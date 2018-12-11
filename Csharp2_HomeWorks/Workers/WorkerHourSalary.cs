using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_HomeWork
{/// <summary>
/// Класс Рабочий с почасовой оплатой
/// </summary>
    class WorkerHourSalary:Worker
    {
        public double hourlyRate { get; set; }
        public WorkerHourSalary(string _name,double _hourlyRate) : base(_name)
        {
            hourlyRate = _hourlyRate;
        }
        //Метод расчета зарплаты
        public override void SalaryCalc()
        {
            averageSalary = 20.8 * 8 * hourlyRate;
        }
    }
}
