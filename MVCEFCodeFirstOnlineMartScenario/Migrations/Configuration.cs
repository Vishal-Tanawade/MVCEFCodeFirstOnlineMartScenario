namespace MVCEFCodeFirstOnlineMartScenario.Migrations
{
    using MVCEFCodeFirstOnlineMartScenario.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCEFCodeFirstOnlineMartScenario.Models.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCEFCodeFirstOnlineMartScenario.Models.AppDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.UserTypes.AddOrUpdate
    (
   new UserType() { UserTypeID = 1, UserTypeName = "Admin" },
   new UserType() { UserTypeID = 2, UserTypeName = "User" },
   new UserType() { UserTypeID = 3, UserTypeName = "Manager" }
   );
            context.SecurityQuestions.AddOrUpdate(
            new SecurityQuestion() { QuId = 1, Question = "What is your mother's maiden name?" },
            new SecurityQuestion() { QuId = 2, Question = "What is the name of your first pet?" },
            new SecurityQuestion() { QuId = 3, Question = "What was your first car?" },
            new SecurityQuestion() { QuId = 4, Question = "What elementary school did you attend?" },
            new SecurityQuestion() { QuId = 5, Question = "What is the name of the town where you were born?" },
            new SecurityQuestion() { QuId = 6, Question = "When you were young, what did you want to be when you grew up?" },
            new SecurityQuestion() { QuId = 7, Question = "Who was your childhood hero?" },
            new SecurityQuestion() { QuId = 8, Question = "Where was your best family vacation as a kid?" }
            );
            context.Categories.AddOrUpdate(
            new Category() { CategoryID = 1, CategoryName = "E-readers" },
            new Category() { CategoryID = 2, CategoryName = "ebooks" },
            new Category() { CategoryID = 3, CategoryName = "computers" },
            new Category() { CategoryID = 4, CategoryName = "laptop" },
            new Category() { CategoryID = 5, CategoryName = "toys" },
            new Category() { CategoryID = 6, CategoryName = "trimmers" },
            new Category() { CategoryID = 7, CategoryName = "watches" },
            new Category() { CategoryID = 8, CategoryName = "fashion jewellery" },
            new Category() { CategoryID = 9, CategoryName = "home" },
            new Category() { CategoryID = 10, CategoryName = "kitchen" },
            new Category() { CategoryID = 11, CategoryName = "small appliances" },
            new Category() { CategoryID = 12, CategoryName = "beauty" },
            new Category() { CategoryID = 13, CategoryName = "Sports" },
            new Category() { CategoryID = 14, CategoryName = "Fitness & Outdoors" }
             );
        }
    }
}
