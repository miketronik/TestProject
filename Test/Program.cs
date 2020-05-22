using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    public class Program {
        static void Main(string[] args) {

            string path = Directory.GetCurrentDirectory();

            int i = path.LastIndexOf("\\");
            path = path.Substring(0,i);

            i = path.LastIndexOf("\\");
            path = path.Substring(0, i)+"\\";

            Console.WriteLine(path);

            Console.ReadKey();

        }
    }
}
