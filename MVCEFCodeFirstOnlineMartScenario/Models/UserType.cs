using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCEFCodeFirstOnlineMartScenario.Models
{
    public class UserType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTypeID { get; set; }
        [DisplayName("User Type")]
        [Required(ErrorMessage = "Login type should not be blank eg. Manager / User ")]
        public string UserTypeName { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}