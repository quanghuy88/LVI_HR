using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class hr_employee
    {
        public decimal id { get; set; }
        public string Employee_code { get; set; }
        public string fullname { get; set; }
        public string department_id { get; set; }
        public decimal placeofbird { get; set; }
        public DateTime dateofbird { get; set; }
        public string cccd { get; set; }
        public DateTime issue_date_cccd { get; set; }
        public string issue_place_cccd { get; set; }
        public string expired_cccd { get; set; }
        public string phone_number { get; set; }
        public string nationality { get; set; }
        public string ethnic { get; set; }
        public string religion { get; set; }
        public decimal marital_status { get; set; }
        public decimal education_level { get; set; }
        public string university { get; set; }
        public string? major { get; set; }
        public DateTime? graduation_date { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
    }
}
