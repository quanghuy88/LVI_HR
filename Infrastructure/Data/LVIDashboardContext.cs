using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public partial class LVIDashboardContext : DbContext
    {
        public LVIDashboardContext()
        {
        }

        public LVIDashboardContext(DbContextOptions<LVIDashboardContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
