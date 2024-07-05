using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_list_auto_posting_code
    {
        public int? id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? system_code { get; set; }
        public string? string_check_sql { get; set; }
        public string? string_insert_sql { get; set; }
        public string? note { get; set; }
        public int? sequence { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
    }
}
