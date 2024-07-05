using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constract.Model
{
    public class report_general
    {
        public string thanght { get; set; }
        public string thangtruoc { get; set; }
        public string bhg_mt_nam { get; set; }
        public string bhg_lk_ht { get; set; }
        public string bhg_lk_namtruoc { get; set; }
        public string bhg_lk_tt { get; set; }
        public string bhg_lk_tlht { get; set; }
        public string dt_mt_thanght { get; set; }
        public string dt_thang_ht { get; set; }
        public string dt_thang_tlht { get; set; }
        public string dt_thang_namtruoc { get; set; }
        public string dt_thang_tt { get; set; }
        public string ln_lk_thanght { get; set; }
        public string ln_mt_nam { get; set; }
        public string ln_lk_tlht { get; set; }
        public string ln_lk_namtruoc { get; set; }
        public string ln_lk_tt { get; set; }
        public string tlbtgl_lk_namht { get; set; }
        public string tlbtgl_lk_namtruoc { get; set; }
        public string TLKH_LK_NamHT { get; set; }
        public string TLKHDNamTruoc { get; set; }
        public List<bhg_thang> bhg_thangs { get; set; }
        public List<bhg_nnv_lk> bhg_nnv_lks { get; set; }
        public List<tlbtgl_nnv_lk> tlbtgl_nnv_lks { get; set; }
    }
}
