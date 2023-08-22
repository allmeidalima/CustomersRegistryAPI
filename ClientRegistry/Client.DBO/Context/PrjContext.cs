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

        public DbSet<Clients> Clients { get; set; }

        public DbSet<ClientsAddress> ClientsAdresses { get; set; }

        public DbSet<ClientsEmail> ClientsEmails { get; set; }

        public DbSet<ClientsPhoneNumber> ClientsPhoneNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=teste;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientsAddress>()
            .HasOne(ca => ca.Clients)
            .WithMany(c => c.Addresses)
            .HasForeignKey(ca => ca.IdClient);

            modelBuilder.Entity<ClientsEmail>()
                .HasOne(ce => ce.Clients)
                .WithMany(c => c.Emails)
                .HasForeignKey(ce => ce.IdClient);

            modelBuilder.Entity<ClientsPhoneNumber>()
                .HasOne(cpn => cpn.Clients)
                .WithMany(c => c.PhoneNumbers)
                .HasForeignKey(cpn => cpn.IdClient);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrjContext).Assembly);
        }

    }
}