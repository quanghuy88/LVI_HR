using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class hr_timesheet
    {
        public decimal id { get; set; }
        public string timesheet_code { get; set; }
        public int accountmonth { get; set; }
        public int datadate { get; set; }
        public int intput_hour { get; set; }
        public int input_minute { get; set; }
        public int input_second { get; set; }
        public int output_hour { get; set; }
        public int output_minute { get; set; }
        public int output_second { get; set; }
        public string employee_code { get; set; }
    }
}
