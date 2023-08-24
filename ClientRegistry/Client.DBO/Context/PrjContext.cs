using Client.DBO.Models;
using Microsoft.EntityFrameworkCore;

namespace Client.DBO.Context
{
    public class PrjContext : DbContext
    {

        public PrjContext() { }

        public PrjContext(DbContextOptions<PrjContext> options) : base(options)
        {
        }

        public DbSet<RegisteredCustomer> RegisteredCustomer { get; set; }

        public DbSet<CustomerAdresses> CustomerAdresses { get; set; }

        public DbSet<CustomerEmails> CustomerEmails { get; set; }

        public DbSet<CustomerPhoneNumbers> CustomerPhoneNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=sqlserver;Database=teste;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAdresses>()
            .HasOne(ca => ca.Clients)
            .WithMany(c => c.CustomerAdresses)
            .HasForeignKey(ca => ca.IdClient);

            modelBuilder.Entity<CustomerEmails>()
                .HasOne(ce => ce.Clients)
                .WithMany(c => c.CustomerEmails)
                .HasForeignKey(ce => ce.IdClient);

            modelBuilder.Entity<CustomerPhoneNumbers>()
                .HasOne(cpn => cpn.Clients)
                .WithMany(c => c.CustomerPhoneNumbers)
                .HasForeignKey(cpn => cpn.IdClient);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrjContext).Assembly);
        }

    }
}