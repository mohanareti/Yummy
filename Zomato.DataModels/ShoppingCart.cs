using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato.DataModels
{
   public class ShoppingCart
    {

        public int Id { get; set; }

        public string ApplicationUserId { get; set; }


        //[ForeignKey("ApplicationUserId")]
        //public ApplicationUser ApplicationUser { get; set; }

        public int MenuItemId { get; set; }


        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }



        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int Quantity { get; set; }
    }
}
