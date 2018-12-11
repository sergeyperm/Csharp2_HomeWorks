using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_HomeWork
{
    /// <summary>
    /// Класс Рабочий, содержащий информацию о рабочем
    /// </summary>

    abstract class Worker
    {
        private string _name;

        public string name { get => _name; set => _name = value; }
        public double averageSalary { get; set; }
        public Worker(string _name)
        {
            name = _name;

        }
        public abstract void SalaryCalc();

    }
}
