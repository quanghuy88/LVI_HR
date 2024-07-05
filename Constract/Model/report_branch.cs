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
        public string dt_lk { get; set; }
        public string dt_muctieu { get; set; }
        public string dt_tlht { get; set; }
        public string dt_tlht_phankhai { get; set; }
        public string tlbhgl_namht { get; set; }
        public string tlbhgl_namtruoc { get; set; }
        public List<rb_bhg_cn_thang> rb_bhg_cn_thangs { get; set; }
        public List<rb_bhg_nvv_cn> rb_bhg_nvv_cns { get; set; }
        public List<rb_tlbtgl_nnv_thang> rb_tlbtgl_nnv_thangs { get; set; }
    }
}
