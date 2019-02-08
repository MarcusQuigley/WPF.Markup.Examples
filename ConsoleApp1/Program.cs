using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = CleanFile(@"C:\Users\Marcus\Downloads\Comparable DataTrigger.txt");
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
          
            Console.ReadKey();
        }

        static IEnumerable<string> CleanFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("path is empty");
            if (!File.Exists(path))
                throw new ArgumentException("path is not valid");
            var data = File.ReadAllLines(path)
                        .Select(l => l.Trim())
                        .Where(l => string.IsNullOrEmpty(l) == false)
                        
                        ;
            File.WriteAllLines("newFile.txt", data);
            return data;
                    
            
        }
    }
}
