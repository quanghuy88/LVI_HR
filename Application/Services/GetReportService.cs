using Constract.Model;
using Core.Entities;
using Injection;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository.Base.LVIDashboard;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Utility;

namespace Application.Services
{
    public class GetReportService : IGetReportService, IScopedInjection
    {
        private readonly ILVIDashboardRepository<dwh_fact_branch_cg_month> _bcgmRepo;
        private readonly ILVIDashboardRepository<dwh_fact_branch_cg_date> _bcgdRepo;
        private readonly ILVIDashboardRepository<dwh_acc_active_account_month> _aamRepo;
        private readonly ILVIDashboardRepository<dwh_revenue_profit_target> _rtRepo;
        private readonly ILVIDashboardRepository<dwh_list_branch> _branchRepo;
        private readonly ILVIDashboardRepository<dwh_acc_code_order> _acoRepo;
        private readonly ILVIDashboardRepository<dwh_acc_major_group> _amgRepo;
        public GetReportService(IServiceProvider serviceProvider)
        {
            _bcgmRepo = serviceProvider.GetService(_bcgmRepo);
            _bcgdRepo = serviceProvider.GetService(_bcgdRepo);
            _aamRepo = serviceProvider.GetService(_aamRepo);
            _rtRepo = serviceProvider.GetService(_rtRepo);
            _branchRepo = serviceProvider.GetService(_branchRepo);
            _acoRepo = serviceProvider.GetService(_acoRepo);
            _amgRepo = serviceProvider.GetService(_amgRepo);
        }
        public async Task<report_general> GetReportGeneral()
        {
            try
            {
                var lst_bhg_thang = new List<bhg_thang>();
                var lstBHG_NNV_LK = new List<bhg_nnv_lk>();
                var lstTLBTGL_NNV_LK = new List<tlbtgl_nnv_lk>();
                var vAAM = _aamRepo.AsActiveNoTracking().FirstOrDefault();
                var vlstClassGroup = _amgRepo.AsActiveNoTracking().ToList();
                //Ngày này nam truoc
                var ngaynay_namtruoc = int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() + vAAM.account_month_id.ToString().Substring(4, 2) + DateTime.Now.Day.ToString());
                //thang này nam truoc
                var thang_namtruoc = int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() + vAAM.account_month_id.ToString().Substring(4, 2));
                //thang truoc nam truoc
                var thangtruoc_namtruoc = int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() + (vAAM.account_month_id - 1).ToString().Substring(4, 2));

