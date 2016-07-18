using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Files1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"C:\1\");
            string searchTo = "test";
            foreach(var file in files)
            {
                StreamReader sr = new StreamReader(file, Encoding.Default);                
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    if(line.Contains(searchTo))
                    {
                        Console.WriteLine(file);
                        break;
                    }
                }
            }
        }
    }
}
