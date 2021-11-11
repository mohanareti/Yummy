using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato.DataModels
{
    public class Category
    {
        [Key]
        public int CId { get; set; }

        [Required]
        [Display(Name ="Category")]
        public string CName { get; set; }
    }
}
