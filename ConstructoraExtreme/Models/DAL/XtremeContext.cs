using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ConstructoraExtreme.Models.DAL
{
    public class XtremeContext : DbContext
    {
        public XtremeContext(DbContextOptions<XtremeContext> options) : base(options)
        {
        }

        // Define un DbSet llamado "Customers" que representa una tabla de clientes en la base de datos.
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DocumentTypesCatalog> DocumentTypesCatalogs { get; set; }
        public DbSet<DepartmentsCatalog> DepartmentsCatalogs { get; set; }
        public DbSet<MunicipalitiesCatalog> MunicipalitiesCatalogs { get; set; }
        public DbSet<EconomicActivitiesCatalog> EconomicActivitiesCatalogs { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<PersonReferences> PersonReferences { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<RentalDetails> RentalDetails { get; set; }
        public DbSet<RentalPayments> RentalPayments { get; set; }
        public DbSet<PaymentHistory> paymentHistories { get; set; }
        public DbSet<MaintenanceTypes> MaintenanceTypes { get; set; }
        public DbSet<MaintenanceRecords> MaintenanceRecords { get; set; }
        public DbSet<MaintenanceTasks> MaintenanceTasks { get; set; }
        public DbSet<MaintenanceParts> MaintenanceParts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Images> Images { get; set; }


    }

}
