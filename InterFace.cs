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
            Console.WriteLine("=========================================");
            Console.WriteLine($"공개키 (N): {Cryptor.Program.N}");
            Console.WriteLine($"공개키 (e): {Cryptor.Program.e}");
            Console.WriteLine($"개인키 (d): {Cryptor.Program.d}");
            Console.WriteLine("=========================================");
            Console.WriteLine("\n암호화할 숫자를 입력하시라요...");
            Cryptor.Program.a = BigInteger.Parse(Console.ReadLine());
            Tions.Encrypt();
            Console.WriteLine($"암호화 결과: {Cryptor.Program.b}");
            Console.WriteLine("\n복호화하시겠습네까...(Y/N)");
            Tions.Decrypt();
            Console.WriteLine($"복호화 결과: {Cryptor.Program.a}");
        }
    }
}