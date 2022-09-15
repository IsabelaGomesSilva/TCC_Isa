using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        public DbSet<Adm> Adm {get; set;}
        public DbSet<Buy> Buy {get; set;}
         public DbSet<BuyDetails> BuyDetails {get; set;}
        public DbSet<Category> Category {get; set;}
        public DbSet<Client> Client {get; set;}
        public DbSet<Order> Order {get; set;}
        public DbSet<OrderDetails> OrderDetails {get; set;}
         public DbSet<Payment> Payment {get; set;}
         public DbSet<Product> Product {get; set;}
         public DbSet<Provider> Provider {get; set;}
           
    }
}