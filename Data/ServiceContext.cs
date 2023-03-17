using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class ServiceContext : DbContext
    {

        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<OrderItem> Orders { get; set; }
        public DbSet<PersonItem> Persons { get; set; }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<CustomerItem> Customers { get; set; }
        public DbSet<RolItem> Roles { get; set; }
        public DbSet<CustomerTypeItem> CustomerTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductItem>()
            .ToTable("Products");

            builder.Entity<OrderItem>(order =>
            {
                order.ToTable("Order");
                order.HasOne<OrderItem>().WithMany().HasForeignKey(p => p.IdProduct);
                order.HasOne<CustomerItem>().WithMany().HasForeignKey(p => p.IdCustomer);
            });

            builder.Entity<PersonItem>()
            .ToTable("Persons");

            builder.Entity<UserItem>(usuario =>
            {
                usuario.ToTable("Users");
                usuario.HasOne<PersonItem>().WithMany().HasForeignKey(u => u.IdPerson);
                usuario.HasIndex(c => c.IdPerson).IsUnique();
                usuario.HasOne<RolItem>().WithMany().HasForeignKey(u => u.IdRol);

            });

            builder.Entity<CustomerItem>(customer =>
            {
                customer.ToTable("Customers");
                customer.HasOne<PersonItem>().WithMany().HasForeignKey(c => c.IdPerson);
                customer.HasIndex(c => c.IdPerson).IsUnique();

                customer.HasOne<RolItem>().WithMany().HasForeignKey(c => c.IdRol);
                customer.HasOne<CustomerTypeItem>().WithMany().HasForeignKey(c => c.IdCustomerType);
            });

            builder.Entity<RolItem>()
            .ToTable("Roles");

            builder.Entity<CustomerTypeItem>()
            .ToTable("CustomerTypes");

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));


            return new ServiceContext(optionsBuilder.Options);
        }

    }


}
