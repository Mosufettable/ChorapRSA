using System;
using System.Numerics;
using Cryptor;
using Func;

namespace Inte
{
    public class rFace
    {
        public static void Processing()
        {
            Tions.KeyGen();

            Console.WriteLine($"공개키 (N): {Cryptor.Program.N}");
            Console.WriteLine($"공개키 (e): {Cryptor.Program.e}");
            Console.WriteLine($"개인키 (d): {Cryptor.Program.d}");

            Cryptor.Program.a = 7; // 테스트용 원본 메시지
            Console.WriteLine($"원본 메시지(테스트로 설정해둔 것): {Cryptor.Program.a}");

            Tions.Encrypt();
            Console.WriteLine($"암호화 결과: {Cryptor.Program.b}");

            Tions.Decrypt();
            Console.WriteLine($"복호화 결과: {Cryptor.Program.a}");
        }
    }
}