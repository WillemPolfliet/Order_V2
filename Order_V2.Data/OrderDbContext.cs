using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Order_V2.Domain.Users;
using Order_V2.Domain.Users.Administrators;
using Order_V2.Domain.Users.Attributes;
using Order_V2.Domain.Users.Customers;

namespace Order_V2.Data
{
    public class OrderDbContext : DbContext
    {
        private readonly string ConnectionString;
        private readonly ILoggerFactory LoggerFactory;


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Workplace> Workplaces { get; set; }

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
            GenerateEntityDB_Users(modelBuilder);
            GenerateEntityDB_Administrators(modelBuilder);
            GenerateEntityDB_Customers(modelBuilder);

            GenerateEntityDB_Cities(modelBuilder);
            ForeignKeysFrom_Cities_Address(modelBuilder);

            GenerateEntityDB_Workplaces(modelBuilder);
            ForeignKeysFrom_Workplace_Administrator(modelBuilder);

            GenerateEntityDB_PhoneNumbers(modelBuilder);
            ForeignKeysFrom_Users_PhoneNumber(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private static void GenerateEntityDB_Users(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                            .ToTable("Users", "Users")
                            .HasKey(U => U.User_ID);

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator");


            modelBuilder.Entity<User>()
                .Property(user => user.User_ID).HasColumnName("User_ID");
            modelBuilder.Entity<User>()
               .Property(user => user.Discriminator).HasColumnName("Discriminator");
            modelBuilder.Entity<User>()
                .Property(user => user.RegistrationDate).HasColumnName("RegistrationDate");
            modelBuilder.Entity<User>()
                .Property(user => user.DateEdited).HasColumnName("DateEdited");
            modelBuilder.Entity<User>()
                .Property(user => user.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<User>()
                .Property(user => user.LastName).HasColumnName("LastName");
            modelBuilder.Entity<User>()
                .Property(user => user.Login_Email).HasColumnName("Login_Email");
            modelBuilder.Entity<User>()
                .OwnsOne(user => user.UserSecurity, US =>
                {
                    US.Property(us => us.Login_HashPass).HasColumnName("Login_HashPass");
                    US.Property(us => us.Login_Salt).HasColumnName("Login_Salt");
                });
        }
        private static void GenerateEntityDB_Customers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasBaseType<User>();

            modelBuilder.Entity<Customer>()
                .OwnsOne(Customer => Customer.Address, a =>
             {
                 a.Property(Address => Address.StreetName).HasColumnName("Customer_StreetName");
                 a.Property(Address => Address.StreetNumber).HasColumnName("Customer_StreetNumber");
                 a.Property(Address => Address.City_ZIP).HasColumnName("Customer_City_ZIP");
             });

        }
        private static void GenerateEntityDB_Administrators(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .HasBaseType<User>();
            
            modelBuilder.Entity<Administrator>()
                .Property(admin => admin.Workplace_FK).HasColumnName("Admin_Workplace_ID");
        }
        private static void GenerateEntityDB_Workplaces(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workplace>()
                           .ToTable("Workplaces", "Users")
                            .HasKey(wp => wp.Workplace_ID);

            modelBuilder.Entity<Workplace>()
                .Property(wp => wp.Workplace_ID).HasColumnName("Workplace_ID");
            modelBuilder.Entity<Workplace>()
                 .Property(wp => wp.OfficeName).HasColumnName("OfficeName");
            modelBuilder.Entity<Workplace>()
                .OwnsOne(Customer => Customer.Address, a =>
                {
                    a.Property(Address => Address.StreetName).HasColumnName("StreetName");
                    a.Property(Address => Address.StreetNumber).HasColumnName("StreetNumber");
                    a.Property(Address => Address.City_ZIP).HasColumnName("City_ZIP");
                });
        }
        private static void GenerateEntityDB_Cities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .ToTable("Cities", "Users")
                .HasKey(c => c.City_ZIP);

            modelBuilder.Entity<City>()
                .Property(c => c.City_ZIP).HasColumnName("City_ZIP");
            modelBuilder.Entity<City>()
                .Property(c => c.CityName).HasColumnName("CityName");
            modelBuilder.Entity<City>()
                .Property(c => c.CountryName).HasColumnName("CountryName");
        }
        private static void GenerateEntityDB_PhoneNumbers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>()
                .ToTable("PhoneNumbers", "Users")
                .HasKey(ph => new
                {
                    ph.User_ID,
                    ph.PhoneNumberValue
                });

            modelBuilder.Entity<PhoneNumber>()
                .Property(lp => lp.User_ID).HasColumnName("User_ID");
            modelBuilder.Entity<PhoneNumber>()
                .Property(lp => lp.PhoneNumberValue).HasColumnName("PhoneNumber");
        }

        private static void ForeignKeysFrom_Cities_Address(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.City_ZIP)
                .IsRequired();
        }
        private static void ForeignKeysFrom_Workplace_Administrator(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .HasOne(adm => adm.Workplace)
                .WithOne(wp => wp.Administrator)
                .HasForeignKey<Administrator>(adm => adm.Workplace_FK);
        }
        private static void ForeignKeysFrom_Users_PhoneNumber(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>()
              .HasOne(ph => ph.User)
              .WithMany(m => m.ListOfPhones)
              .HasForeignKey(ph => ph.User_ID)
              .IsRequired();
        }
    }
}
