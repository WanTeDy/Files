using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Files2
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader(@"C:\1\war.txt", Encoding.Default);
            string content = sr.ReadToEnd();
            sr.Close();
            List<String> singleWord = new List<string>();
            string[] temp;
            temp = Regex.Replace(content, "[!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~\\\\\\d]+", " ").Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var str in temp)
            {
                if(str.Length >= 3 && str.Length <= 20)
                singleWord.Add(str);
            }
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (var el in singleWord)
            {
                if (!words.ContainsKey(el))
                {
                    words.Add(el, 1);
                }
                else
                {
                    words[el]++;
                }
            }
            int count = 0;
            foreach (var pair in words.OrderByDescending(pair => pair.Value))
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                if (++count == 50)
                    break;
                if(count % 10 == 0)
                {
                    Console.ReadLine();
                }
            }

        }
    }
}
