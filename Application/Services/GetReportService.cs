﻿using Constract.Model;
using Core.Entities;
using Injection;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILVIDashboardRepository<dwh_fact_branch_class_date> _bcdRepo;
        private readonly ILVIDashboardRepository<dwh_acc_active_account_month> _aamRepo;
        private readonly ILVIDashboardRepository<dwh_revenue_profit_target> _rtRepo;
        private readonly ILVIDashboardRepository<dwh_list_branch> _branchRepo;
        private readonly ILVIDashboardRepository<dwh_acc_code_order> _acoRepo;
        private readonly ILVIDashboardRepository<dwh_acc_major_group> _amgRepo;
        private readonly ILVIDashboardRepository<dwh_list_insurance_product> _lipRepo;
        public GetReportService(IServiceProvider serviceProvider)
        {
            _bcgmRepo = serviceProvider.GetService(_bcgmRepo);
            _bcgdRepo = serviceProvider.GetService(_bcgdRepo);
            _bcdRepo = serviceProvider.GetService(_bcdRepo);
            _aamRepo = serviceProvider.GetService(_aamRepo);
            _rtRepo = serviceProvider.GetService(_rtRepo);
            _branchRepo = serviceProvider.GetService(_branchRepo);
            _acoRepo = serviceProvider.GetService(_acoRepo);
            _amgRepo = serviceProvider.GetService(_amgRepo);
            _lipRepo = serviceProvider.GetService(_lipRepo);
        }
        public async Task<report_general> GetReportGeneral()
        {
            try
            {
                var lst_bhg_thang = new List<bhg_thang>();
                var lstBHG_NNV_LK = new List<bhg_nnv_lk>();
                var lstTLBTGL_NNV_LK = new List<tlbtgl_nnv_lk>();
                var vAAM = await _aamRepo.AsActiveNoTracking().FirstOrDefaultAsync();
                var vlstClassGroup = await _amgRepo.AsActiveNoTracking().ToListAsync();

                //Ngày này nam truoc
                var ngaynay_namtruoc = int.Parse((vAAM.next_month_id - 100).ToString() + (DateTime.Now.Day - 1).ToString());
                //thang này nam truoc
                var thang_namtruoc = vAAM.next_month_id - 100;
                //thang truoc nam truoc
                var thangtruoc_namtruoc = vAAM.next_month_id - 101;

                //bhg thang
                var vLstBHG_Thang_NamHT = await _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.next_month_id.ToString().Substring(0, 4) && s.code_order == "04")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_money = x.Sum(g => g.original_money)
                                                      }).ToListAsync();
                var vLstBHG_Thang_NamTruoc = await _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "04")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_money = x.Sum(g => g.original_money)
                                                      }).ToListAsync();
                //boi thuong thang
                var vLstBT_Thang_NamHT = await _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.next_month_id.ToString().Substring(0, 4) && s.code_order == "05")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToListAsync();
                var vLstBT_Thang_NamTruoc = await _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "05")
                                              .GroupBy(s => new { s.account_month, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          account_month = x.Key.account_month,
                                                          account_year = x.Key.account_year,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToListAsync();
                //BHG NNV nam
                var vLstBHG_NNV_NamHT = await _bcgdRepo.AsActiveNoTracking()
                                              .Join(_amgRepo.AsActiveNoTracking(), bcgd => bcgd.class_group_id, amg => amg.id,
                                                    (bcgd, amg) => new {
                                                        class_group_id = bcgd.class_group_id,
                                                        cg_ename = amg.ename,
                                                        account_month = bcgd.account_month,
                                                        code_order = bcgd.code_order,
                                                        account_year = bcgd.account_year,
                                                        original_money = bcgd.original_money
                                                    })
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4) && s.code_order == "04")
                                              .GroupBy(s => new { s.class_group_id, s.cg_ename, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          class_group_id = x.Key.class_group_id,
                                                          cg_ename = x.Key.cg_ename,
                                                          total_money = x.Sum(g => g.original_money)
                                                      }).ToListAsync();
                var vLstBHG_NNV_NamTruoc = await _bcgdRepo.AsActiveNoTracking()
                                              .Join(_amgRepo.AsActiveNoTracking(), bcgd => bcgd.class_group_id, amg => amg.id,
                                                    (bcgd, amg) => new {
                                                        class_group_id = bcgd.class_group_id,
                                                        cg_ename = amg.ename,
                                                        account_month = bcgd.account_month,
                                                        code_order = bcgd.code_order,
                                                        account_year = bcgd.account_year,
                                                        original_money = bcgd.original_money,
                                                        int_datadate = bcgd.int_datadate
                                                    })
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.account_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.int_datadate < ngaynay_namtruoc && s.code_order == "04")
                                              .GroupBy(s => new { s.class_group_id, s.cg_ename, s.account_year })
                                              .Select(x =>
                                                      new {
                                                          class_group_id = x.Key.class_group_id,
                                                          cg_ename = x.Key.cg_ename,
                                                          total_money = x.Sum(g => g.original_money)
                                                      }).ToListAsync();
                //Tổng BT NNV
                var vLstTongBT_NNV_NamHT = await _bcgdRepo.AsActiveNoTracking()
                                              .Join(_amgRepo.AsActiveNoTracking(), bcgd => bcgd.class_group_id, amg => amg.id,
                                                    (bcgd, amg) => new {
                                                        class_group_id = bcgd.class_group_id,
                                                        cg_ename = amg.ename,
                                                        account_month = bcgd.account_month,
                                                        code_order = bcgd.code_order,
                                                        account_year = bcgd.account_year,
                                                        original_money = bcgd.original_money,
                                                        int_datadate = bcgd.int_datadate
                                                    })
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4) && s.account_month < vAAM.account_month_id && s.code_order == "05")
                                              .GroupBy(s => new { s.class_group_id, s.cg_ename })
                                              .Select(x =>
                                                      new {
                                                          class_group_id = x.Key.class_group_id,
                                                          cg_ename = x.Key.cg_ename,
                                                          total_compensation = x.Sum(g => g.original_money),
                                                      }).ToListAsync();
                var vLstTongBT_NNV_NamTruoc = await _bcgdRepo.AsActiveNoTracking()
                                              .Join(_amgRepo.AsActiveNoTracking(), bcgd => bcgd.class_group_id, amg => amg.id,
                                                    (bcgd, amg) => new {
                                                        class_group_id = bcgd.class_group_id,
                                                        cg_ename = amg.ename,
                                                        account_month = bcgd.account_month,
                                                        code_order = bcgd.code_order,
                                                        account_year = bcgd.account_year,
                                                        original_money = bcgd.original_money,
                                                        int_datadate = bcgd.int_datadate
                                                    })
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == (int.Parse(vAAM.next_month_id.ToString().Substring(0, 4)) - 1).ToString() && s.account_month < thang_namtruoc && s.code_order == "05")
                                              .GroupBy(s => new { s.class_group_id, s.cg_ename })
                                              .Select(x =>
                                                      new {
                                                          class_group_id = x.Key.class_group_id,
                                                          cg_ename = x.Key.cg_ename,
                                                          total_compensation = x.Sum(g => g.original_money),
                                                      }).ToListAsync();

                var vLstBHG_MT = await _rtRepo.AsActiveNoTracking()
                                 .Where(x => x.account_year == DateTime.Now.Year.ToString() && x.branch_id == 1 && x.class_group_id == 1)
                                 .ToListAsync();

                //add data
                var vReportGeneral = new report_general();

                vReportGeneral.thanght = vAAM.next_month_id.ToString().Substring(4, 2);
                vReportGeneral.thangtruoc = (vAAM.next_month_id - 1).ToString().Substring(4, 2);
                //bhg lũy kế
                decimal bhg_MT_NamHT = vLstBHG_MT.FirstOrDefault(x => x.account_month == "All" && x.type_target == "revenue")?.target ?? 0;
                decimal vBHG_lk_NamTruoc = vLstBHG_Thang_NamTruoc?.Sum(x => x.total_money) ?? 0;
                vReportGeneral.bhg_lk_ht = ConvertNumToString.NumberToString(vLstBHG_Thang_NamHT?.Sum(x => x.total_money) ?? 0);
                vReportGeneral.bhg_mt_nam = ConvertNumToString.NumberToString(bhg_MT_NamHT);
                vReportGeneral.bhg_lk_tlht = bhg_MT_NamHT == 0 ? "100%" : Math.Round((vLstBHG_Thang_NamHT?.Sum(x => x.total_money) ?? 0) / bhg_MT_NamHT, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                vReportGeneral.bhg_lk_namtruoc = ConvertNumToString.NumberToString(vBHG_lk_NamTruoc);
                vReportGeneral.bhg_lk_tt = vBHG_lk_NamTruoc == 0 ? "100" : Math.Round((((vLstBHG_Thang_NamHT?.Sum(x => x.total_money) ?? 0) / vBHG_lk_NamTruoc) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                //DT tháng
                decimal bhg_MT_ThangHT = vLstBHG_MT.FirstOrDefault(x => x.account_month == vAAM.next_month_id.ToString() && x.type_target == "revenue")?.target ?? 0;
                decimal vBHG_Thang_NamTruoc = vLstBHG_Thang_NamTruoc.FirstOrDefault(x => x.account_month == thang_namtruoc)?.total_money ?? 0;
                vReportGeneral.dt_mt_thanght = ConvertNumToString.NumberToString(bhg_MT_ThangHT);
                vReportGeneral.dt_thang_ht = ConvertNumToString.NumberToString(vLstBHG_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id)?.total_money ?? 0);
                vReportGeneral.dt_thang_tlht = bhg_MT_ThangHT == 0 ? "100%" :
                    (Math.Round(vLstBHG_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id)?.total_money ?? 0) / bhg_MT_ThangHT, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                vReportGeneral.dt_thang_namtruoc = ConvertNumToString.NumberToString(vBHG_Thang_NamTruoc);
                vReportGeneral.dt_thang_tt = vBHG_Thang_NamTruoc == 0 ? "100%" : 
                    (Math.Round(((vLstBHG_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id)?.total_money ?? 0) /  vBHG_Thang_NamTruoc) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                //loi nhuan luy ke
                decimal ln_MT_NamHT = vLstBHG_MT.FirstOrDefault(x => x.account_month == vAAM.account_month_id.ToString().Substring(0, 4) && x.type_target == "profit" && x.branch_id == 1 && x.class_group_id == 1)?.target ?? 0;
                decimal ln_lk_namht = (vLstBHG_Thang_NamHT?.Sum(x => x.total_money) ?? 0) - (vLstBT_Thang_NamHT?.Sum(x => x.total_compensation) ?? 0);
                decimal ln_lk_namtruoc = (vLstBHG_Thang_NamTruoc?.Sum(x => x.total_money) ?? 0) - (vLstBT_Thang_NamTruoc?.Sum(x => x.total_compensation) ?? 0);
                vReportGeneral.ln_mt_nam = ConvertNumToString.NumberToString(ln_MT_NamHT);
                vReportGeneral.ln_lk_thanght = ConvertNumToString.NumberToString(ln_lk_namht);
                vReportGeneral.ln_lk_tlht = ln_MT_NamHT == 0 ? "100%" : 
                    Math.Round(ln_lk_namht / ln_MT_NamHT, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                vReportGeneral.ln_lk_namtruoc = ConvertNumToString.NumberToString(ln_lk_namtruoc);
                vReportGeneral.ln_lk_tt = ln_lk_namtruoc == 0 ? "100%" : Math.Round(((ln_lk_namht / ln_lk_namtruoc) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();

                //bhg các tháng
                if ((vLstBHG_Thang_NamHT?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vLstBHG_Thang_NamHT.Count(); i++)
                    {
                        var vData = new bhg_thang();
                        vData.thang = vLstBHG_Thang_NamHT[i].account_month.ToString().Substring(4, 2);
                        vData.nam_ht = vLstBHG_Thang_NamHT[i].account_month.ToString().Substring(0, 4);
                        vData.bhg_thang_namht = ConvertNumToString.ShortenNumberBillion(vLstBHG_Thang_NamHT[i].total_money);
                        vData.bhg_thang_namtruoc = ConvertNumToString.ShortenNumberBillion(0);
                        vData.bhg_thang_namht_format = ConvertNumToString.NumberToStringFormat(vLstBHG_Thang_NamHT[i].total_money) + " LAK";
                        vData.bhg_thang_namtruoc_format = ConvertNumToString.NumberToStringFormat(0) + " LAK";
                        vData.bhg_thang_tangtruong = "100";
                        lst_bhg_thang.Add(vData);                   
                    }
                }
                if ((vLstBHG_Thang_NamTruoc?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vLstBHG_Thang_NamTruoc.Count(); i++)
                    {
                        var index = lst_bhg_thang.FindIndex(x => x.thang == vLstBHG_Thang_NamTruoc[i].account_month.ToString().Substring(4, 2));
                        if (index > -1)
                        {
                            lst_bhg_thang[index].bhg_thang_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_Thang_NamTruoc[i].total_money);
                            lst_bhg_thang[index].bhg_thang_namht_format = ConvertNumToString.NumberToStringFormat(vLstBHG_Thang_NamTruoc[i].total_money) + " LAK";
                            lst_bhg_thang[index].bhg_thang_tangtruong = Math.Round(((vLstBHG_Thang_NamHT
                                .Find(x => x.account_month.ToString().Substring(4, 2) == vLstBHG_Thang_NamTruoc[i].account_month.ToString().Substring(4, 2)).total_money / 
                                vLstBHG_Thang_NamTruoc[i].total_money) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                        }
                        else
                        {
                            var vData = new bhg_thang();
                            vData.thang = vLstBHG_Thang_NamHT[i].account_month.ToString().Substring(4, 2);
                            vData.nam_ht = vLstBHG_Thang_NamHT[i].account_month.ToString().Substring(0, 4);
                            vData.bhg_thang_namht = ConvertNumToString.ShortenNumberBillion(0);
                            vData.bhg_thang_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_Thang_NamTruoc[i].total_money);
                            vData.bhg_thang_namht_format = ConvertNumToString.NumberToStringFormat(0) + " LAK";
                            vData.bhg_thang_namtruoc_format = ConvertNumToString.NumberToStringFormat(vLstBHG_Thang_NamTruoc[i].total_money) + " LAK";
                            vData.bhg_thang_tangtruong = "0";
                            lst_bhg_thang.Add(vData);
                        }
                    }
                        
                }
                //bhg nhóm nv các lũy kế
                if ((vLstBHG_NNV_NamHT?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vLstBHG_Thang_NamHT.Count(); i++)
                    {
                        var vData = new bhg_nnv_lk();
                        vData.class_group_id = vLstBHG_NNV_NamHT[i].class_group_id;
                        vData.nhomnghiepvu = vLstBHG_NNV_NamHT[i].cg_ename;
                        vData.bhg_nnv_lk_namht = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_NamHT[i].total_money);
                        vData.bhg_nnv_lk_namtruoc = ConvertNumToString.ShortenNumberBillion(0);
                        vData.bhg_nnv_lk_namht_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NNV_NamHT[i].total_money) + " LAK";
                        vData.bhg_nnv_lk_namtruoc_format = ConvertNumToString.NumberToStringFormat(0) + " LAK";
                        vData.bhg_nnv_lk_tt = "100";
                        lstBHG_NNV_LK.Add(vData);
                    }
                }
                if ((vLstBHG_NNV_NamTruoc?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vLstBHG_NNV_NamTruoc.Count(); i++)
                    {
                        var index = lstBHG_NNV_LK.FindIndex(x => x.class_group_id == vLstBHG_NNV_NamTruoc[i].class_group_id);
                        if (index > -1)
                        {
                            lstBHG_NNV_LK[index].bhg_nnv_lk_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_NamTruoc[i].total_money);
                            lstBHG_NNV_LK[index].bhg_nnv_lk_namtruoc_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NNV_NamTruoc[i].total_money) + " LAK";
                            lstBHG_NNV_LK[index].bhg_nnv_lk_tt = Math.Round(((vLstBHG_NNV_NamHT
                                .Find(x => x.class_group_id == vLstBHG_NNV_NamTruoc[i].class_group_id).total_money /
                                vLstBHG_NNV_NamTruoc[i].total_money) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                        }
                        else
                        {
                            var vData = new bhg_nnv_lk();
                            vData.class_group_id = vLstBHG_NNV_NamHT[i].class_group_id;
                            vData.nhomnghiepvu = vLstBHG_NNV_NamHT[i].cg_ename;
                            vData.bhg_nnv_lk_namht = ConvertNumToString.ShortenNumberBillion(0);
                            vData.bhg_nnv_lk_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_NamTruoc[i].total_money);
                            vData.bhg_nnv_lk_namht_format = ConvertNumToString.NumberToStringFormat(0) + " LAK";
                            vData.bhg_nnv_lk_namtruoc_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NNV_NamTruoc[i].total_money) + " LAK";
                            vData.bhg_nnv_lk_tt = "0";
                            lstBHG_NNV_LK.Add(vData);
                        }
                    }

                }
                if ((vlstClassGroup?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vlstClassGroup.Count(); i++)
                    {

                        var tongbt_nnv_ht = vLstTongBT_NNV_NamHT.FirstOrDefault(x => x.class_group_id == vlstClassGroup[i].id)?.total_compensation ?? 0;
                        var tongbt_nnv_namtruoc = vLstTongBT_NNV_NamTruoc.FirstOrDefault(x => x.class_group_id == vlstClassGroup[i].id)?.total_compensation ?? 0;
                        var bhg_nnv_namht = vLstBHG_NNV_NamHT.FirstOrDefault(x => x.class_group_id == vlstClassGroup[i].id)?.total_money ?? 1;
                        var bhg_nnv_namtruoc = vLstBHG_NNV_NamTruoc.FirstOrDefault(x => x.class_group_id == vlstClassGroup[i].id)?.total_money ?? 1;
                        if (tongbt_nnv_ht != 0 || tongbt_nnv_namtruoc != 0)
                        {
                            var vData1 = new tlbtgl_nnv_lk();
                            vData1.nhomnghiepvu = vlstClassGroup[i].ename;
                            vData1.tbltgl_nnv_lk_namht = Math.Round(tongbt_nnv_ht * 100 / bhg_nnv_namht, 2, MidpointRounding.AwayFromZero).ToString();
                            vData1.tbltgl_nnv_lk_namtruoc = Math.Round(tongbt_nnv_namtruoc * 100 / bhg_nnv_namtruoc, 2, MidpointRounding.AwayFromZero).ToString();
                            lstTLBTGL_NNV_LK.Add(vData1);
                        }
                    }
                }
                    
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
        public async Task<report_class_group> GetReportClassGroup(decimal? class_group_id)
        {
            try
            {
                if (!class_group_id.HasValue || class_group_id == 0)
                {
                    return null;
                }
                var lstrcg_bhg_nnv_ngay = new List<rcg_bhg_nnv_ngay>();
                var lstrcg_bhg_nv_lk = new List<rcg_bhg_nv_lk>();
                var lstrcg_bhg_nnv_thang = new List<rcg_bhg_nnv_thang>();
                var lstrcg_tlbtgl = new List<rcg_tlbtgl>();
                var vAAM = await _aamRepo.AsActiveNoTracking().FirstOrDefaultAsync();

                //Ngày này nam truoc
                var ngaynay_namtruoc = int.Parse((vAAM.next_month_id - 100).ToString() + (DateTime.Now.Day - 1).ToString());
                //thang này nam truoc
                var thang_namtruoc = vAAM.next_month_id - 100;
                //thang truoc nam truoc
                var thangtruoc_namtruoc = vAAM.next_month_id - 101;

                //BHG NNV thang
                var vLstBHG_NNV_Thang_NamHT =  await _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4)
                                                          && s.class_group_id == class_group_id && s.code_order == "04")
                                              .GroupBy(s => new { s.account_month, s.class_group_id })
                                              .Select(x =>
                                                      new
                                                      {
                                                          account_month = x.Key.account_month,
                                                          class_group_id = x.Key.class_group_id,
                                                          total_money = x.Sum(g => g.original_money),
                                                      }).ToListAsync();
                var vLstBHG_NNV_Thang_NamTruoc = await _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == thang_namtruoc.ToString().Substring(0, 4)
                                                          && s.class_group_id == class_group_id && s.int_datadate <= ngaynay_namtruoc && s.code_order == "04")
                                              .GroupBy(s => new { s.class_group_id, s.account_month })
                                              .Select(x =>
                                                      new
                                                      {
                                                          account_month = x.Key.account_month,
                                                          class_group_id = x.Key.class_group_id,
                                                          total_money = x.Sum(g => g.original_money),
                                                      }).ToListAsync();
                //boi thuong nnv thang
                var vLstBT_NNV_Thang_NamHT = await _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4)
                                                          && s.class_group_id == class_group_id && s.code_order == "05")
                                              .GroupBy(s => new { s.class_group_id, s.account_month })
                                              .Select(x =>
                                                      new
                                                      {
                                                          account_month = x.Key.account_month,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToListAsync();
                var vLstBT_NNV_Thang_NamTruoc = await _bcgdRepo.AsActiveNoTracking()
                                              .Where(s => s.account_month.ToString().Substring(0, 4) == thang_namtruoc.ToString().Substring(0, 4)
                                                           && s.int_datadate < ngaynay_namtruoc
                                                           && s.class_group_id == class_group_id && s.code_order == "05")
                                              .GroupBy(s => new { s.class_group_id, s.account_month })
                                              .Select(x =>
                                                      new
                                                      {
                                                          account_month = x.Key.account_month,
                                                          total_compensation = x.Sum(g => g.original_money)
                                                      }).ToListAsync();
                //bhg nnv theo ngày
                var vLstBHG_NNV_Ngay_thanght = await _bcgdRepo.AsActiveNoTracking()
                                             .Where(s => s.account_month == vAAM.account_month_id
                                                          && s.class_group_id == class_group_id && s.code_order == "04")
                                             .GroupBy(s => new { s.class_group_id, s.int_datadate })
                                            .Select(x => new
                                            {
                                                ngay = x.Key.int_datadate.ToString().Substring(6, 2),
                                                class_group_id = x.Key.class_group_id,
                                                total_money = x.Sum(g => g.original_money)
                                            }).ToListAsync();
                //bhg nghiệp vụ lk
                var vLstBHG_NV_lk_NamHT = await _bcdRepo.AsActiveNoTracking()
                                            .Where(s => s.account_year == vAAM.account_month_id.ToString().Substring(0, 4) && s.code_order == "04"
                                                     && s.class_group_id == class_group_id)
                                            .GroupBy(s => new { s.class_code })
                                            .Select(x => new
                                            {
                                                class_code = x.Key.class_code,
                                                total_money = x.Sum(g => g.original_money),
                                            }).ToListAsync();
                var vLstBHG_NV_lk_NamTruoc = await _bcdRepo.AsActiveNoTracking()
                                            .Where(s => s.account_year == ngaynay_namtruoc.ToString().Substring(0, 4) && s.code_order == "04"
                                                     && s.int_datadate < ngaynay_namtruoc
                                                     && s.class_group_id == class_group_id)
                                            .GroupBy(s => new { s.class_code })
                                            .Select(x => new
                                            {
                                                class_code = x.Key.class_code,
                                                total_money = x.Sum(g => g.original_money),
                                            }).ToListAsync();
                //btgl theo nghiep vu lk
                var vLstTongBT_NV_NamHT = await _bcdRepo.AsActiveNoTracking()
                                             .Join(_lipRepo.AsActiveNoTracking(), bcd => bcd.class_code, lip => lip.code,
                                                   (bcgd, lip) => new
                                                   {
                                                       class_group_id = bcgd.class_group_id,
                                                       class_code = lip.code,
                                                       account_month = bcgd.account_month,
                                                       code_order = bcgd.code_order,
                                                       account_year = bcgd.account_year,
                                                       original_money = bcgd.original_money,
                                                       int_datadate = bcgd.int_datadate
                                                   })
                                             .Where(s => s.account_month.ToString().Substring(0, 4) == vAAM.account_month_id.ToString().Substring(0, 4)
                                                        && s.code_order == "05" && s.class_group_id == class_group_id)
                                             .GroupBy(s => new { s.class_code })
                                             .Select(x =>
                                                     new
                                                     {
                                                         class_code = x.Key.class_code,
                                                         total_compensation = x.Sum(g => g.original_money),
                                                     }).ToListAsync();

                //lst muc tieu 
                var vLstBHG_MT = await _rtRepo.AsActiveNoTracking()
                                 .Join(_branchRepo.AsActiveNoTracking(),
                                       _rtRepo => _rtRepo.branch_id,
                                       _branchRepo => _branchRepo.id,
                                       (_rtRepo, _branchRepo) => new { rt = _rtRepo, branch = _branchRepo })
                                 .Where(x => x.rt.account_year == DateTime.Now.Year.ToString() && x.rt.class_group_id == class_group_id)
                                 .ToListAsync();
                //nnv
                var vClassGroup = await _amgRepo.AsNoTracking().FirstOrDefaultAsync(x => x.id == class_group_id);

                //insert du lieu report
                var vrcg = new report_class_group();
                vrcg.class_group_name = vClassGroup.name;
                vrcg.thanght = vAAM.next_month_id.ToString().Substring(4, 2);
                vrcg.thanght_namtruoc = (vAAM.next_month_id - 1).ToString().Substring(4, 2);
                vrcg.bhg_thanght = ConvertNumToString.NumberToString(vLstBHG_NNV_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id)?.total_money ?? 0);

                vrcg.bhg_thanght = (vLstBHG_NNV_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id)?.total_money ?? 0).NumberToString();

                vrcg.bhg_thanght_namtruoc = ConvertNumToString.NumberToString(vLstBHG_NNV_Thang_NamTruoc.FirstOrDefault(x => x.account_month == thang_namtruoc)?.total_money ?? 0);
                vrcg.bhg_thanght_tt = Math.Round((vLstBHG_NNV_Thang_NamHT.FirstOrDefault(x => x.account_month == vAAM.account_month_id)?.total_money ?? 0) * 100 /
                                                vLstBHG_NNV_Thang_NamTruoc.FirstOrDefault(x => x.account_month == thang_namtruoc)?.total_money ?? 1, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                //bhg luy ke
                vrcg.bhg_lk_ht = ConvertNumToString.NumberToString(vLstBHG_NNV_Thang_NamHT?.Sum(x => x.total_money) ?? 0);
                vrcg.bhg_lk_muctieu = vLstBHG_MT.FirstOrDefault(x => x.rt.account_month == "All" && x.rt.type_target == "revenue")?.rt.target_name ?? "0";
                vrcg.bhg_lk_tlht = Math.Round((vLstBHG_NNV_Thang_NamHT?.Sum(x => x.total_money) ?? 0) * 100 / (vLstBHG_MT.FirstOrDefault(x => x.rt.account_month == "All" && x.rt.type_target == "revenue")?.rt.target ?? 1)).ToString();
                vrcg.bhg_lk_phankhai = "";
                vrcg.bhg_lk_tangtruong = Math.Round(((vLstBHG_NNV_Thang_NamHT?.Sum(x => x.total_money) ?? 0) / (vLstBHG_NNV_Thang_NamTruoc?.Sum(x => x.total_money) ?? 1) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                //tlbtgl
                vrcg.tlbtgl_ht = Math.Round((vLstBT_NNV_Thang_NamHT?.Sum(x => x.total_compensation) ?? 0) / (vLstBHG_NNV_Thang_NamHT?.Sum(x => x.total_money) ?? 1), 2).ToString();
                vrcg.tlbtgl_namtruoc = ((vLstBT_NNV_Thang_NamTruoc?.Sum(x => x.total_compensation) ?? 0) / (vLstBHG_NNV_Thang_NamTruoc?.Sum(x => x.total_money) ?? 1)).ToString();

                //list bhg nnv theo thang
                if ((vLstBHG_NNV_Thang_NamHT?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vLstBHG_NNV_Thang_NamHT.Count(); i++)
                    {
                        var vData = new rcg_bhg_nnv_thang();
                        vData.thang = vLstBHG_NNV_Thang_NamHT[i].account_month.ToString().Substring(4, 2);
                        vData.bhg_nnv_thang_namht = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_Thang_NamHT[i].total_money);
                        vData.bhg_nnv_thang_namht_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NNV_Thang_NamHT[i].total_money);
                        vData.bhg_nnv_thang_namtruoc = "0";
                        vData.bhg_nnv_thang_namtruoc_format = ConvertNumToString.NumberToStringFormat(0);
                        vData.bhg_nnv_tangtruong = "100%";
                        lstrcg_bhg_nnv_thang.Add(vData);

                    }
                }
                if ((vLstBHG_NNV_Thang_NamTruoc?.Count() ?? 0) > 0)
                {
                    for (int j = 0; j < vLstBHG_NNV_Thang_NamTruoc.Count(); j++)
                    {
                        var index = lstrcg_bhg_nnv_thang.FindIndex(x => x.thang == vLstBHG_NNV_Thang_NamHT[j].account_month.ToString().Substring(4, 2));
                        if (index > -1)
                        {
                            lstrcg_bhg_nnv_thang[index].bhg_nnv_thang_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_Thang_NamTruoc[j].total_money);
                            lstrcg_bhg_nnv_thang[index].bhg_nnv_tangtruong = Math.Round(((vLstBHG_NNV_Thang_NamHT.Find(x => x.account_month == vLstBHG_NNV_Thang_NamHT[j].account_month).total_money / vLstBHG_NNV_Thang_NamTruoc[j].total_money) - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString();
                        }
                        else
                        {
                            var vData = new rcg_bhg_nnv_thang();
                            vData.thang = vLstBHG_NNV_Thang_NamTruoc[j].account_month.ToString().Substring(4, 2);
                            vData.bhg_nnv_thang_namht = "0";
                            vData.bhg_nnv_thang_namht_format = ConvertNumToString.NumberToStringFormat(0);
                            vData.bhg_nnv_thang_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_Thang_NamTruoc[j].total_money);
                            vData.bhg_nnv_thang_namtruoc_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NNV_Thang_NamTruoc[j].total_money);
                            vData.bhg_nnv_tangtruong = "100%";
                            lstrcg_bhg_nnv_thang.Add(vData);
                        }
                    }
                }
                    
                //list bhg nnv theo ngay
                if ((vLstBHG_NNV_Ngay_thanght?.Count() ?? 0) > 0)
                    for (int i = 0; i < vLstBHG_NNV_Ngay_thanght.Count(); i++)
                    {
                        var vData = new rcg_bhg_nnv_ngay();
                        vData.ngay = vLstBHG_NNV_Ngay_thanght[i].ngay.ToString();
                        vData.bhg_nnv_ngay = ConvertNumToString.ShortenNumberBillion(vLstBHG_NNV_Ngay_thanght[i].total_money);
                        vData.bhg_nnv_ngay_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NNV_Ngay_thanght[i].total_money) + " LAK";
                        lstrcg_bhg_nnv_ngay.Add(vData);
                    }

                //list bhg nghiệp vụ lk
                if ((vLstBHG_NV_lk_NamHT?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vLstBHG_NV_lk_NamHT.Count(); i++)
                    {
                        var vData = new rcg_bhg_nv_lk();
                        vData.class_code = vLstBHG_NV_lk_NamHT[i].class_code;
                        vData.bhg_nv_lk_namht = ConvertNumToString.ShortenNumberBillion(vLstBHG_NV_lk_NamHT[i].total_money);
                        vData.bhg_nv_lk_namht_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NV_lk_NamHT[i].total_money) + " LAK";
                        vData.bhg_nv_lk_namtruoc = ConvertNumToString.ShortenNumberBillion(0);
                        vData.bhg_nv_lk_namtruoc_format = ConvertNumToString.NumberToStringFormat(0) + " LAK";
                        vData.bhg_nv_lk_tt = "100";
                        vData.bhg_nv_lk_tt_format = "100%";
                        lstrcg_bhg_nv_lk.Add(vData);


                    }
                }
                if ((vLstBHG_NV_lk_NamTruoc?.Count() ?? 0) > 0)
                { 
                    for (int i = 0; i < vLstBHG_NV_lk_NamTruoc.Count(); i++)
                    {
                        var index = lstrcg_bhg_nv_lk.FindIndex(x => x.class_code == vLstBHG_NV_lk_NamTruoc[i].class_code);
                        if (index > -1)
                        {
                            lstrcg_bhg_nv_lk[index].bhg_nv_lk_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_NV_lk_NamTruoc[i].total_money);
                            lstrcg_bhg_nv_lk[index].bhg_nv_lk_namtruoc_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NV_lk_NamTruoc[i].total_money) + " LAK";
                            lstrcg_bhg_nv_lk[index].bhg_nv_lk_tt = Math.Round((vLstBHG_NV_lk_NamHT.Find(x => x.class_code == vLstBHG_NV_lk_NamTruoc[i].class_code).total_money * 100) / vLstBHG_NV_lk_NamTruoc[i].total_money, 2, MidpointRounding.AwayFromZero).ToString();
                            lstrcg_bhg_nv_lk[index].bhg_nv_lk_tt_format = Math.Round((vLstBHG_NV_lk_NamHT.Find(x => x.class_code == vLstBHG_NV_lk_NamTruoc[i].class_code).total_money * 100) / vLstBHG_NV_lk_NamTruoc[i].total_money, 2, MidpointRounding.AwayFromZero).ToString() + "%";
                        }
                        else 
                        {
                            var vData = new rcg_bhg_nv_lk();
                            vData.class_code = vLstBHG_NV_lk_NamHT[i].class_code;
                            vData.bhg_nv_lk_namht = ConvertNumToString.ShortenNumberBillion(0);
                            vData.bhg_nv_lk_namht_format = ConvertNumToString.NumberToStringFormat(0) + " LAK";
                            vData.bhg_nv_lk_namtruoc = ConvertNumToString.ShortenNumberBillion(vLstBHG_NV_lk_NamTruoc[i].total_money);
                            vData.bhg_nv_lk_namtruoc_format = ConvertNumToString.NumberToStringFormat(vLstBHG_NV_lk_NamTruoc[i].total_money) + " LAK";
                            lstrcg_bhg_nv_lk.Add(vData);
                        }
                    }
                }

                //list tlbtgl
                if ((vLstTongBT_NV_NamHT?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vLstTongBT_NV_NamHT.Count(); i++)
                    {
                        var vData = new rcg_tlbtgl();
                        vData.class_code = vLstTongBT_NV_NamHT[i].class_code;
                        vData.tlbtgl = "100";
                        lstrcg_tlbtgl.Add(vData);

                    }
                }
                if ((vLstBHG_NV_lk_NamHT?.Count() ?? 0) > 0)
                {
                    for (int i = 0; i < vLstBHG_NV_lk_NamHT.Count(); i++)
                    {
                        var index = lstrcg_tlbtgl.FindIndex(x => x.class_code == vLstBHG_NV_lk_NamHT[i].class_code);
                        if (index > -1)
                        {
                            lstrcg_tlbtgl[index].tlbtgl = Math.Round(vLstTongBT_NV_NamHT.Find(x => x.class_code == vLstBHG_NV_lk_NamHT[i].class_code).total_compensation * 100 / vLstBHG_NV_lk_NamHT[i].total_money).ToString();
                        }
                        else
                        {
                            var vData = new rcg_tlbtgl();
                            vData.class_code = vLstBHG_NV_lk_NamHT[i].class_code;
                            vData.tlbtgl = "-100";
                            lstrcg_tlbtgl.Add(vData);
                        }
                    }
                }
                    
                vrcg.rcg_bhg_nnv_thangs = lstrcg_bhg_nnv_thang;
                vrcg.rcg_bhg_nnv_ngays = lstrcg_bhg_nnv_ngay;
                vrcg.rcg_bhg_nv_lks = lstrcg_bhg_nv_lk;
                vrcg.rcg_tlbtgls = lstrcg_tlbtgl;
                return vrcg;
            }
            catch (Exception ex)
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
                                  .GroupBy(s => new { s.class_group_id, s.account_year, s.branch_id })
                                  .Select(x =>
                                          new {
                                              branch_id = x.Key.branch_id,
                                              account_year = x.Key.account_year,
                                              class_group_id = x.Key.class_group_id,
                                              total_money = x.Sum(g => g.original_money),
                                          }).ToList();
                var vLstBHG_NNV_CN_Namtruoc = _bcgdRepo.AsActiveNoTracking()
                                  .Where(s => int.Parse(s.account_month.ToString().Substring(0, 4)) == int.Parse(vAAM.account_month_id.ToString().Substring(0, 4))
                                         && s.branch_id == branch_id && s.int_datadate < ngaynay_namtruoc)
                                  .GroupBy(s => new { s.class_group_id, s.account_year, s.branch_id })
                                  .Select(x =>
                                          new {
                                              branch_id = x.Key.branch_id,
                                              account_year = x.Key.account_year,
                                              class_group_code = x.Key.class_group_id,
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
                        if (vLstBHG_NNV_CN_NamHT[i].class_group_id.ToString() == vLstBHG_NNV_CN_Namtruoc[j].class_group_code.ToString())
                        {
                            var bhg_cn_thang_muctieu = vLstBHG_MT.FirstOrDefault(x => x.rt.account_month.ToString() == vLstBHG_CN_Thang_NamHT[i].account_month.ToString().Substring(5, 2)).rt.target;
                            var vData = new rb_bhg_nvv_cn();
                            vData.nnv_ten = vLstBHG_NNV_CN_NamHT[i].class_group_id.ToString().Substring(5, 2);
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
