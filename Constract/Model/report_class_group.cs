using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constract.Model
{
    public class report_class_group
    {
        public string class_group_name { get; set; }
        public string thanght { get; set; }
        public string thanght_namtruoc { get; set; }
        public string thangtruoc_ht {  get; set; }
        public string thangtruoc_namtruoc { get; set; }
        public string bhg_thanght { get; set; }
        public string bhg_thanght_namtruoc { get; set; }
        public string bhg_thang_muctieu { get; set; }
        public string bhg_thang_tlht { get; set; }
        public string bhg_thanght_tt { get; set; }
        public string bhg_lk_ht { get; set; }
        public string bhg_lk_muctieu { get; set; }
        public string bhg_lk_tlht { get; set; }
        public string bhg_lk_namtruoc { get; set; }
        public string bhg_lk_tangtruong { get; set; }
        public string tlbtgl_ht { get; set; }
        public string tlbtgl_namtruoc { get; set; }
        public List<rcg_bhg_nnv_thang> rcg_bhg_nnv_thangs { get; set; }
        public List<rcg_bhg_nnv_ngay> rcg_bhg_nnv_ngays { get; set; }
        public List<rcg_bhg_nv_lk> rcg_bhg_nv_lks { get; set; }
        public List<rcg_tlbtgl> rcg_tlbtgls { get; set; }
    }
}
