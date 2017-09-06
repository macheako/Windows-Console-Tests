using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config();

            config.AddSection("string");
            config.AddSection("int");
            config.AddSection("float");
            config.AddSection("bool");

            config.Set("string", "var",  "value11");
            config.Set("int", "var", "1");
            config.Set("float", "var", "1.1");
            config.Set("bool", "var", "yes");
            config.Set("bool", "var2", "no");


            Console.Write(config);

            string endl = Environment.NewLine;

            Console.Write(config.Get("string", "var"));
            Console.Write(endl);

            Console.Write(config.Getint("int", "var") + 1);
            Console.Write(endl);
            
            Console.Write(config.Getfloat("float", "var") + 1.1);
            Console.Write(endl);

            Console.Write(config.Getboolean("bool", "var"));
            Console.Write(endl);

            Console.Write(config.Getboolean("bool", "var2"));
            Console.Write(endl);

            Console.Write(config.HasOption("string", "var"));
            config.RemoveOption("string", "var");
            Console.Write(endl);
            Console.Write(config.HasOption("string", "var"));
            Console.Write(endl);

            Console.ReadKey();
        }
    }
}
