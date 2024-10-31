using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class admin_department
    {
        public decimal id { get; set; }
        public string? code { get; set; }
        public string? code_ref { get; set; }
        public string? contact_name { get; set; }
        public string? contact_tel { get; set; }
        public string? name { get; set; }
        public decimal? domain_id { get; set; }
        public decimal? parent_id { get; set; }
        public string? name_abbreviation { get; set; }
        public int? level { get; set; }
        public string? address { get; set; }
        public decimal? place_id { get; set; }
        public string? image { get; set; }
        public string? slogan { get; set; }
        public string? tel { get; set; }
        public string? fax { get; set; }
        public string? email { get; set; }
        public string? website { get; set; }
        public string? tax_code { get; set; }
        public string? director_name { get; set; }
        public string? account_name { get; set; }
        public string? acc_no { get; set; }
        public string? bank_name { get; set; }
        public string? bank_address { get; set; }
        public string? bussiness_registration_no { get; set; }
        public DateTime? issued_date { get; set; }
        public string? issued_by { get; set; }
        public string? contact_address { get; set; }
        public string? contact_mobile { get; set; }
        public string? contact_email { get; set; }
        public string? note { get; set; }
        public int? sequence { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
    }
}
