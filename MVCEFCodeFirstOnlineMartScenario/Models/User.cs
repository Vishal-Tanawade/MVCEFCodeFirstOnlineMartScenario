using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEFCodeFirstOnlineMartScenario.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [ForeignKey("UserType")]
        public int UserTypeID { get; set; }
        [Required(ErrorMessage = "Please Enter Name e.g. Aaron")]
        [DisplayName("First Name")]
        [StringLength(30, MinimumLength = 5)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Name e.g. Hawkins")]
        [DisplayName("Last Name")]
        [StringLength(30, MinimumLength = 5)]
        [RegularExpression("^[A-Za-z]{4,30}$")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Name e.g. Aaronkins12345")]
        [DisplayName("User Name")]
        [StringLength(30, MinimumLength = 8)]
        [RegularExpression("^[A-Za-z1-9]{8,30}$")]
        public string UserName { get; set; }
        public DateTime Dob { get; set; }
        [DisplayName("Phone Number")]
        //(372) 587-2335
        [RegularExpression(@"^\([0-9]{3}\) [1-9]{3}-[1-9]{4}$")]
        [Required(ErrorMessage = "Phone number should not be blank eg. (372) 587-2335")]
        public string PhoneNo { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Enter Email Address")]
        public string Email { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password should not be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Question should not be blank")]
        [ForeignKey("SecurityQuestion")]
        public int QuId { get; set; }
        [DisplayName("Security Answer")]
        [Required(ErrorMessage = "Security should not be blank")]
        public string Answer { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual SecurityQuestion SecurityQuestion { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }

    }
}