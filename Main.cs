using System;
using System.Numerics;
using Inte;
using Func;

namespace Cryptor
{
    class Chorap // I am a Chorap... (Chorap==Newbie==초보)
    {
        public static BigInteger a; // 원본 숫자
        public static BigInteger b; // 암호화된 숫자
        public static BigInteger A; // a^e
        public static BigInteger B; // b^d
        public static BigInteger p; // 소수-1
        public static BigInteger q; // 소수-2
        public static BigInteger N; // p*q(=공개키 N)
        public static BigInteger P; // 오일러 피 함수 (p-1)(q-1)
        public static BigInteger e; // 공개키에 곱할 거
        public static BigInteger d; // 개인키에 곱할 거
        static void Main(string[] args)
        {
            Res(); //초기화           
            rFace.Processing(); //본격적인 실행
        }
        static void Res()
        {
            a = 0;
            b = 0;
            A = 0;
            B = 0;
            p = 0;
            q = 0;
            N = 0;
            P = 0;
            e = 0;
            d = 0;
        }
    }
}