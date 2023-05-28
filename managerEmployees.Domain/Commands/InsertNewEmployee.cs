using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managerEmployees.Domain.Commands
{
    public class InsertNewEmployee
    {

        public int area_id { get; set; }
        public string typeDocument { get; set; }
        public int number_ID { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }


    }
}
