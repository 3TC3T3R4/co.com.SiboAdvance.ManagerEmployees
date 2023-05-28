using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace managerEmployees.Domain.Entities
{
    public class Employee
    {

        public int employees_id { get; set; }
        public int subArea_id { get; set; }
        public string typeDocument { get; set; }
        public int number_ID { get; set; }
        public string name { get; set; } 
        public string lastName { get; set; }

        public Employee()
        {
        }




    }
}
