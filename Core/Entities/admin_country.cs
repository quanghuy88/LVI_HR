using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class admin_country
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public string postal_code { get; set; }
        public string description { get; set; }
        public int? sequence { get; set; }
        public DateTime create_date { get; set; }
        public decimal created_by { get; set; }
        public DateTime modified_date { get; set; }
        public decimal modified_by { get; set; }
    }
}
