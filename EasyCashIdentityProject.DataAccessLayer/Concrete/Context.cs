using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-141UAGI;initial catalog=EasyCashDb;integrated Security=true;TrustServerCertificate=True");
        }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
        public DbSet<ElectricBill> ElectricBills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // CustomerAccountProcess entity's SenderCustomer navigation property with a one-to-many relationship
            builder.Entity<CustomerAccountProcess>()
                // SenderCustomer ile ilişkilendirilmiş olan CustomerAccountProcess nesnesini belirtir
                .HasOne(x => x.SenderCustomer)
                // SenderCustomer'ın birden fazla CustomerAccountProcess nesnesine sahip olabileceğini belirtir
                .WithMany(y => y.CustomerSender)
                // SenderID alanını dış anahtar olarak ayarlar
                .HasForeignKey(z => z.SenderID)
                // Silme davranışını ayarlar; SenderCustomer silindiğinde, ilgili CustomerAccountProcess nesneleri null olarak ayarlanır
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.ReceiverCustomer)
                .WithMany(y => y.CustomerReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(builder);
        }

    }
}
