using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class claim
    {
        public decimal id { get; set; }
        public Nullable<System.Guid> id_referenct { get; set; }
        public Nullable<decimal> id_ref { get; set; }
        public decimal unit_id { get; set; }
        public Nullable<decimal> underwriting_form_id { get; set; }
        public string underwriting_form_code { get; set; }
        public Nullable<decimal> customer_id { get; set; }
        public string customer_code { get; set; }
        public string code { get; set; }
        public Nullable<decimal> currency_id { get; set; }
        public string currency_code { get; set; }
        public Nullable<decimal> policy_id { get; set; }
        public string policy_code { get; set; }
        public Nullable<System.DateTime> loss_date { get; set; }
        public Nullable<System.DateTime> report_date { get; set; }
        public string loss_description { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public System.DateTime created_date { get; set; }
        public decimal created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public Nullable<decimal> modified_by { get; set; }
        public Nullable<short> finance_year { get; set; }
        public decimal application_id { get; set; }
        public string application_code { get; set; }
        public Nullable<decimal> policy_system_type_id { get; set; }
        public Nullable<decimal> department_id { get; set; }
        public string class_code { get; set; }
        public Nullable<decimal> class_id { get; set; }
    }
}
