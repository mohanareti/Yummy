using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zomato.DataModels;

namespace Zomato.ViewModels
{
    public class MenuItemsViewModel
    {
        public IEnumerable<MenuItem> MenuItem { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }

        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public HistorySummary HistorySummaries { get; set; }
    }
}