using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Common
{
    public class Common
    {
        public static string Prompt()
        {
            return Console.ReadLine();
        }

        public static string Prompt(string content)
        {
            Console.Write(content);
            return Console.ReadLine();
        }

        public static void Print(string content)
        {
            Console.WriteLine(content);
        }
    }
}
