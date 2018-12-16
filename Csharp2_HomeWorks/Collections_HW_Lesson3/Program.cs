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
        public static List<int> listInt = new List<int>();//Исходная коллекция целых чисел
        public static Random rand = new Random();
        public static Dictionary<int, int> countInt = new Dictionary<int, int>();//Словарь для подсчета элементов в коллекции
        public static Dictionary<int, int> countInt1 = new Dictionary<int, int>();//Словарь для подсчета с использованием LINQ
        static void Main(string[] args)
        {
                       
            //Подсчет количества вхождений в список для целых чисел
            #region
            for (int i=0;i<100;i++)
            {
                listInt.Add(rand.Next(1, 100));
            }
            Console.WriteLine("Задана коллекция целых чисел:");
            foreach (int i in listInt)
            {
                Console.Write(i+" ");
            }
            listInt.Sort();
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.ReadKey();
            Console.WriteLine("Cколько раз каждый элемент встречается в данной коллекции");
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
            
            //Метод добавления в словарь
            void Add(int item)
            {
                countInt.Add(item, ++count);
                count = 0;
            }
            printDictionary(countInt);
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.ReadKey();
            #endregion

            //Подсчет количества вхождений в список для целых чисел c использованием LINQ 
            #region
            List<int> filter2;
            //Выбор элементов из коллекции с помощью LINQ запроса
            foreach (int i in listInt)
            {
                if (!countInt1.ContainsKey(i))
                {
                    filter2 = listInt.Where(s => s == i).ToList();//выборка из исходной коллекции по значению текущего элемента
                    countInt1.Add(i, filter2.Count);//запись значения и количество элементов выборки
                }
            }

            Console.WriteLine("Cколько раз каждый элемент встречается в заданной коллекции c использованием LINQ");
            printDictionary(countInt1);
            Console.ReadKey();
            #endregion

            void printDictionary(Dictionary<int,int> countInt)
            {
                foreach (KeyValuePair<int, int> d in countInt)
                {
                    Console.WriteLine($"{d.Key}-{d.Value}");
                }
            }
        }
    }
}
