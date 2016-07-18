using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Files3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\");
            FileInfo[] fi = null;
            try
            {
                fi = di.GetFiles("*.*", SearchOption.AllDirectories);
            }
            catch(UnauthorizedAccessException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            if (fi != null)
            {
                Dictionary<string, int> files = new Dictionary<string, int>();
                Dictionary<string, long> fileSize = new Dictionary<string, long>();
                int total = 0;
                long totalSize = 0;
                foreach (var el in fi)
                {
                    total++;
                    totalSize += el.Length;
                    if (el.Extension == "")
                    {
                        continue;
                    }
                    else if (!files.ContainsKey(el.Extension))
                    {
                        files.Add(el.Extension, 1);
                        fileSize.Add(el.Extension, el.Length);
                    }
                    else
                    {
                        files[el.Extension]++;
                        fileSize[el.Extension] += el.Length;
                    }
                }
                int count = 0;
                Console.WriteLine("Расширение - Кол-во - % кол-ва - % объёма");
                foreach (var pair in files.OrderByDescending(pair => pair.Value))
                {
                    Console.WriteLine("{0} - {1} - {2} - {3:f4} - {4:f4}", pair.Key, pair.Value, fileSize[pair.Key], pair.Value / (double)total * 100, fileSize[pair.Key] / (double)totalSize * 100);
                    if (++count == 50)
                        break;
                    if (count % 10 == 0)
                    {
                        Console.ReadLine();
                    }
                }
                Console.WriteLine("TOTAL - {0} - {1} - 100 - 100", total, totalSize);
            }
        }
    }
}
