using MVCEFCodeFirstOnlineMartScenario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCEFCodeFirstOnlineMartScenario
{
    public class AppDBContext: DbContext
    {
        public AppDBContext() : base("name=OnlineMartConnnectionString")
        {

        }


        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}