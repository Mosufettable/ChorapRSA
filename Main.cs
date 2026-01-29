using System;
using System.Numerics;
using Inte;
using Func;

namespace Cryptor
{
    class Program
    {
        // RSA 관련 변수들
        public static BigInteger a; // 원본 메시지
        public static BigInteger b; // 암호화된 메시지
        public static BigInteger A; // a^e (중간 계산)
        public static BigInteger B; // b^d (중간 계산)
        public static BigInteger p; // 소수 1
        public static BigInteger q; // 소수 2
        public static BigInteger N; // 공개키 N = p*q
        public static BigInteger Phi; // 오일러 피 함수 (p-1)(q-1)
        public static BigInteger e; // 공개키 지수
        public static BigInteger d; // 개인키 지수
        public static BigInteger Q; // 사용하지 않는 변수 (잔여)

        public static BigInteger Quoti; // 사용하지 않는 변수 (잔여)

        static void Main(string[] args)
        {
            Res();              // 초기화
            rFace.Processing(); // RSA 테스트 실행
        }

        // 모든 변수 초기화
        static void Res()
        {
            a = 0;
            b = 0;
            A = 0;
            B = 0;
            p = 0;
            q = 0;
            N = 0;
            Phi = 0;
            e = 0;
            d = 0;
            Q = 0;
            Quoti = 0;
        }
    }
}