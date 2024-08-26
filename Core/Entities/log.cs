using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class log
    {
        public decimal id { get; set; }
        public string error_message { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? created_date { get; set; }
    }

}
