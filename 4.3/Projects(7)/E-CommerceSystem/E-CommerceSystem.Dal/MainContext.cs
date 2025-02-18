using E_CommerceSystem.Dal.Entities;
using E_CommerceSystem.Dal.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSystem.Dal;

public class MainContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts  { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }


    public MainContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CartProductConfigurations());
        modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
    }
}
