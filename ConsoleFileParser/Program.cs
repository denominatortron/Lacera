using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserLibrary;
using ParserLibrary.Entities;

namespace ConsoleFileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 1)
            {
                System.Console.WriteLine("Please enter only one argument.");
                System.Console.WriteLine("Usage: ConsoleFileParser <filename>");
                return;
            }

            Parser<Employee> parser = new Parser<Employee>();
            List<Employee> employees = parser.ParseCSV(args[0]);
            
            //clean up, don't show invalid employees
            employees.RemoveAll(x => x.Invalid == true);

            foreach (Employee e in employees)
            { 
                Console.WriteLine(e.Name + ", " +
                                  e.Birthdate.ToShortDateString() + ", " +
                                  e.Salary + ", " +
                                  e.DateHired.ToShortDateString());
                
            }

            Console.ReadLine();
            return;
        }
    }
}
