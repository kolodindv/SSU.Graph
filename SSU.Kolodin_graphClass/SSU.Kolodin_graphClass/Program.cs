using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.Kolodin_graphClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding windows = Encoding.GetEncoding(1251);
            string path = @"..\..\graph_list.txt";
                
            string[] grProperties;
            using (StreamReader rd = new StreamReader(path, windows))
            {
                string line = rd.ReadLine();
                char[] sym__ = { ' ' };
                grProperties = line.Split(sym__, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(grProperties[0]);
            Console.WriteLine(grProperties[1]);

            Type myType1 = Type.GetType("System.Int32");
            Type a = Type.GetType(grProperties[0]);
           
            Graph <string, int> first = new Graph<string, int>(path);
            Console.WriteLine("Успешно считано с файла");
            Console.ReadLine();


            //foreach (var prop in props)
            //{
            //    Console.WriteLine(prop.Name);
            //}

            // Graph <grProperties[0], grProperties[1]> words = new Graph<((Type)grProperties[0], grProperties[1]>(path);
        }
    }
}
