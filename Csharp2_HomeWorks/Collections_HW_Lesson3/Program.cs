using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_HW_Lesson3
{
    class Program
    {
        public static List<int> listInt = new List<int>();
        public static List<T> listGeneric = new List<T>();
        public static int[] arrayInt;
        public static Random rand = new Random();
        public static Dictionary<int, int> countInt = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            #region
            for (int i=0;i<100;i++)
            {
                listInt.Add(rand.Next(1, 100));
            }
            foreach (int i in listInt)
            {
                Console.Write(i+" ");
            }
            listInt.Sort();
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.ReadKey();
            foreach (int i in listInt)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.ReadKey();
            int count = 0;
            for (int k=0;k<listInt.Count;k++)
            {
                if (((k + 1) < listInt.Count))
                {
                    if (listInt[k] == listInt[k +1])
                    {
                        count++;
                    }
                    else
                    {
                        Add(listInt[k]);
                    }
                }
                else
                {
                    Add(listInt[k]);
                }

            }

            void Add(int item)
            {
                countInt.Add(item, ++count);
                count = 0;
            }
        
            foreach (KeyValuePair<int, int> d in countInt)
            {
                Console.WriteLine($"{d.Key}-{d.Value}");
            }
           
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.ReadKey();
            var numbers = from n in listInt
                          where n > 20
                          select n;


            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.ReadKey();

            #endregion  //Подсчет количества вхождений в список для целых чисел



        }
    }
}
