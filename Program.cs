using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hesap.Makinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Написат как такое : 2 + 5 +...");
                string s = Console.ReadLine();
                string[] split = s.Split(' ');

                if (split.Length < 3 || split.Length % 2 == 0)
                {
                    Console.WriteLine("Выполните действия с числами");
                    continue;
                }

                List<int> sanlar = new List<int>();
                List<string> amallar = new List<string>();


                for (int i = 0; i < split.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        sanlar.Add(Convert.ToInt32(split[i]));
                    }
                    else
                    {
                        amallar.Add(split[i]);
                    }
                }

                while (amallar.Contains("*") || amallar.Contains("/"))
                {
                    for (int i = 0; i < amallar.Count; i++)
                    {
                        if (amallar[i] == "*" || amallar[i] == "/")
                        {
                            int result = (amallar[i] == "*") ? sanlar[i] * sanlar[i + 1] : sanlar[i] / sanlar[i + 1];

                            sanlar[i] = result;
                            sanlar.RemoveAt(i + 1);
                            amallar.RemoveAt(i);
                            break; 
                        }
                    }
                }

                while (amallar.Count > 0)
                {
                    int result = (amallar[0] == "+") ? sanlar[0] + sanlar[1] : sanlar[0] - sanlar[1];

                    sanlar[0] = result;
                    sanlar.RemoveAt(1);
                    amallar.RemoveAt(0);
                }

                Console.WriteLine("Sonuç: " + sanlar[0]);
            }
        }
    




public static int gosmak(int a, int b)
        { return a + b; }
        public static int ayyrmak(int a, int b)
        { return a - b; }
        public static int kopeltmek(int a, int b)
        { return a * b; }
        public static int bolmek(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Ошибка");
                return 0;
            }
            return a / b;
        
        }
    }
}
