using MyDev.DataAccess.Db.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Context
{
    public class CommonDBContext : DbContext
    {
        public CommonDBContext()
            : this("DefaultConnection")
        { }
        public CommonDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<CommonDBContext>(null);
            DbInterception.Add(new CommonDBInterceptor());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约
        }

        public DbSet<Rbac_User> RbacUser { get; set; }
    }
}