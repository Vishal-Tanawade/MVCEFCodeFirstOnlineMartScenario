using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCEFCodeFirstOnlineMartScenario.Models
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartID { get; set; }

        [ForeignKey("User")]
        [DisplayName("Booking Person")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Select Product")]
        [DisplayName("Product")]
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Enter Quantity to purchase ")]
        [DisplayName("Quantity to purchase")]
        public int PurchaseQTY { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}