                //bhg thang
                var vLstBHG_Thang_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.next_month_id.ToString().Substring(0, 4) && s.code_order == "04")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_money = x.Sum(g => g.original_money)
                                                      }).ToList();
                var vLstBHG_Thang_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "04")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_money = x.Sum(g => g.original_money)
                                                      }).ToList();
                //boi thuong thang
                var vLstBT_Thang_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.next_month_id.ToString().Substring(0, 4) && s.code_order == "05")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToList();
                var vLstBT_Thang_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "05")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToList();
                //BHG NNV nam
                var vLstBHG_NNV_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Join(_amgRepo.AsActiveNoTracking(), bcgd => bcgd.class_group_code, amg => amg.code,
                                                    (bcgd, amg) => new {
                                                        class_group_code = bcgd.class_group_code,
                                                        cg_ename = amg.ename,
                                                        account_month = bcgd.account_month,
                                                        code_order = bcgd.code_order,
                                                        account_year = bcgd.account_year,
                                                        original_money = bcgd.original_money
                                                    })
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4) && s.code_order == "04")
                                              .GroupBy(s => new { s.class_group_code, s.cg_ename, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          class_group_code = x.Key.class_group_code,
                                                          cg_ename = x.Key.cg_ename,
                                                          total_money = x.Sum(g => g.original_money)
                                                      }).ToList();
                var vLstBHG_NNV_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                                              .Join(_amgRepo.AsActiveNoTracking(), bcgd => bcgd.class_group_code, amg => amg.code,
                                                    (bcgd, amg) => new {
                                                        class_group_code = bcgd.class_group_code,
                                                        cg_ename = amg.ename,
                                                        account_month = bcgd.account_month,
                                                        code_order = bcgd.code_order,
                                                        account_year = bcgd.account_year,
                                                        original_money = bcgd.original_money,
                                                        int_datadate = bcgd.int_datadate
                                                    })
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "04")
                                              .GroupBy(s => new { s.class_group_code, s.cg_ename, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          class_group_code = x.Key.class_group_code,
                                                          cg_ename = x.Key.cg_ename,
                                                          total_money = x.Sum(g => g.original_money)
                                                      }).ToList();
                //BHG NNV thang
                //var vLstBHG_NNV_thang_NamHT = _bcgdRepo.AsActiveNoTracking()
                //                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4) && s.code_order == "04")
                //                              .GroupBy(s => new { s.account_month, s.class_group_code, s.account_year })
                //                              .Select(x =>
                //                                      new {
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.original_money)
                //                                      }).ToList();
                //var vLstBHG_NNV_thang_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                //                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "04")
                //                              .GroupBy(s => new { s.account_month, s.class_group_code, s.account_year })
                //                              .Select(x =>
                //                                      new {
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.original_money)
                //                                      }).ToList();
                //Tổng BT NNV
                var vLstTongBT_NNV_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Join(_amgRepo.AsActiveNoTracking(), bcgd => bcgd.class_group_code, amg => amg.code,
                                                    (bcgd, amg) => new {
                                                        class_group_code = bcgd.class_group_code,
                                                        cg_ename = amg.ename,
                                                        account_month = bcgd.account_month,
                                                        code_order = bcgd.code_order,
                                                        account_year = bcgd.account_year,
                                                        original_money = bcgd.original_money,
                                                        int_datadate = bcgd.int_datadate
                                                    })
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4) && s.account_month < vAAM.account_month_id && s.code_order == "05")
                                              .GroupBy(s => new { s.class_group_code, s.cg_ename })
                                              .Select(x =>
                                                      new {
                                                          class_group_code = x.Key.class_group_code,
                                                          cg_ename = x.Key.cg_ename,
                                                          total_compensation = x.Sum(g => g.original_money),
                                                      }).ToList();
                var vLstTongBT_NNV_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                                              .Join(_amgRepo.AsActiveNoTracking(), bcgd => bcgd.class_group_code, amg => amg.code,
                                                    (bcgd, amg) => new {
                                                        class_group_code = bcgd.class_group_code,
                                                        cg_ename = amg.ename,
                                                        account_month = bcgd.account_month,
                                                        code_order = bcgd.code_order,
                                                        account_year = bcgd.account_year,
                                                        original_money = bcgd.original_money,
                                                        int_datadate = bcgd.int_datadate
                                                    })
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.account_month < thang_namtruoc && s.code_order == "05")
                                              .GroupBy(s => new { s.class_group_code, s.cg_ename })
                                              .Select(x =>
                                                      new {
                                                          class_group_code = x.Key.class_group_code,
                                                          cg_ename = x.Key.cg_ename,
                                                          total_compensation = x.Sum(g => g.original_money),
                                                      }).ToList();
                //TLBT NNV
                //var vLstTLBT_NNV_NamHT = _bcgdRepo.AsActiveNoTracking()
                //                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4) && s.account_month < vAAM.account_month_id && s.code_order == "04")
                //                              .GroupBy(s => new { s.account_month, s.class_group_code, s.account_year })
                //                              .Select(x =>
                //                                      new {
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_non_retention_conpensation = x.Sum(g => g.original_money),
                //                                      }).ToList();
                //var vLstTLBH_NNV_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                //                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.account_month < thang_namtruoc && s.code_order == "04")
                //                              .GroupBy(s => new { s.class_group_code })
                //                              .Select(x =>
                //                                      new {
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_non_retention_conpensation = x.Sum(g => g.original_money),
                //                                      }).ToList();
                var vLstBHG_MT = _rtRepo.AsActiveNoTracking()
                                 .Where(x => x.account_year == DateTime.Now.Year.ToString() && x.branch_id == 1 && x.class_group_code == "I")
                                 .ToList();

                //add data
                var vReportGeneral = new report_general();

                vReportGeneral.thanght = vAAM.next_month_id.ToString().Substring(4, 2);
                vReportGeneral.thangtruoc = (vAAM.next_month_id - 1).ToString().Substring(4, 2);
                //bhg lũy kế
                decimal bhg_MT_NamHT = vLstBHG_MT.FirstOrDefault(x => x.account_month == "All" && x.type_target == "revenue") == null ? 0 : vLstBHG_MT.FirstOrDefault(x => x.account_month == "All" && x.type_target == "revenue").target;
                vReportGeneral.bhg_lk_ht = ConvertNumToString.NumberToString(vLstBHG_Thang_NamHT.Sum(x => x.total_money));
                vReportGeneral.bhg_mt_nam = ConvertNumToString.NumberToString(bhg_MT_NamHT);
                vReportGeneral.bhg_lk_tlht = bhg_MT_NamHT == 0 ? "100%" : Math.Round(vLstBHG_Thang_NamHT.Sum(x => x.total_money) / bhg_MT_NamHT, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                vReportGeneral.bhg_lk_namtruoc = ConvertNumToString.NumberToString(vLstBHG_Thang_NamTruoc.Sum(x => x.total_money));
                vReportGeneral.bhg_lk_tt = Math.Round(((vLstBHG_Thang_NamHT.Sum(x => x.total_money) / vLstBHG_Thang_NamTruoc.Sum(x => x.total_money)) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                //DT tháng
                decimal bhg_MT_ThangHT = vLstBHG_MT.FirstOrDefault(x => x.account_month == vAAM.next_month_id.ToString() && x.type_target == "revenue") == null ? 0 : vLstBHG_MT.FirstOrDefault(x => x.account_month == vAAM.next_month_id.ToString() && x.type_target == "revenue").target;
                vReportGeneral.dt_mt_thanght = ConvertNumToString.NumberToString(bhg_MT_ThangHT);
                vReportGeneral.dt_thang_ht = ConvertNumToString.NumberToString(vLstBHG_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id).total_money);
                vReportGeneral.dt_thang_tlht = bhg_MT_ThangHT == 0 ? "100%" :
                                               Math.Round(vLstBHG_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id).total_money / bhg_MT_ThangHT, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                vReportGeneral.dt_thang_namtruoc = ConvertNumToString.NumberToString(vLstBHG_Thang_NamTruoc.FirstOrDefault(x => x.account_month == thang_namtruoc) == null ? 0 : 
                                                                                    vLstBHG_Thang_NamTruoc.FirstOrDefault(x => x.account_month == thang_namtruoc).total_money);
                vReportGeneral.dt_thang_tt = Math.Round(((vLstBHG_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id).total_money /
                                                        vLstBHG_Thang_NamTruoc.FirstOrDefault(x => x.account_month == thang_namtruoc).total_money) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                //loi nhuan luy ke
                decimal ln_MT_NamHT = vLstBHG_MT.FirstOrDefault(x => x.account_month == vAAM.account_month_id.ToString().Substring(0, 4) && x.type_target == "profit" && x.branch_id == 1 && x.class_group_code == "All") == null ? 0 :
                                      vLstBHG_MT.FirstOrDefault(x => x.account_month == vAAM.account_month_id.ToString().Substring(0, 4) && x.type_target == "profit" && x.branch_id == 1 && x.class_group_code == "All").target;
                vReportGeneral.ln_mt_nam = ConvertNumToString.NumberToString(ln_MT_NamHT);
                vReportGeneral.ln_lk_thanght = ConvertNumToString.NumberToString(vLstBHG_Thang_NamHT.Sum(x => x.total_money) - vLstBT_Thang_NamHT.Sum(x => x.total_compensation));
                vReportGeneral.ln_lk_tlht = ln_MT_NamHT == 0 ? "100%" : Math.Round(vLstBHG_Thang_NamHT.Sum(x => x.total_money) / ln_MT_NamHT, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                vReportGeneral.ln_lk_namtruoc = ConvertNumToString.NumberToString(vLstBHG_Thang_NamTruoc.Sum(x => x.total_money));
                vReportGeneral.ln_lk_tt = Math.Round(((vLstBHG_Thang_NamHT.Sum(x => x.total_money) / vLstBHG_Thang_NamTruoc.Sum(x => x.total_money)) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();

                //Ds tháng
                
                //bhg các tháng
                for (int i = 0; i < vLstBHG_Thang_NamHT.Count(); i++)
                {
                    for (int j = 0; j < vLstBHG_Thang_NamTruoc.Count(); j++)
                    {
                        if (vLstBHG_Thang_NamHT[i].account_month.ToString().Substring(4, 2) == vLstBHG_Thang_NamTruoc[j].account_month.ToString().Substring(4, 2))
                        {
                            var vData = new bhg_thang();
                            vData.thang = vLstBHG_Thang_NamHT[i].account_month.ToString().Substring(4, 2);
                            vData.nam_ht = vLstBHG_Thang_NamHT[i].account_month.ToString().Substring(0, 4);
                            vData.bhg_thang_namht = ConvertNumToString.ShortenNumberBillion(vLstBHG_Thang_NamHT[i].total_money);
                            vData.bhg_thang_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_Thang_NamTruoc[j].total_money);
                            vData.bhg_thang_namht_format = ConvertNumToString.NumberToStringFormat(vLstBHG_Thang_NamHT[i].total_money) + " LAK";
                            vData.bhg_thang_namtruoc_format = ConvertNumToString.NumberToStringFormat(vLstBHG_Thang_NamTruoc[j].total_money) + " LAK";
                            if (vLstBHG_Thang_NamTruoc[j].total_money > 0)
                            {
                                vData.bhg_thang_tangtruong = Math.Round(((vLstBHG_Thang_NamHT[i].total_money / vLstBHG_Thang_NamTruoc[j].total_money) - 1) * 10, 2, MidpointRounding.AwayFromZero).ToString();
                            } else {
                                vData.bhg_thang_tangtruong = "100";
                            }
                            //vData.bhg_thang_tangtruong = vLstBHG_Thang_NamHT[i].total_money > 0 && vLstBHG_Thang_NamTruoc[j].total_money > 0 && vLstBHG_Thang_NamHT[i].total_money > vLstBHG_Thang_NamTruoc[j].total_money  ? Math.Round(((vLstBHG_Thang_NamHT[i].total_money / vLstBHG_Thang_NamTruoc[j].total_money) - 1) * 10, 2, MidpointRounding.AwayFromZero).ToString() : "0";
                            lst_bhg_thang.Add(vData);
                            break;
                        }
                    }
                }
                //bhg nhóm nv các lũy kế
                for (int i = 0; i < vLstBHG_NNV_NamHT.Count(); i++)
                {
                    for (int j = 0; j < vLstBHG_NNV_NamTruoc.Count(); j++)
                    {
                        if (vLstBHG_NNV_NamHT[i].class_group_code == vLstBHG_NNV_NamTruoc[j].class_group_code)
                        {
                            var vData = new bhg_nnv_lk();
                            vData.nhomnghiepvu = vLstBHG_NNV_NamHT[i].cg_ename;
                            vData.bhg_nnv_lk_namht = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_NamHT[i].total_money);
                            vData.bhg_nnv_lk_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_NamTruoc[j].total_money);
                            vData.bhg_nnv_lk_namht_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NNV_NamHT[i].total_money) + " LAK";
                            vData.bhg_nnv_lk_namtruoc_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NNV_NamTruoc[j].total_money) + " LAK";
                            if (vLstBHG_NNV_NamTruoc[j].total_money > 0)
                            {
                                vData.bhg_nnv_lk_tt = Math.Round(((vLstBHG_NNV_NamHT[i].total_money / vLstBHG_NNV_NamTruoc[j].total_money) - 1) * 10, 2, MidpointRounding.AwayFromZero).ToString();
                            }
                            else
                            {
                                vData.bhg_nnv_lk_tt = "100";
                            }
                            //vData.bhg_nnv_lk_tt = Math.Round(((vLstBHG_NNV_NamHT[i].total_money / vLstBHG_NNV_NamTruoc[j].total_money) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                            lstBHG_NNV_LK.Add(vData);
                            break;
                        }
                    }
                }
                for (int i = 0; i < vlstClassGroup.Count(); i++)
                {

                    var tongbt_nnv_ht = vLstTongBT_NNV_NamHT.FirstOrDefault(x => x.class_group_code == vlstClassGroup[i].code)?.total_compensation ?? 0;
                    var tongbt_nnv_namtruoc = vLstTongBT_NNV_NamTruoc.FirstOrDefault(x => x.class_group_code == vlstClassGroup[i].code)?.total_compensation ?? 0;
                    var bhg_nnv_namht = vLstBHG_NNV_NamHT.FirstOrDefault(x => x.class_group_code == vlstClassGroup[i].code)?.total_money ?? 1;
                    var bhg_nnv_namtruoc = vLstBHG_NNV_NamTruoc.FirstOrDefault(x => x.class_group_code == vlstClassGroup[i].code)?.total_money ?? 1;
                    if (tongbt_nnv_ht != 0 || tongbt_nnv_namtruoc != 0) 
                    {
                        var vData1 = new tlbtgl_nnv_lk();
                        vData1.nhomnghiepvu = vlstClassGroup[i].ename;
                        vData1.tbltgl_nnv_lk_namht = Math.Round(tongbt_nnv_ht * 100 / bhg_nnv_namht, 2, MidpointRounding.AwayFromZero).ToString();
                        vData1.tbltgl_nnv_lk_namtruoc = Math.Round(tongbt_nnv_namtruoc * 100 / bhg_nnv_namtruoc, 2, MidpointRounding.AwayFromZero).ToString();
                        lstTLBTGL_NNV_LK.Add(vData1);
                    }
                }
                //for (int i = 0; i < vLstTongBT_NNV_NamHT.Count(); i++)
                //{
                //    for (int j = 0; j < vLstTongBT_NNV_NamTruoc.Count(); j++)
                //    {
                //        if (vLstTongBT_NNV_NamHT[i].class_group_code == vLstTongBT_NNV_NamTruoc[j].class_group_code)
                //        {
                //            var btgl_namht = vLstTongBT_NNV_NamHT[i].total_compensation;
                //            var btgl_namtruoc = vLstTongBT_NNV_NamTruoc[j].total_compensation;
                //            var vData1 = new tlbtgl_nnv_lk();
                //            vData1.nhomnghiepvu = vLstTongBT_NNV_NamHT[i].cg_ename;
                //            vData1.tbltgl_nnv_lk_namht = Math.Round(btgl_namht * 100 / vLstBHG_NNV_NamHT.FirstOrDefault(x => x.class_group_code == vLstTongBT_NNV_NamHT[i].class_group_code).total_money, 2, MidpointRounding.AwayFromZero).ToString();
                //            vData1.tbltgl_nnv_lk_namtruoc = Math.Round(btgl_namtruoc * 100 / vLstBHG_NNV_NamTruoc.FirstOrDefault(x => x.class_group_code == vLstTongBT_NNV_NamHT[i].class_group_code).total_money, 2, MidpointRounding.AwayFromZero).ToString();
                //            lstTLBTGL_NNV_LK.Add(vData1);
                //            break;
                //        }
                //    }
                //}
                vReportGeneral.bhg_thangs = lst_bhg_thang;
                vReportGeneral.bhg_nnv_lks = lstBHG_NNV_LK;
                vReportGeneral.tlbtgl_nnv_lks = lstTLBTGL_NNV_LK;
                return vReportGeneral;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        public async Task<report_class_group> GetReportClassGroup(string class_group_code)
        {
            try
            {
                if (class_group_code.IsNullOrEmpty())
                {
                    return null;
                }
                var lstrcg_bhg_nnv_ngay = new List<rcg_bhg_nnv_ngay>();
                var lstrcg_bhg_nnv_thang = new List<rcg_bhg_nnv_thang>();
                var lstrcg_bhg_tlht = new List<rcg_bhg_tlht>();
                var vAAM = _aamRepo.AsActiveNoTracking().FirstOrDefault();

                //Ngày này nam truoc
                var ngaynay_namtruoc = int.Parse(int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(1, 4)) - 1).ToString() + vAAM.account_month_id.ToString().Substring(5, 2)) + (DateTime.Now.Day - 1).ToString());
                //thang này nam truoc
                var thang_namtruoc = int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(1, 4)) - 1).ToString() + vAAM.account_month_id.ToString().Substring(5, 2));
                //thang truoc nam truoc
                var thangtruoc_namtruoc = int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(1, 4)) - 1).ToString() + (vAAM.account_month_id - 1).ToString().Substring(5, 2));

                ////BHG NNV thang
                //var vLstBHG_NNV_Thang_NamHT = _bcgmRepo.AsActiveNoTracking()
                //                              .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) && s.class_group_code == class_group_code)
                //                              .GroupBy(s => new { s.account_month, s.class_group_code, s.account_year })
                //                              .Select(x =>
                //                                      new {
                //                                          account_month = x.Key.account_month,
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.exchange_revenue_money),
                //                                          total_non_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                                          total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                                      }).ToList();
                //var vLstBHG_NNV_Thang_NamTruoc = _bcgmRepo.AsActiveNoTracking()
                //                              .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) - 1 && s.int_datadate <= ngaynay_namtruoc)
                //                              .GroupBy(s => new { s.class_group_code, s.account_month, s.account_year })
                //                              .Select(x =>
                //                                      new {
                //                                          account_month = x.Key.account_month,
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.exchange_revenue_money),
                //                                          total_non_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                                          total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                                      }).ToList();
                ////tlht lk theo chi nhanh
                //var vLstBHG_NNV_Ngay_NamHT = _bcgmRepo.AsActiveNoTracking()
                //                              .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4))
                //                                     && s.class_group_code == class_group_code)
                //                              .GroupBy(s => new { s.class_group_code, s.account_year, s.branch_id })
                //                              .Select(x =>
                //                                      new {
                //                                          branch_id = x.Key.branch_id,
                //                                          account_year = x.Key.account_year,
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.exchange_revenue_money),
                //                                          total_non_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                                          total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                                      }).ToList();

                //BHG NNV thang
                var vLstBHG_NNV_Thang_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) && s.class_group_code == class_group_code && s.code_order == "04")
                                              .GroupBy(s => new { s.account_month, s.class_group_code, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          class_group_code = x.Key.class_group_code,
                                                          total_money = x.Sum(g => g.original_money),
                                                      }).ToList();
                var vLstBHG_NNV_Thang_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) - 1 && s.int_datadate <= ngaynay_namtruoc && s.code_order == "04")
                                              .GroupBy(s => new { s.class_group_code, s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          class_group_code = x.Key.class_group_code,
                                                          total_money = x.Sum(g => g.original_money),
                                                      }).ToList();
                //boi thuong nnv thang
                var vLstBT_NNV_Thang_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.next_month_id.ToString().Substring(0, 4) && s.code_order == "05")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToList();
                var vLstBT_NNV_Thang_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "05")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToList();
                //tlht lk theo chi nhanh
                var vLstBHG_NNV_Ngay_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4))
                                                     && s.class_group_code == class_group_code && s.code_order == "04")
                                              .GroupBy(s => new { s.class_group_code, s.account_year, s.branch_id })
                                              .Select(x =>
                                                      new {
                                                          branch_id = x.Key.branch_id,
                                                          account_year = x.Key.account_year,
                                                          class_group_code = x.Key.class_group_code,
                                                          total_money = x.Sum(g => g.original_money),
                                                      }).ToList();

                //lst muc tieu 
                var vLstBHG_MT = _rtRepo.AsActiveNoTracking()
                                 .Join(_branchRepo.AsActiveNoTracking(),
                                       _rtRepo => _rtRepo.branch_id,
                                       _branchRepo => _branchRepo.id,
                                       (_rtRepo, _branchRepo) => new { rt = _rtRepo, branch = _branchRepo })
                                 .Where(x => x.rt.account_year == DateTime.Now.Year.ToString() && x.rt.class_group_code == class_group_code)
                                 .ToList();

                //insert du lieu report
                var vrcg = new report_class_group();
                vrcg.bhg_thang_ht = vLstBHG_NNV_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id).total_money.ToString();
                vrcg.bhg_thang_muctieu = vLstBHG_MT.FirstOrDefault(x => x.rt.account_month == vAAM.account_month_id.ToString() && x.rt.type_target == "revenue").rt.target_name;
                vrcg.bhg_thang_tlht = Math.Round(vLstBHG_NNV_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id).total_money * 100 /
                                      vLstBHG_MT.FirstOrDefault(x => x.rt.account_month == vAAM.account_month_id.ToString()).rt.target, 2).ToString() + "%";
                //bhg luy ke
                vrcg.bhg_lk_ht = vLstBHG_NNV_Thang_NamHT.Sum(x => x.total_money).ToString();
                vrcg.bhg_lk_muctieu = vLstBHG_MT.FirstOrDefault(x => x.rt.account_month == "All" && x.rt.type_target == "revenue").rt.target_name;
                vrcg.bhg_lk_tlht = Math.Round(vLstBHG_NNV_Thang_NamHT.Sum(x => x.total_money) * 100 / vLstBHG_MT.FirstOrDefault(x => x.rt.account_month == "All" && x.rt.type_target == "revenue").rt.target).ToString();
                vrcg.bhg_lk_phankhai = "";
                vrcg.bhg_lk_tangtruong = Math.Round((vLstBHG_NNV_Thang_NamHT.Sum(x => x.total_money) / vLstBHG_NNV_Thang_NamTruoc.Sum(x => x.total_money) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                //tlbtgl
                vrcg.tlbtgl_ht = Math.Round(vLstBT_NNV_Thang_NamHT.Sum(x => x.total_compensation) / vLstBHG_NNV_Thang_NamHT.Sum(x => x.total_money), 2).ToString() + "%";
                vrcg.tlbtgl_namtruoc = (vLstBT_NNV_Thang_NamTruoc.Sum(x => x.total_compensation) / vLstBHG_NNV_Thang_NamTruoc.Sum(x => x.total_money)).ToString() + "%";

                //list bhg nnv theo thang
                for (int i = 0; i < vLstBHG_NNV_Thang_NamHT.Count(); i++)
                {
                    for (int j = 0; j < vLstBHG_NNV_Thang_NamTruoc.Count(); j++)
                    {
                        if (vLstBHG_NNV_Thang_NamHT[i].account_month.ToString().Substring(4, 2) == vLstBHG_NNV_Thang_NamTruoc[j].account_month.ToString().Substring(4, 2))
                        {
                            var vData = new rcg_bhg_nnv_thang();
                            vData.thang = vLstBHG_NNV_Thang_NamHT[i].account_month.ToString().Substring(4, 2);
                            vData.bhg_nnv_thang_namht = vLstBHG_NNV_Thang_NamHT[i].account_month.ToString().Substring(0, 4);
                            vData.bhg_nnv_thang_namtruoc = vLstBHG_NNV_Thang_NamTruoc[i].total_money.ToString();
                            vData.bhg_nnv_tangtruong = Math.Round(((vLstBHG_NNV_Thang_NamHT[j].total_money / vLstBHG_NNV_Thang_NamTruoc[i].total_money) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                            lstrcg_bhg_nnv_thang.Add(vData);
                            break;
                        }
                    }
                }
                //list bhg nnv theo ngay
                for (int i = 0; i < vLstBHG_NNV_Ngay_NamHT.Count(); i++)
                {
                    var vData = new rcg_bhg_nnv_ngay();
                    vData.ngay = vLstBHG_NNV_Thang_NamHT[i].account_month.ToString().Substring(4, 2);
                    vData.bhg_nnv_ngay = vLstBHG_NNV_Thang_NamTruoc[i].total_money.ToString();
                    lstrcg_bhg_nnv_ngay.Add(vData);
                    break;
                }

                //list bhg nnv theo ngay
                for (int i = 0; i < vLstBHG_NNV_Ngay_NamHT.Count(); i++)
                {
                    var vData = new rcg_bhg_nnv_ngay();
                    vData.ngay = vLstBHG_NNV_Thang_NamHT[i].account_month.ToString().Substring(4, 2);
                    vData.bhg_nnv_ngay = vLstBHG_NNV_Thang_NamTruoc[i].total_money.ToString();
                    lstrcg_bhg_nnv_ngay.Add(vData);
                    break;
                }

                //list bhg nnv theo ngay
                for (int i = 0; i < vLstBHG_NNV_Ngay_NamHT.Count(); i++)
                {
                    var vData = new rcg_bhg_nnv_ngay();
                    vData.ngay = vLstBHG_NNV_Thang_NamHT[i].account_month.ToString().Substring(4, 2);
                    vData.bhg_nnv_ngay = vLstBHG_NNV_Thang_NamTruoc[i].total_money.ToString();
                    lstrcg_bhg_nnv_ngay.Add(vData);
                    break;
                }

                //list bhg tlht
                for (int i = 0; i < vLstBHG_NNV_Ngay_NamHT.Count(); i++)
                {
                    for (int j = 0; j < vLstBHG_MT.Count(); j++)
                    {
                        if (vLstBHG_NNV_Ngay_NamHT[i].branch_id == vLstBHG_MT[j].rt.branch_id)
                        {
                            var vData = new rcg_bhg_tlht();
                            vData.branch_name = vLstBHG_MT[i].branch.name;
                            vData.bhg_tlht = Math.Round(vLstBHG_NNV_Ngay_NamHT[i].total_money * 100 / vLstBHG_MT[j].rt.target).ToString();
                            lstrcg_bhg_tlht.Add(vData);
                            break;
                        }
                    }
                }
                return vrcg;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<report_branch> GetReportBranch(int branch_id)
        {
            try
            {
                if (branch_id <= 0)
                {
                    return null;
                }
                var lst_bhg_nnv_cn = new List<rb_bhg_nvv_cn>();
                var lstrb_tlbtgl_nnv_thang = new List<rb_tlbtgl_nnv_thang>();
                var vAAM = _aamRepo.AsActiveNoTracking().FirstOrDefault();

                //Ngày này nam truoc
                var ngaynay_namtruoc = int.Parse(int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(1, 4)) - 1).ToString() + vAAM.account_month_id.ToString().Substring(5, 2)) + (DateTime.Now.Day).ToString());
                //thang này nam truoc
                var thang_namtruoc = int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(1, 4)) - 1).ToString() + vAAM.account_month_id.ToString().Substring(5, 2));
                //thang truoc nam truoc
                var thangtruoc_namtruoc = int.Parse((int.Parse(vAAM.next_month_id.ToString().Substring(1, 4)) - 1).ToString() + (vAAM.account_month_id - 1).ToString().Substring(5, 2));

                //lst muc tieu 
                var vLstBHG_MT = _rtRepo.AsActiveNoTracking()
                                 .Join(_branchRepo.AsActiveNoTracking(),
                                       _rtRepo => _rtRepo.branch_id,
                                       _branchRepo => _branchRepo.id,
                                       (_rtRepo, _branchRepo) => new { rt = _rtRepo, branch = _branchRepo })
                                 .Where(x => x.rt.account_year == DateTime.Now.Year.ToString() && x.rt.branch_id == branch_id)
                                 .ToList();

                ////BHG NNV thang
                //var vLstBHG_NNV_Thang_NamHT = _bcgmRepo.AsActiveNoTracking()
                //                              .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) && s.class_group_code == class_group_code)
                //                              .GroupBy(s => new { s.account_month, s.class_group_code, s.account_year })
                //                              .Select(x =>
                //                                      new {
                //                                          account_month = x.Key.account_month,
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.exchange_revenue_money),
                //                                          total_non_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                                          total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                                      }).ToList();
                //var vLstBHG_NNV_Thang_NamTruoc = _bcgmRepo.AsActiveNoTracking()
                //                              .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) - 1 && s.int_datadate <= ngaynay_namtruoc)
                //                              .GroupBy(s => new { s.class_group_code, s.account_month, s.account_year })
                //                              .Select(x =>
                //                                      new {
                //                                          account_month = x.Key.account_month,
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.exchange_revenue_money),
                //                                          total_non_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                                          total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                                      }).ToList();
                ////bhg chi nhanh theo thang
                //var vLstBHG_CN_Thang_NamHT = _bcgRepo.AsActiveNoTracking()
                //                              .Where(s => s.branch_id == branch_id && s.account_month == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)))
                //                              .GroupBy(s => new { s.account_year, s.branch_id, s.class_group_code, s.account_month })
                //                              .Select(x =>
                //                                      new {
                //                                          branch_id = x.Key.branch_id,
                //                                          account_month = x.Key.account_month,
                //                                          account_year = x.Key.account_year,
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.exchange_revenue_money),
                //                                          total_non_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                                          total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                                      }).ToList();
                //var vLstBHG_CN_Thang_NamTruoc = _bcgmRepo.AsActiveNoTracking()
                //                              .Where(s => s.branch_id == branch_id && s.account_month == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) - 1)
                //                              .GroupBy(s => new { s.account_year, s.branch_id, s.class_group_code, s.account_month })
                //                              .Select(x =>
                //                                      new {
                //                                          branch_id = x.Key.branch_id,
                //                                          account_month = x.Key.account_month,
                //                                          account_year = x.Key.account_year,
                //                                          class_group_code = x.Key.class_group_code,
                //                                          total_money = x.Sum(g => g.exchange_revenue_money),
                //                                          total_non_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                                          total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                                      }).ToList();
                ////bhg theo nnv luy ke
                //var vLstBHG_NNV_CN_NamHT = _bcgmRepo.AsActiveNoTracking()
                //                  .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4))
                //                         && s.branch_id == branch_id)
                //                  .GroupBy(s => new { s.class_group_code, s.account_year, s.branch_id })
                //                  .Select(x =>
                //                          new {
                //                              branch_id = x.Key.branch_id,
                //                              account_year = x.Key.account_year,
                //                              class_group_code = x.Key.class_group_code,
                //                              total_money = x.Sum(g => g.exchange_revenue_money),
                //                              total_non_retention_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                              total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                          }).ToList();
                //var vLstBHG_NNV_CN_Namtruoc = _bcgmRepo.AsActiveNoTracking()
                //                  .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4))
                //                         && s.branch_id == branch_id && s.int_datadate < ngaynay_namtruoc)
                //                  .GroupBy(s => new { s.class_group_code, s.account_year, s.branch_id })
                //                  .Select(x =>
                //                          new {
                //                              branch_id = x.Key.branch_id,
                //                              account_year = x.Key.account_year,
                //                              class_group_code = x.Key.class_group_code,
                //                              total_money = x.Sum(g => g.exchange_revenue_money),
                //                              total_non_retention_conpensation = x.Sum(g => g.exchange_non_retention_compensation_money),
                //                              total_conpensation = x.Sum(g => g.exchange_total_compensation_money)
                //                          }).ToList();
                //bhg chi nhanh theo thang
                var vLstBHG_CN_Thang_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.branch_id == branch_id && s.account_month == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)))
                                              .GroupBy(s => new { s.account_year, s.branch_id, s.account_month })
                                              .Select(x =>
                                                      new {
                                                          branch_id = x.Key.branch_id,
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_money = x.Sum(g => g.original_money),
                                                      }).ToList();
                var vLstBHG_CN_Thang_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.branch_id == branch_id && s.account_month == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) - 1)
                                              .GroupBy(s => new { s.account_year, s.branch_id, s.account_month })
                                              .Select(x =>
                                                      new {
                                                          branch_id = x.Key.branch_id,
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_money = x.Sum(g => g.original_money),
                                                      }).ToList();
                //boi thuong chi nhanh lk
                var vLstBT_CN_Thang_NamHT = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.next_month_id.ToString().Substring(0, 4) && s.code_order == "05")
                                              .GroupBy(s => new { s.account_month, s.account_year, s.branch_id })
                                              .Select(x =>
                                                      new {
                                                          branch_id = x.Key.branch_id,
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToList();
                var vLstBT_CN_Thang_NamTruoc = _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "05")
                                              .GroupBy(s => new { s.account_month, s.account_year, s.branch_id })
                                              .Select(x =>
                                                      new {
                                                          branch_id = x.Key.branch_id,
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToList();
                //bhg theo nnv luy ke
                var vLstBHG_NNV_CN_NamHT = _bcgdRepo.AsActiveNoTracking()
                                  .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4))
                                         && s.branch_id == branch_id)
                                  .GroupBy(s => new { s.class_group_code, s.account_year, s.branch_id })
                                  .Select(x =>
                                          new {
                                              branch_id = x.Key.branch_id,
                                              account_year = x.Key.account_year,
                                              class_group_code = x.Key.class_group_code,
                                              total_money = x.Sum(g => g.original_money),
                                          }).ToList();
                var vLstBHG_NNV_CN_Namtruoc = _bcgdRepo.AsActiveNoTracking()
                                  .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4))
                                         && s.branch_id == branch_id && s.int_datadate < ngaynay_namtruoc)
                                  .GroupBy(s => new { s.class_group_code, s.account_year, s.branch_id })
                                  .Select(x =>
                                          new {
                                              branch_id = x.Key.branch_id,
                                              account_year = x.Key.account_year,
                                              class_group_code = x.Key.class_group_code,
                                              total_money = x.Sum(g => g.original_money),
                                          }).ToList();
                var vrb = new report_branch();
                vrb.dt_lk = vLstBHG_CN_Thang_NamHT.Sum(x => x.total_money).ToString();
                vrb.dt_muctieu = vLstBHG_MT.FirstOrDefault(x => x.rt.account_month == "All" && x.rt.type_target == "revenue").rt.target_name;
                vrb.dt_tlht = Math.Round(vLstBHG_CN_Thang_NamHT.Sum(x => x.total_money) * 100 / vLstBHG_MT.FirstOrDefault(x => x.rt.account_month == "All" && x.rt.type_target == "revenue").rt.target).ToString() + "%";
                vrb.dt_tlht_phankhai = "";
                vrb.tlbhgl_namht = Math.Round(vLstBT_CN_Thang_NamHT.Sum(x => x.total_compensation) * 100 / vLstBHG_CN_Thang_NamHT.Sum(x => x.total_money),2, MidpointRounding.AwayFromZero).ToString() + "%";
                vrb.tlbhgl_namtruoc = Math.Round(vLstBT_CN_Thang_NamHT.Sum(x => x.total_compensation) * 100 / vLstBHG_CN_Thang_NamTruoc.Sum(x => x.total_money), 2, MidpointRounding.AwayFromZero).ToString() + "%";

                for (int i = 0; i < vLstBHG_CN_Thang_NamHT.Count(); i++)
                {
                    for (int j = 0; j < vLstBHG_CN_Thang_NamTruoc.Count(); j++)
                    {
                        if (vLstBHG_CN_Thang_NamHT[i].account_month.ToString().Substring(5, 2) == vLstBHG_CN_Thang_NamTruoc[j].account_month.ToString().Substring(5, 2))
                        {
                            var bhg_cn_thang_muctieu = vLstBHG_MT.FirstOrDefault(x => x.rt.account_month.ToString() == vLstBHG_CN_Thang_NamHT[i].account_month.ToString().Substring(5, 2)).rt.target;
                            var vData = new rb_bhg_cn_thang();
                            vData.thang = vLstBHG_CN_Thang_NamHT[i].account_month.ToString().Substring(5, 2);
                            vData.bhg_cn_thang_namht = vLstBHG_CN_Thang_NamHT[i].total_money.ToString();
                            vData.bhg_cn_thang_namtruoc = vLstBHG_CN_Thang_NamTruoc[j].total_money.ToString();
                            vData.bhg_cn_thang_muctieu = bhg_cn_thang_muctieu.ToString();
                            vData.bhg_cn_thang_tangtruong = Math.Round(vLstBHG_CN_Thang_NamHT[i].total_money * 100 / bhg_cn_thang_muctieu, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                            break;
                        }

                    }
                }
                for (int i = 0; i < vLstBHG_CN_Thang_NamHT.Count(); i++)
                {
                    for (int j = 0; j < vLstBT_CN_Thang_NamHT.Count(); j++)
                    {
                        if (vLstBHG_CN_Thang_NamHT[i].branch_id == vLstBT_CN_Thang_NamHT[j].branch_id && vLstBHG_CN_Thang_NamHT[i].account_month == vLstBT_CN_Thang_NamHT[j].account_month)
                        {
                            var vData1 = new rb_tlbtgl_nnv_thang();
                            vData1.thang = vLstBHG_CN_Thang_NamHT[i].account_month.ToString().Substring(5, 2);
                            vData1.tlbtgl = Math.Round((vLstBT_CN_Thang_NamHT[j].total_compensation * 100 / vLstBHG_CN_Thang_NamHT[i].total_money),2, MidpointRounding.AwayFromZero).ToString() + "%";
                        }
                    }
                    
                }

                for (int i = 0; i < vLstBHG_NNV_CN_NamHT.Count(); i++)
                {
                    for (int j = 0; j < vLstBHG_NNV_CN_Namtruoc.Count(); j++)
                    {
                        if (vLstBHG_NNV_CN_NamHT[i].class_group_code.ToString() == vLstBHG_NNV_CN_Namtruoc[j].class_group_code.ToString())
                        {
                            var bhg_cn_thang_muctieu = vLstBHG_MT.FirstOrDefault(x => x.rt.account_month.ToString() == vLstBHG_CN_Thang_NamHT[i].account_month.ToString().Substring(5, 2)).rt.target;
                            var vData = new rb_bhg_nvv_cn();
                            vData.nnv_ten = vLstBHG_NNV_CN_NamHT[i].class_group_code.ToString().Substring(5, 2);
                            vData.bhg_nnv_namht = vLstBHG_NNV_CN_NamHT[i].total_money.ToString();
                            vData.bhg_nvv_namtruoc = vLstBHG_NNV_CN_Namtruoc[j].total_money.ToString();
                            vData.bhg_nnv_tangtruong = Math.Round(vLstBHG_NNV_CN_NamHT[i].total_money * 100 / vLstBHG_NNV_CN_Namtruoc[j].total_money, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                            break;
                        }

                    }
                }

                return vrb;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        
    }
}
