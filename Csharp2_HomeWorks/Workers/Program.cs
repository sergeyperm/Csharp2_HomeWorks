using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Workers w = new Workers();//Создание экземпляра класса, содержащго массив сотрудников
            //Заполнение массива сотрудников
            w.workers[0] = new WorkerFixSalary("Vadim", 50000.00);
            w.workers[1] = new WorkerFixSalary("Alexey", 20000.00);
            w.workers[2] = new WorkerFixSalary("Dmtriy", 80000.00);
            w.workers[3] = new WorkerFixSalary("Oleg", 90000.00);
            w.workers[4] = new WorkerFixSalary("Stas", 100000.00);
            w.workers[5] = new WorkerFixSalary("Gleb", 120000.00);
            w.workers[6] = new WorkerFixSalary("Sergey", 130000.00);
            w.workers[7] = new WorkerFixSalary("Daniil", 100000.00);
            w.workers[8] = new WorkerFixSalary("Slava", 80000.00);
            w.workers[9] = new WorkerFixSalary("Ivan", 10000.00);
            //Вывод на экран массива сотрудников
            Console.WriteLine("Список сотрудников:");
            Console.WriteLine("=================");
            w.emploersPrint();
            Console.WriteLine("=================");
            Console.WriteLine("Нажмите любую клавишу для сортировки списка сотрудников");
            Console.ReadKey();
            Console.WriteLine("=================");
            Console.WriteLine("Список сотрудников после сортировки по убыванию уровня зарплаты:");
            //Сортировка по убыванию массива сотрудников
            Array.Sort(w.workers,Workers.WorkersComparer());
            w.emploersPrint();
           
            Console.WriteLine("=================");
            Console.ReadKey();
        }
    }
}
