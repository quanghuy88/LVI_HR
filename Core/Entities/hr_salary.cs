using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class hr_salary
    {
        public decimal id { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public decimal type { get; set; }
        public decimal departmentid { get; set; }
        public decimal amount { get; set; }
        public int? sequence { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
    }
}
