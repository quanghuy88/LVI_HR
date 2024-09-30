using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constract.Model
{
    public class report_branch
    {
        public string thang_ht { get; set; }
        public string thangtruoc { get; set; }
        public string branch_name { get; set; }
        public string dtcn_lk_namht { get; set; }
        public string dtcn_muctieu { get; set; }
        public string dtcn_tlht { get; set; }
        public string dtcn_lk_namtruoc { get; set; }
        public string dtcn_lk_tt { get; set; }
        public string tlbtgl_namht { get; set; }
        public string tlbtgl_namtruoc { get; set; }
        public List<rb_bhg_cn_thang> rb_bhg_cn_thangs { get; set; }
        public List<rb_bhg_cn_ngay> rb_bhg_cn_ngays { get; set; }
        public List<rb_bhg_nnv_cn> rb_bhg_nnv_cns { get; set; }
        public List<rb_tlbtgl_nnv> rb_tlbtgl_nnvs { get; set; }
    }
}
