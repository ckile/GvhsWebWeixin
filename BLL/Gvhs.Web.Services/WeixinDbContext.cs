using Gvhs.Web.DataContracts;
using Microsoft.Data.Entity;

namespace Gvhs.Web.Services
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class WeixinDbContext : DbContext
    {
        // 数据库设计时启用
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 在正式运行时注释此行
            optionsBuilder.UseSqlServer("Data Source=gvsserver;Initial Catalog=Weixin;uid=sa;pwd=masterkey;MultipleActiveResultSets=True");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<WeixinConfig> WeixinConfig { get; set; }

        public DbSet<EGuest> Guest { get; set; }

        public DbSet<EReservation> Reservation { get; set; }

        public DbSet<EHotel> Hotel { get; set; }

        public DbSet<User> User { get; set; }

    }
}
