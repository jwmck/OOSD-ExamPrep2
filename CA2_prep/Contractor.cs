using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_prep
{
    class Contractor : PartTimer
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private static int _contractorCount;

        public static int ContractorCount
        {
            get { return _contractorCount; }
        }

        public Contractor(string firstName, string lastName, int hours, decimal hourlyRate,
            DateTime startDate, DateTime endDate)
            :base(firstName, lastName,  hours, hourlyRate)
        {
            StartDate = startDate;
            EndDate = endDate;

            _contractorCount++;
        }

        public Contractor(string firstName, string lastName, decimal rate, DateTime startDate)
            :this(firstName, lastName, 0, rate,  startDate, DateTime.Now.AddYears(1))
        {

        }

        public Contractor()
            :this("Unknown", "Unknown", 0, DateTime.Now)
        {

        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" {0} {1}",  StartDate.ToShortDateString(), EndDate.ToShortDateString());
        }
    }
}
