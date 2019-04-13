using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_prep
{
    class PartTimer : Employee
    {
        public decimal HourlyRate { get; set; }
        public int Hours { get; set; }

        private static int _partTimerCount;

        public static int PartTimerCount
        {
            get { return _partTimerCount; }
        }

        public PartTimer(string firstName, string lastName, int hours, decimal hourlyRate)
            : base(firstName, lastName)
        {
            HourlyRate = hourlyRate;
            Hours = hours;
            _partTimerCount++;
        }

        public PartTimer(string firstName, string lastName)
            :this(firstName, lastName, 0,0)
        {

        }

        public PartTimer()
            : this("Unknown", "Unknown")
        {

        }

        public override string ToString()
        {
            return string.Format(" [{0}] {1} {2} Weekly wages{3}", this.GetType().Name.ToUpper(), FirstName, LastName,  HourlyRate* Hours);
        }
    }
}
