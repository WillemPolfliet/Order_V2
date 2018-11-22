using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Order_V2.Domain.Users.Attributes;
using Order_V2.Domain.Users.Customers;

namespace Order_V2.Data
{
    public class OrderDbContext : DbContext
    {
        private readonly string ConnectionString;
        private readonly ILoggerFactory LoggerFactory;


        public virtual DbSet<Customer> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        public OrderDbContext(string connectionString, ILoggerFactory loggerFactory = null)
        {
            ConnectionString = connectionString;
            LoggerFactory = loggerFactory;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            if (LoggerFactory != null)
            { optionsBuilder.UseLoggerFactory(LoggerFactory); }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            GenerateEntityDB_Customer(modelBuilder);
            GenerateEntityDB_City(modelBuilder);
            GenerateEntityDB_PhoneNumber(modelBuilder);

            ForeignKeysFrom_Cities_Address(modelBuilder);
            ForeignKeysFrom_Customers_PhoneNumber(modelBuilder);

            
            base.OnModelCreating(modelBuilder);

        }

        private static void GenerateEntityDB_Customer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                            .ToTable("Customers", "Users")
                            .HasKey(U => U.CustomerID);
            modelBuilder.Entity<Customer>()
                .Property(d => d.CustomerID).HasColumnName("Customer_ID");
            modelBuilder.Entity<Customer>()
                .Property(d => d.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<Customer>()
                .Property(d => d.LastName).HasColumnName("LastName");
            modelBuilder.Entity<Customer>()
                .Property(d => d.Login_Email).HasColumnName("Login_Email");
            modelBuilder.Entity<Customer>()
                .OwnsOne(m => m.Address, a =>
                {
                    a.Property(b => b.StreetName).HasColumnName("StreetName");
                    a.Property(s => s.StreetNumber).HasColumnName("StreetNumber");
                    a.Property(z => z.ZIP).HasColumnName("City_ZIP");
                });
            modelBuilder.Entity<Customer>()
                .Property(d => d.RegistrationDate).HasColumnName("RegistrationDate");
            modelBuilder.Entity<Customer>()
                .Property(d => d.DateEdited).HasColumnName("DateEdited");
            modelBuilder.Entity<Customer>()
                 .Property(d => d.Login_HashPass).HasColumnName("Login_HashPass");
        }
        private static void GenerateEntityDB_City(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .ToTable("Cities", "Users")
                .HasKey(c => c.ZIP);

            modelBuilder.Entity<City>()
                .Property(c => c.ZIP).HasColumnName("City_ZIP");
            modelBuilder.Entity<City>()
                .Property(c => c.CityName).HasColumnName("CityName");
            modelBuilder.Entity<City>()
                .Property(c => c.CountryName).HasColumnName("CountryName");
        }
        private static void GenerateEntityDB_PhoneNumber(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>()
                .ToTable("PhoneNumbers", "Users")
                .HasKey(ph => new
                {
                    ph.CustomerID,
                    ph.PhoneNumberValue
                });

            modelBuilder.Entity<PhoneNumber>()
                .Property(lp => lp.CustomerID).HasColumnName("Customer_ID");
            modelBuilder.Entity<PhoneNumber>()
                .Property(lp => lp.PhoneNumberValue).HasColumnName("PhoneNumber");          
        }
        private static void ForeignKeysFrom_Cities_Address(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.ZIP)
                .IsRequired();
        }
        private static void ForeignKeysFrom_Customers_PhoneNumber(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>()
              .HasOne(ph => ph.Customer)
              .WithMany(m => m.ListOfPhones)
              .HasForeignKey(ph => ph.CustomerID)
              .IsRequired();
        }        
    }
}
