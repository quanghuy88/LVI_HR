using Infrastructure.Data;
using Injection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base.LVIDashboard
{
    public class LVIDashboardRepository<TEntity> : Repository<TEntity>, ILVIDashboardRepository<TEntity>, IScopedInjection where TEntity : class
    {
        private readonly IContextUserService _contextUserService;

        public LVIDashboardRepository(LVIDashboardContext dbContext, IServiceProvider serviceProvider) : base(dbContext)
        {
            _contextUserService = serviceProvider.GetRequiredService<IContextUserService>();
        }

        public IQueryable<TEntity> AsActiveNoTracking()
        {
            var entityType = typeof(TEntity);
            var statusField = entityType.GetProperty("is_deleted");
            if (statusField == null) return base.AsNoTracking();
            var fieldType = Nullable.GetUnderlyingType(statusField.PropertyType) == null ? typeof(bool) : typeof(bool?);
            var parameter = Expression.Parameter(entityType, "x");
            var body = Expression.NotEqual(Expression.PropertyOrField(parameter, statusField.Name), Expression.Constant(true, fieldType));
            var expression = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
            return base.AsNoTracking().Where(expression);
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
