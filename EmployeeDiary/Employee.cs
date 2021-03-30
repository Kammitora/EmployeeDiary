using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDiary
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public int? Salary { get; set; }
        public string AgreementType { get; set; }
        public DateTime HiringDate { get; set; }
        public bool IsFired { get; set; }
        public DateTime? FiringDate { get; set; }
    }
}
