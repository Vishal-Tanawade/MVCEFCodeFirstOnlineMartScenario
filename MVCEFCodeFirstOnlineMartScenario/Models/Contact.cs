using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEFCodeFirstOnlineMartScenario.Models
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        [DisplayName("User")]
        [Required(ErrorMessage = "User should not be blank")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [DisplayName("Flat Number | House No ")]
        [Required(ErrorMessage = "Flat Number | House No should not be blank")]
        public string HouseNo { get; set; }
        [DisplayName("Area")]
        [Required(ErrorMessage = "Area should not be blank")]
        public string Area { get; set; }
        public string Landmark { get; set; }
        [DisplayName("City")]
        [Required(ErrorMessage = "City should not be blank")]
        public string City { get; set; }

        [DisplayName("Pin Code")]
        [RegularExpression(@"^[1-9]{1}[0-9]{5}$")]
        [Required(ErrorMessage = "Pin Code should not be blank")]
        public int PinCode { get; set; }


        [DisplayName("State")]
        [Required(ErrorMessage = "State should not be blank")]
        public string State { get; set; }
        [DisplayName("Mark as Default Delivery Address")]
        public bool DefaultAddress { get; set; }

        public virtual User User { get; set; }
    }
}