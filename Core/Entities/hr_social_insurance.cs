using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class hr_social_insurance
    {
        public decimal id { get; set; }
        public string insurance_book { get; set; }
        public DateTime issue_date { get; set; }
        public string issue_plate { get; set; }
        public string clinic_address { get; set; }
    }
}
