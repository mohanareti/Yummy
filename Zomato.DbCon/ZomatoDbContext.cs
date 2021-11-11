using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.


namespace Zomato.DbCon
{
    class ZomatoDbContext:DbContext
    {
        public ZomatoDbContext():base("fod")
        {

        }
        public DbSet<Category> Categories{ get; set; }
    }
}
