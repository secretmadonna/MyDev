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
            : this("name=Context")
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

        public DbSet<U_Group> Group { get; set; }
        public DbSet<U_GroupRole> GroupRole { get; set; }
        public DbSet<U_GroupUser> GroupUser { get; set; }
        public DbSet<U_Menu> Menu { get; set; }
        public DbSet<U_Operate> Operate { get; set; }
        public DbSet<U_Power> Power { get; set; }
        public DbSet<U_PowerMenu> PowerMenu { get; set; }
        public DbSet<U_PowerOperate> PowerOperate { get; set; }
        public DbSet<U_Role> Role { get; set; }
        public DbSet<U_RolePower> RolePower { get; set; }
        public DbSet<U_User> User { get; set; }
        public DbSet<U_UserRole> UserRole { get; set; }
    }
}