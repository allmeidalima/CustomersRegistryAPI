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
            => options.UseSqlServer("DefaultConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrjContext).Assembly);
        }

    }
}