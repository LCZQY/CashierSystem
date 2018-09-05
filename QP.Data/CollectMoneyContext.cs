using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QP.Cashier_Model.CreateEntity;

namespace QP.Cashier_Data
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class CollectMoneyContext : DbContext
    {
        public CollectMoneyContext() { }


        public DbSet<Departments> Departments { get; set; }
        public DbSet<CardMembers> CardMembers { get; set; }
        public DbSet<Consumes> Consumes { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public DbSet<Shops> Shops { get; set; }
        public DbSet<Authoritys> Authoritys { get; set; }
        public DbSet<Staffs> Staffs { get; set; }
        public DbSet<Categorys> Categorys { get; set; }

        public DbSet<Certificates> Certificates { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Inventorys> Inventorys { get; set; }
        public DbSet<Products> Products { get; set; }

        public DbSet<ProjectTypes> ProjectTypes { get; set; }
        public DbSet<Wages> Wages { get; set; }
        public DbSet<Navs> Navs { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //单独一种约束，其维护性更加强大
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
              .Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 重大问题？？？ 采用Code frist的方式 ， 直接引起中文乱码？？？


            /// 知识: 
            ///  可能是该字段（date/datetime）的值默认缺省值为：0000-00-00/0000-00-00 00:00:00,这样的数据读出来转换成System.DateTime时就会有问题；
            ///  Convert Zero Datetime=True;Allow Zero Datetime=True;连接串中添加
            optionsBuilder.UseMySQL("Data Source = localhost; Database = Casher; User ID = root; Password = 'root'; pooling = true; CharSet = utf8; port = 3306; sslmode = none;Convert Zero Datetime=True;Allow Zero Datetime=True;");
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=myDataBase;User Id=sa;Password=sasa;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
