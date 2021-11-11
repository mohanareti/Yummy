using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato.Data
{
    class Category
    {
        [Key]
        public int CId { get; set; }

        [Required]
        public string CName { get; set; }
    }
}
