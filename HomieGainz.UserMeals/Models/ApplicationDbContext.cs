using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace HomieGainz.ApplicationDb.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MealPlan>().HasData(new MealPlan
            {
                Id = 1,
                Name = "Low Calories",
                Description = "This Meal plan will have a lot of veggies and will have a tons of low calorie food"

            }, new MealPlan
            {
                Id = 2,
                Name = "High Calories",
                Description = "This mealplan is to bulk up and also be in shape"
            });

            modelBuilder.Entity<Meal>().HasData(new Meal
            {
                Id = 1,
                Name = "Salmon",
                Description = "This is a simple meal that will give you enough proteins to hit that gym hard!",
                IngredientList = "Salmon, spices",
                Directions = "First, get that salmon going, add a little of lemon pepper and that is all you need"
            }, new Meal
            {
                Id= 2,
                Name = "Salad",
                Description = "Nice and easy salad that will make you want to have every day",
                IngredientList = "Lettuce, Tomato, Broccoli, Carrot",
                Directions = "First, cut those veggies and then finish it up with putting everything together"
            });

            modelBuilder.Entity<WorkoutPlan>().HasData(new WorkoutPlan 
            { 
                Id = 1, 
                Name = "Bulk up",
                Description = "This plan is to help you bulk those muscles and make them bigger! The workouts will mostly be using heavy weights and doing exercises with them"
            }, new WorkoutPlan 
            { 
                Id = 2,
                Name = "Tune up",
                Description = "This plan is filled with workouts that will make your muscles go in shock and it will also have mostly body-weight exercises"
            });
            

        }
        public DbSet<User> Users { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
