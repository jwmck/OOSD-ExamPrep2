using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_prep
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        private static int _empCount;

        public static int EmpCount
        {
            get { return _empCount; }
        }

        //public static int noOfEmployees;

       

        public Employee(string firstName, string lastName, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;

            _empCount++;
        }

        public Employee(string firstName, string lastName)
           : this(firstName, lastName, 0 )
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = 0;
        }

        public Employee()
            :this("Unknown", "Unknown")
        {

        }
        public override string ToString()
        {
            return string.Format(" [{0}] {1} {2} {3:C}", this.GetType().Name.ToUpper(), FirstName, LastName, Salary );
        }
    }
}
