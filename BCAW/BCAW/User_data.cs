using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCAW
{
    internal class User_data
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?  SurName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public bool ? Gender { get; set; } = true;  
        public bool ? Experience { get; set; } = true;
        public string ? Job { get; set; }
        public int Salary { get; set; }
        public string? AFewWords { get; set; }

    }
}
