using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base.LVIDashboard
{
    public interface ILVIDashboardRepository<TEntity> : IRepository<TEntity>, IInjection where TEntity : class
    {
        IQueryable<TEntity> AsActiveNoTracking();
    }
}
