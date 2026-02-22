using System;
using System.Numerics;
using System.Security.Cryptography;
using Cryptor;
using Inte;

namespace Func
{
    public class Tions
    {
        public static void KeyGen() //키 제작소
        {
            Chorap.p = primegen(128);
            Chorap.q = primegen(128);

            Chorap.N = Chorap.p * Chorap.q;
            Chorap.P = (Chorap.p - 1) * (Chorap.q - 1);

            Chorap.e = 65537; //이게 요즘 대세라며
            if (BigInteger.GreatestCommonDivisor(Chorap.e, Chorap.P) != 1)
            {
                Chorap.e = 3;
                while (BigInteger.GreatestCommonDivisor(Chorap.e, Chorap.P) != 1)
                    Chorap.e++;
            }

            Chorap.d = moder(Chorap.e, Chorap.P); //e의 모듈러 역원인 d 계산(인데 사실 나도 잘 몰라)

            killer(); //p,q 혹시 모르니까 지울게
        }

        public static void Encrypt() //b = a^e mod N (사실 모드연산 나도 몰라)
        {
            Chorap.b = BigInteger.ModPow(Chorap.a, Chorap.e, Chorap.N);
        }

        public static void Decrypt() //a = b^d mod N (걍 인터넷에서 이러면 된다길래 이렇게 한 거임)
        {
            Chorap.a = BigInteger.ModPow(Chorap.b, Chorap.d, Chorap.N);
        }

        static bool isprime(BigInteger n, int k = 10) //아래꺼랑 꼬이긴 했는데 어쨌든 소수판정기
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0) return false;

            BigInteger d = n - 1;
            int r = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                r++;
            }

            for (int i = 0; i < k; i++)
            {
                BigInteger a = randgen(2, n - 2);
                BigInteger x = BigInteger.ModPow(a, d, n);
                if (x == 1 || x == n - 1) continue;

                bool cont = false;
                for (int j = 0; j < r - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == n - 1)
                    {
                        cont = true;
                        break;
                    }
                }
                if (!cont) return false;
            }
            return true;
        }

        static BigInteger primegen(int bits) //큰 수 생성기
        {
            using (var dr = RandomNumberGenerator.Create())
            {
                while (true)
                {
                    byte[] bytes = new byte[bits / 8];
                    dr.GetBytes(bytes);
                    BigInteger candidate = new BigInteger(bytes);
                    if (candidate < 0) candidate = -candidate;
                    if (isprime(candidate)) return candidate;
                }
            }
        }

        static BigInteger randgen(BigInteger min, BigInteger max)
        {
            using (var dr = RandomNumberGenerator.Create())
            {
                byte[] bytes = max.ToByteArray();
                BigInteger result;
                do
                {
                    dr.GetBytes(bytes);
                    result = new BigInteger(bytes);
                } while (result < min || result >= max);
                return result;
            }
        }

        static BigInteger moder(BigInteger e, BigInteger phi) //대충 모드역원 뭐시기 해주는 놈
        {
            BigInteger t = 0, newt = 1;
            BigInteger r = phi, newr = e;

            while (newr != 0)
            {
                BigInteger quotient = r / newr;
                (t, newt) = (newt, t - quotient * newt);
                (r, newr) = (newr, r - quotient * newr);
            }

            if (r > 1) throw new Exception("e가 역원이 아닙네다.");
            if (t < 0) t += phi;
            return t;
        }

        static void killer() //보안위협줴거용
        {
            Chorap.p = 0;
            Chorap.q = 0;
        }
    }
}