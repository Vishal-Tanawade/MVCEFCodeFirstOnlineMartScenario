﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCEFCodeFirstOnlineMartScenario.Models
{
    public class SecurityQuestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuId { get; set; }

        [DisplayName("Select security question")]
        [Required(ErrorMessage = "Security Question should not be blank")]
        public string Question { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}