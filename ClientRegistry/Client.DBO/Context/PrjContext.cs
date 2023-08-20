using Client.DBO.Models;
using Microsoft.EntityFrameworkCore;

namespace Client.DBO.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<ClientsAddress> ClientsAddress { get; set; }

        public DbSet<ClientsEmail> ClientsEmail { get; set; }

        public DbSet<ClientsPhoneNumber> ClientsPhoneNumbers { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }


            }

            return base.SaveChanges();
        }
    }
}