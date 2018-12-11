using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace Lesson_2_HomeWork
{
    /// <summary>
    /// Класс 
    /// </summary>
    class Workers:IComparer
    {
       public Workers() { }
       public Worker[] workers = new Worker[10];
        //Метод вывода на экран информации о рабочих с использованием foreach
        public void emploersPrint()
        {
            foreach (Worker w in workers)
            {
                if (w is WorkerFixSalary)
                {
                    Console.WriteLine("Name-{0}{1}Salary in mounth-{2}", w.name,"\t", (w as WorkerFixSalary).fixRate);
                }

                if (w is WorkerHourSalary)
                {
                    Console.WriteLine("Name-{0}{1}Salary in hour-{1}", w.name,"\t", (w as WorkerHourSalary).hourlyRate);
                }


            }
        }
        
        //Реализация интерфейса IComparer. Сравнение по заработной плате.
        int IComparer.Compare(object x, object y)
        {
            if ((x is WorkerFixSalary) && (y is WorkerFixSalary))
            {
                if ((x as WorkerFixSalary).fixRate < (y as WorkerFixSalary).fixRate)
                {
                    return 1;
                }
                else if ((x as WorkerFixSalary).fixRate > (y as WorkerFixSalary).fixRate)
                {
                    return -1;
                }
                else return 0;
            }
            
            if ((x is WorkerHourSalary) && (y is WorkerHourSalary))
            {
                if ((x as WorkerHourSalary).hourlyRate < (y as WorkerHourSalary).hourlyRate)
                {
                    return 1;
                }
                else if ((x as WorkerHourSalary).hourlyRate > (y as WorkerHourSalary).hourlyRate)
                {
                    return -1;
                }
                else return 0;

            }
            return 2;
        }

        public static IComparer WorkersComparer()
        {
            return new Workers();
        }
    }
}
