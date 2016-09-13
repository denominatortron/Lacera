using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLibrary.Entities
{
    public class Employee : IParseable
    {
        public String Name { get; set; }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private DateTime dateHired;
        public DateTime DateHired
        {
            get { return dateHired; }
            set { dateHired = value; }
        }

        public bool Invalid { get; set; }

        public void Inflate(String[] inputs)
        {
            Invalid = false;

            if(inputs.Length < 4 || inputs.Contains(String.Empty))
            {
                Invalid = true;
                return;
            }
            Name = inputs[0].Replace("\"", String.Empty);

            bool isGood;
            isGood = DateTime.TryParse(inputs[1], out birthdate);

            if (!isGood)
            {
                Invalid = true;
                return;
            }

            isGood = Decimal.TryParse(inputs[2], out salary);
            if (!isGood || salary == 0)
            {
                Invalid = true;
                return;
            }

            isGood = DateTime.TryParse(inputs[3], out dateHired);
            if (!isGood)
            {
                Invalid = true;
                return;
            }
        }
    }  
}
