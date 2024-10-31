using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class admin_user
    {
        public decimal id { get; set; }
        public decimal? staff_id { get; set; }
        public decimal? original_user_id { get; set; }
        public decimal? unit_id { get; set; }
        public string? name { get; set; }
        public string? name_en { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? password_decrypted { get; set; }
        public string? note { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
        public bool? is_online { get; set; }
        public decimal? branch_id { get; set; }
        public bool? first_login { get; set; }
    }
}
