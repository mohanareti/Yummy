using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato.DataModels
{
   public class History
    {
        [Key]
        public int Id { get; set; }

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual MenuItem MenuItem { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual HistorySummary HistorySummary  { get; set; }

    }
}
