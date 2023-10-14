using Microsoft.EntityFrameworkCore;
using Products_Record_MAnagement_System.Entity;
using System.Collections.Generic;

namespace Products_Record_MAnagement_System.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
