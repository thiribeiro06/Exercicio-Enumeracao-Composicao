using System;
using System.Globalization;
using System.Threading.Tasks;
using Exec1_secao9.Entities;
using Exec1_secao9.Entities.Enums;

namespace Exec1_secao9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Cadastro de Contrato de Trabalho -----");
            Console.Write("Entre com o nome do Departamento: ");
            string nomeDept = Console.ReadLine();
            Console.Write("Nome do Funcionario: ");
            string nomeFunc = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            string v = (Console.ReadLine());
            Enum.TryParse(v, out Enumw level);               
            Console.Write("Salario Base: ");
            double salarioBase = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("Quantos contratos você deseja cadastrar? ");
            int n = int.Parse(Console.ReadLine());
            Console.Clear();
            Department dept = new Department(nomeDept);

            Worker worker = new Worker(nomeFunc, level, salarioBase, dept);

            Console.WriteLine("----- Cadastro de Contrato de Trabalho -----");
            for (int i = 1; i <= n; i++)
            {                
                Console.Write("Contrato {0} ", i);
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valor = double.Parse(Console.ReadLine());
                Console.Write("Duração(horas): ");
                int hora = int.Parse(Console.ReadLine());
                
                HourContract contrato = new HourContract(data, valor, hora);                
                worker.ContratoAdd(contrato);
            }
            Console.Clear();

            Console.WriteLine("----- Cálculo da Renda de Trabalho -----");
            Console.Write("Entre com o mes e ano para cálculo da renda (MM/YYYY): ");
            string mesEano = Console.ReadLine();
            int mes = int.Parse(mesEano.Substring(0, 2));
            int ano = int.Parse(mesEano.Substring(3));
            double resultado = worker.Income(ano, mes);


            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Nome);
            Console.WriteLine("Renda em " + mesEano + ": " + resultado.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine();
            
        }
    }
}
