﻿using HomieGainz.ApplicationDb.Db.MealDb;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);

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
            

        }
        public DbSet<User> Users { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
