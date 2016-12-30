using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DAL
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
        static MyDbContext()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
              Database.SetInitializer<MyDbContext>(null);
        }

        public MyDbContext() : base("EFContext") { }
        public DbSet<TailorMake> TailorMakeData
        {
            get;
            set;
        }
        public DbSet<Tourquery> TourqueryData { get; set; }
        public DbSet<WebPage> WebPages { get; set; }
        public DbSet<TestModel> TestModelData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
