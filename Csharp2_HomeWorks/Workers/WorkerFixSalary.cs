using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_HomeWork
{
    /// <summary>
    /// Класс Рабочий с фиксированной платой
    /// </summary>
    class WorkerFixSalary:Worker
    {
        public double fixRate { get; set;}
        public WorkerFixSalary(string _name, double _fixRate) : base(_name)
        {
            fixRate = _fixRate;
        }
        //Метод расчета зарплаты
        public override void SalaryCalc()
        {
            averageSalary = fixRate;
        }
    }
}
