using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato.DataModels
{
   public class HistorySummary
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double OrderTotal { get; set; }
        [Required]
        public DateTime PickUpTime { get; set; }
        [Required]
        public DateTime PickUpDate { get; set; }
        [Required]
        public string PaymentStatus { get; set; }
        [Required]
        public string TransactionId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }

    }
}
