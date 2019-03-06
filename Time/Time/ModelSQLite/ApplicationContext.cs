using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Time.ModelSQLite;

namespace Time
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<GreanSite> GreanSites { get; set; }
        public DbSet<RedSite> RedSites { get; set; }
        public DbSet<StatisticSite> StatisticSites { get; set; }
        public DbSet<OneTimeBreakModel> OneTimeBreakModels { get; set; }
        public DbSet<ShortBreakModel> ShortBreakModels { get; set; }
        public DbSet<BigBreakModel> BigBreakModels { get; set; }      
        public DbSet<Sound> Sounds { get; set; }
    }
}
