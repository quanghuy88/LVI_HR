using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_code_order
    {
        public decimal? id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public int? sequence { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
    }
}
