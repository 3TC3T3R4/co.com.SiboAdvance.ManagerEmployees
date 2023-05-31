using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managerEmployees.Domain.Entities
{
    public class SubArea
    {
        public int subArea_id { get; set; }
        public int area_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public SubArea() { }
    }
}
