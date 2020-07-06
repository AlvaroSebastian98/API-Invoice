using Domain;
using System.Data.Entity;


namespace Infraestructure
{
   public class InvoiceContext : DbContext
    {
        public InvoiceContext() : base("name = MyContextDB")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }



    }
}
