using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exec1_secao9.Entities;
using Exec1_secao9.Entities.Enums;

namespace Exec1_secao9.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public Enumw Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        public  List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name, Enumw level, double baseSalary, Department department)
        {
            Name=name;
            Level=level;
            BaseSalary=baseSalary;
            Department=department;
        }

        public void ContratoAdd(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void ContratoRem(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach(HourContract contrato in Contracts)
            {
                if(contrato.Date.Year == year && contrato.Date.Month == month )
                {
                    sum += contrato.totalValue();
                }
            }
            return sum;

        }
    }
}
