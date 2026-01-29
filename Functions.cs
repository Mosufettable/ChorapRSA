using System;
using System.Numerics;
using System.Security.Cryptography;
using Cryptor;
using Inte;

namespace Func
{
    public class Tions
    {
        public static void KeyGen()
        {
            Program.p = GenerateLargePrime(128);
            Program.q = GenerateLargePrime(128);

            Program.N = Program.p * Program.q;
            Program.Phi = (Program.p - 1) * (Program.q - 1);

            Program.e = 65537;//(많이 쓰이는 65537 사용)
            if (BigInteger.GreatestCommonDivisor(Program.e, Program.Phi) != 1)
            {
                Program.e = 3;
                while (BigInteger.GreatestCommonDivisor(Program.e, Program.Phi) != 1)
                    Program.e++;
            }

            Program.d = ModInverse(Program.e, Program.Phi); // d 계산 (e의 모듈러 역원)

            Waster(); // 보안상 p, q 제거
        }

        public static void Encrypt() // 암호화: c = a^e mod N
        {
            Program.b = BigInteger.ModPow(Program.a, Program.e, Program.N);
        }

        public static void Decrypt() // 복호화: a = c^d mod N
        {
            Program.a = BigInteger.ModPow(Program.b, Program.d, Program.N);
        }

        static bool IsProbablePrime(BigInteger n, int k = 10)
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
                BigInteger a = RandomBigInteger(2, n - 2);
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

        static BigInteger GenerateLargePrime(int bits)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                while (true)
                {
                    byte[] bytes = new byte[bits / 8];
                    rng.GetBytes(bytes);
                    BigInteger candidate = new BigInteger(bytes);
                    if (candidate < 0) candidate = -candidate;
                    if (IsProbablePrime(candidate)) return candidate;
                }
            }
        }

        static BigInteger RandomBigInteger(BigInteger min, BigInteger max)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = max.ToByteArray();
                BigInteger result;
                do
                {
                    rng.GetBytes(bytes);
                    result = new BigInteger(bytes);
                } while (result < min || result >= max);
                return result;
            }
        }

        static BigInteger ModInverse(BigInteger e, BigInteger phi)
        {
            BigInteger t = 0, newt = 1;
            BigInteger r = phi, newr = e;

            while (newr != 0)
            {
                BigInteger quotient = r / newr;
                (t, newt) = (newt, t - quotient * newt);
                (r, newr) = (newr, r - quotient * newr);
            }

            if (r > 1) throw new Exception("e is not invertible");
            if (t < 0) t += phi;
            return t;
        }

        static void Waster()
        {
            Program.p = 0;
            Program.q = 0;
        }
    }
}