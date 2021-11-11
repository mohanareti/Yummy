using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DataModels;

namespace Zomato.DataLayer
{
    public class ApplicatioDbContext:DbContext
    {
        public ApplicatioDbContext():base("fon")
        {

        }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<HistorySummary> HistorySummaries { get; set; }
        public DbSet<History> Histories { get; set; }

    }
}
