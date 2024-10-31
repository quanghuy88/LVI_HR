using Constract.Model;
using Core.Entities;
using Injection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base.LVIDashboard;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.Services
{
    public class CategoryService : ICategoryService, IScopedInjection
    {
        private readonly ILVIDashboardRepository<admin_position> _apRepo;
        private readonly ILVIDashboardRepository<admin_country> _acRepo;
        private readonly ILVIDashboardRepository<admin_department> _adRepo;
        private readonly ILVIDashboardRepository<admin_place> _aplaceRepo;
        public CategoryService(IServiceProvider serviceProvider) 
        {
            _apRepo = serviceProvider.GetService(_apRepo);
            _acRepo = serviceProvider.GetService(_acRepo);
            _adRepo = serviceProvider.GetService(_adRepo);
            _aplaceRepo = serviceProvider.GetService(_aplaceRepo);
        }

        //GET
        public async Task<List<admin_position>> GetPositionAsync() 
        {
            var result = await _apRepo.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<List<admin_country>> GetCountAsync()
        {
            var result = await _acRepo.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<List<admin_department>> GetDepartmentAsync()
        {
            var result = await _adRepo.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<List<admin_place>> GetPlaceAsync()
        {
            var result = await _aplaceRepo.AsNoTracking().ToListAsync();
            return result;
        }

        //POST
        public async Task<decimal> PostPositionAsync([FromBody]admin_position model)
        {
            try
            {
                if (model.id == 0)
                {
                    //insert
                    _apRepo.AddAsync(model);
                }
                else
                {
                    //update
                    var data = await _apRepo.AsNoTracking().FirstOrDefaultAsync(x => x.id == model.id);
                    if (data != null)
                    { 
                        data.name = model.name;
                        data.level = model.level;
                        data.sequence = model.sequence;
                    }
                    _apRepo.Update(data);
                }
                _apRepo.SaveChangesAsync();
                return model.id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<decimal> PostCountAsync([FromBody] admin_country model)
        {
            try
            {
                if (model.id == 0)
                {
                    //insert
                    _acRepo.AddAsync(model);
                }
                else
                {
                    //update
                    var data = await _acRepo.AsNoTracking().FirstOrDefaultAsync(x => x.id == model.id);
                    if (data != null)
                    {
                        data.name = model.name;
                        data.postal_code = model.postal_code;
                        data.description = model.description;
                        data.sequence = model.sequence;
                        data.modified_date = DateTime.Now;
                        data.modified_by = model.modified_by;
                    }
                    _acRepo.Update(data);
                }
                _acRepo.SaveChangesAsync();
                return model.id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<decimal> PostDepartmentAsync([FromBody] admin_department model)
        {
            try
            {
                if (model.id == 0)
                {
                    //insert
                    _adRepo.AddAsync(model);
                }
                else
                {
                    //update
                    var data = await _adRepo.AsNoTracking().FirstOrDefaultAsync(x => x.id == model.id);
                    if (data != null)
                    {
                        data.code = model.code;
                        data.code_ref = model.code_ref;
                        data.contact_name = model.contact_name;
                        data.contact_tel = model.contact_tel;
                        data.name = model.name;
                        data.domain_id = model.domain_id;
                        data.parent_id = model.parent_id;
                        data.name_abbreviation = model.name_abbreviation;
                        data.level = model.level;
                        data.address = model.address;
                        data.place_id = model.place_id;
                        data.image = model.image;
                        data.slogan = model.slogan;
                        data.tel = model.tel;
                        data.fax = model.fax;
                        data.email = model.email;
                        data.website = model.website;
                        data.tax_code = model.tax_code;
                        data.director_name = model.director_name;
                        data.account_name = model.account_name;
                        data.acc_no = model.acc_no;
                        data.bank_name = model.bank_name;
                        data.bank_address = model.bank_address;
                        data.bussiness_registration_no = model.bussiness_registration_no;
                        data.contact_address = model.contact_address;
                        data.contact_mobile = model.contact_mobile;
                        data.contact_email = model.contact_email;
                        data.note = model.note;
                        data.sequence = model.sequence;
                        data.status = model.status;
                        data.modified_date = DateTime.Now;
                        data.modified_by = model.modified_by;
                    }
                    _adRepo.Update(data);
                }
                _adRepo.SaveChangesAsync();
                return model.id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<decimal> PostPlaceAsync([FromBody] admin_place model)
        {
            try
            {
                if (model.id == 0)
                {
                    //insert
                    _aplaceRepo.AddAsync(model);
                }
                else
                {
                    //update
                    var data = await _aplaceRepo.AsNoTracking().FirstOrDefaultAsync(x => x.id == model.id);
                    if (data != null)
                    {
                        data.name = model.name;
                        data.postal_code = model.postal_code;
                        data.sequence = model.sequence;
                        data.description = model.description;
                    }
                    _aplaceRepo.Update(data);
                }
                _aplaceRepo.SaveChangesAsync();
                return model.id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
