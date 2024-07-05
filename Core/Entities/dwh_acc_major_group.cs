using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_major_group
    {
        public int id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? ename { get; set; }
        public string? sub_name { get; set; }
        public string? sub_ename { get; set; }
        public string? sub_class_code { get; set; }
        public string? represent_class_code { get; set; }
    }
}
