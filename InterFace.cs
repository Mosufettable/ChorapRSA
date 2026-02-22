using System;
using System.Numerics;
using Cryptor;
using Func;

namespace Inte
{
    public class rFace
    {
        public static int C;
        public static void Processing()
        {
            menu();
            C = readC();
            operate();
        }

        public static void menu()
        {
            Console.WriteLine("원하시는 기능을 선택해주십시오...(1,2,3)");
            Console.WriteLine("1.키 생성");
            Console.WriteLine("2.암호화");
            Console.WriteLine("3.복호화");
        }

        public static int readC()
        {
            while (true)
            {
                Console.Write(">> ");
                if (int.TryParse(Console.ReadLine(), out int v) && v >= 1 && v <= 3)
                    return v;
                Console.WriteLine("입력값이 올바르지 않습니다.");
            }
        }

        public static BigInteger readNum()
        {
            while (true)
            {
                Console.Write(">> ");
                if (BigInteger.TryParse(Console.ReadLine(), out BigInteger v) && v > 0)
                    return v;
                Console.WriteLine("입력값이 올바르지 않습니다.");
            }
        }
        
        public static void operate()
        {
            if (C == 1)
            {
                Tions.KeyGen();
                Console.WriteLine("====================================================================================");
                Console.WriteLine($"공개키 (N): {Cryptor.Chorap.N}");
                Console.WriteLine($"공개키 (e): {Cryptor.Chorap.e}");
                Console.WriteLine($"개인키 (d): {Cryptor.Chorap.d}");
                Console.WriteLine("====================================================================================");
            }

            else if (C == 2)
            {
                Console.WriteLine("암호화할 자연수를 입력하십시오...");
                Cryptor.Chorap.a = readNum();
                Console.WriteLine("공개키 (N)를 입력하십시오...");
                Cryptor.Chorap.N = readNum();
                Console.WriteLine("공개키 (e)를 입력하십시오...");
                Cryptor.Chorap.e = readNum();
                Console.WriteLine("개인키 (d)를 입력하십시오...");
                Cryptor.Chorap.d = readNum();
                Tions.Encrypt();
                Console.WriteLine("\n================================================");
                Console.WriteLine($"원본: {Cryptor.Chorap.a}");
                Console.WriteLine($"암호본: {Cryptor.Chorap.b}");
                Console.WriteLine("================================================");
            }

            else if (C == 3)
            {
                Console.WriteLine("복호화할 자연수를 입력하십시오...");
                Cryptor.Chorap.b = readNum();
                Console.WriteLine("공개키 (N)를 입력하십시오...");
                Cryptor.Chorap.N = readNum();
                Console.WriteLine("공개키 (e)를 입력하십시오...");
                Cryptor.Chorap.e = readNum();
                Console.WriteLine("개인키 (d)를 입력하십시오...");
                Cryptor.Chorap.d = readNum();
                Tions.Decrypt();
                Console.WriteLine("\n================================================");
                Console.WriteLine($"원본: {Cryptor.Chorap.a}");
                Console.WriteLine($"암호본: {Cryptor.Chorap.b}");
                Console.WriteLine("================================================");
            }

            Console.WriteLine("종료하시려면 아무 키나 눌러주십시오...");
            Console.ReadKey();
        }
    }
}