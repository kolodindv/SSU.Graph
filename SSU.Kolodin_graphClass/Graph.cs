using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace SSU.Kolodin_graphClass
{
    class Graph <Tname, Tweight>
    {
        //adjacency list -> adjList
        private Dictionary<Tname, Dictionary<Tname, Tweight>> adjList;
        //private string splSep = " ^?";



        //public bool Directed
        //{
        //    get; 
        //}

        private bool Directed;
        private bool Weighted;
        

        //сделать возможность выбирать в файле тип и считывать его
     

        private static TType TakeFromString <TType> (string in_)
        {
            
            Console.WriteLine("На вход взята: {0}", in_);
            TypeConverter toTname = TypeDescriptor.GetConverter(typeof(TType));

            var onon = (TType)toTname.ConvertFrom(in_);
            Console.WriteLine("На выход ушла: {0}", onon);
            return onon;
        }

        public Graph()
        {
            Directed = false;
            Weighted = false;
            adjList = new Dictionary<Tname, Dictionary<Tname, Tweight>>(); //конструктор по умолчанию, создающий пустой граф
        }

        public Graph(Graph<Tname, Tweight> toCopy)   //конструктор, создающий копию графа
        {
            Directed = toCopy.Directed;
            Weighted = toCopy.Weighted;
            adjList = new Dictionary<Tname, Dictionary<Tname, Tweight>>(toCopy.adjList);
        }

        public Graph(string path)
        {
            Encoding windows = Encoding.GetEncoding(1251);
            using (StreamReader rd = new StreamReader(path, windows))
            {
                string line = rd.ReadLine();
                line = rd.ReadLine();
                char[] sym__ = { ' ' };
                string[] grProperties = line.Split(sym__, StringSplitOptions.RemoveEmptyEntries);

                Directed = grProperties.Contains("Directed") ? true : false;
                Weighted = grProperties.Contains("Weighted") ? true : false;

                string[] special_seps = { " --- ", "|", " |: ", " "};
                string[] in_;

                adjList = new Dictionary<Tname, Dictionary<Tname, Tweight>>();

                Tweight digit1 = TakeFromString<Tweight>("1");
                Console.WriteLine("Создали еденичку");

                while (!rd.EndOfStream)
                {
                    in_ = rd.ReadLine().Split(special_seps, StringSplitOptions.RemoveEmptyEntries); 
                    foreach (var ini in in_)
                    {
                        Console.Write("`{0}`", ini);
                    }
                    Console.WriteLine();


                    Tname active_node = TakeFromString<Tname>(in_[0]);

                    Console.WriteLine("Активная вершина {0}", active_node);

                    Dictionary<Tname, Tweight> deepAdj = new Dictionary<Tname, Tweight>(); //инициализация субсловаря (глубокого словаря)

                    int step = Weighted ? 2 : 1;    //шаг, если граф взвешенный, то будут пары имя смежной вершины + вес (шаг длины 2) 
                                                    //иначе просто список имен смежных вершин (шаг длины 1)                    

                    for (int i = 1; i < in_.Length; i += step)
                    {

                        deepAdj.Add(TakeFromString<Tname>(in_[i]), Weighted ? TakeFromString<Tweight>(in_[i + 1]) : digit1);
                    }

                    adjList.Add(active_node, deepAdj);
                }


            }
        }

       
    }
}

