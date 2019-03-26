using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Context
{
    public class ProizvodiContext : DbContext
    {
        public ProizvodiContext() : base("name=ProizvodiContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProizvodiContext>());
        }

        public DbSet<Proizvod> Proizvod { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
