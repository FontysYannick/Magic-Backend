using Magic_Logic.Classes;
using Microsoft.EntityFrameworkCore;

namespace Magic.Controllers
{
    public class Magic_Product_Context : DbContext
    {
        public Magic_Product_Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
