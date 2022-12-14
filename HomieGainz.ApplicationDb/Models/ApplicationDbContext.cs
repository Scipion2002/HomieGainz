using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using HomieGainz.ApplicationDb.Models.Users;
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

            modelBuilder.Entity<MealPlan>().HasData(
               new MealPlan
               {
                   Id = 1,
                   Name = "Low Calories",
                   Description = "This Meal plan will have a lot of veggies and will have a tons of low calorie food",

               }, new MealPlan
               {
                   Id = 2,
                   Name = "High Calories",
                   Description = "This mealplan is to bulk up and also be in shape"
               }, new MealPlan
               {
                   Id = 3,
                   Name = "Medium Calories",
                   Description = "This mealplan is to give you a nice and balanced calorie burn, while giving you enough to build up."
               });

            var meals = modelBuilder.Entity<Meal>().HasData(
               new Meal
               {
                   Id = 1,
                   Name = "Salmon",
                   Description = "This is a simple meal that will give you enough proteins to hit that gym hard!",
                   IngredientList = "Salmon, spices",
                   Directions = "First, get that salmon going, add a little of lemon pepper and that is all you need"
               }, new Meal
               {
                   Id = 2,
                   Name = "Salad",
                   Description = "Nice and easy salad that will make you want to have every day",
                   IngredientList = "Lettuce, Tomato, Broccoli, Carrot",
                   Directions = "First, cut those veggies and then finish it up with putting everything together"
               }, new Meal
               {
                   Id = 3,
                   Name = "Chicken Pesto & Rice",
                   Description = "Easy and fast to make meal :)",
                   IngredientList = "Chicken, pesto sauce, Rice",
                   Directions = "Get that rice started and while that is happening, cook the chicken. Once everything is done, add the pesto sauce and you're done!"
               }, new Meal
               {
                   Id = 4,
                   Name = "Chicken breast & Egg",
                   Description = "Super fast meal to make that will give you the carbohydrates and protein you need",
                   IngredientList = "Chicken Breast, egg",
                   Directions = "Start preparing the chicken and in another pan, cook that egg. Put it together and enjoy! (give the chicken a spice of your choice to make it better!)"
               }, new Meal
               {
                   Id = 5,
                   Name = "Tuna Sandwich",
                   Description = "fast meal that can be to go!",
                   IngredientList = "Tuna, Sandwich bread, mayonaise",
                   Directions = "Put bread on plate, open can of tuna, apply mayo to the bread and put the tuna. Done!"
               }, new Meal
               {
                   Id = 6,
                   Name = "Chicken Chipotle Salad",
                   Description = "Cool chicken Chipotle salad that is nice and easy to make", 
                   IngredientList = "Chicken breast, Chipotle sauce, Salad",
                   Directions = "cook that chicken while putting the salad on a bowl, add the sauce. After all that, cut the chicken breast into square pieces and place them on top of the salad. Done!"
               });

            modelBuilder.Entity<WorkoutPlan>().HasData(
               new WorkoutPlan
               {
                   Id = 1,
                   Name = "Bulk up",
                   Description = "This plan is to help you bulk those muscles and make them bigger! The workouts will mostly be using heavy weights and doing exercises with them"
               }, new WorkoutPlan
               {
                   Id = 2,
                   Name = "Tune up",
                   Description = "This plan is filled with workouts that will make your muscles go in shock and it will also have mostly body-weight exercises"
               }, new WorkoutPlan
               {
                   Id = 3,
                   Name = "Slim Down",
                   Description = "This plan is made to make you lower your weight, get ready for some cardio workouts!"
               });

            modelBuilder.Entity<Exercise>().HasData(
               new Exercise
               {
                   Id = 1,
                   Name = "Push ups",
                   TargetMuscle = "biceps/triceps",
                   SetAmt = 3,
                   RepAmt = 10,
                   Description = "This exercise is one of the essentials, it will help you have a better control of your own weight and it will tune you up too!"
               }, new Exercise
               {
                   Id = 2,
                   Name = "Jumping Jacks",
                   TargetMuscle = "Legs",
                   SetAmt = 3,
                   RepAmt = 35,
                   Description = "This exercise gives you the feeling of running but without it!"
               }, new Exercise
               {
                   Id = 3,
                   Name = "Sit-ups",
                   TargetMuscle = "bottom abdominals",
                   SetAmt = 3,
                   RepAmt = 15,
                   Description = "This exercise helps your bottom abs"
               }, new Exercise
               {
                   Id = 4,
                   Name = "pull-ups",
                   TargetMuscle = "back",
                   SetAmt = 3,
                   RepAmt = 5,
                   Description = "This exercise helps your back get stronger and more defined"
               }, new Exercise
               {
                   Id = 5,
                   Name = "curls",
                   TargetMuscle = "biceps",
                   SetAmt = 3,
                   RepAmt = 12,
                   Description = "This exercise helps your biceps break down and re-build stronger"
               }, new Exercise
               {
                   Id = 6,
                   Name = "Leg Press",
                   TargetMuscle = "legs",
                   SetAmt = 3,
                   RepAmt = 12,
                   Description = "This exercise helps your biceps break down and re-build stronger, it's on you the weight of the plates"
               });

            modelBuilder.Entity<User>().HasData(
            new User() 
            { 
                Id = 1,
                Username = "Scipion2002", 
                Password = "TestPass", 
                Email = "aturro@student.neumont.edu",
                Age = 19, 
                Weight = 164, 
                Height = 6.1
            },
            new User() 
            {
                Id = 2,
                Username = "DNgo-Neumont", 
                Password = "DavidPass",
                Email = "aturro@student.neumont.edu",
                Age = 20, 
                Weight = 156, 
                Height = 6 
            },
            new User() 
            {
                Id = 3,
                Username = "Rxittles", 
                Password = "RobPass",
                Email = "rbrunney@student.neumont.edu",
                Age = 21, 
                Weight = 135, 
                Height = 6 
            });

            modelBuilder.Entity<Workout>().HasData(
            new Workout()
            {
                Id = 1,
                Name = "Upper Body" 
            },
            new Workout() 
            {
                Id = 2,
                Name = "Lower Body" 
            },
            new Workout()
            {
                Id = 3,
                Name = "Cardio"
            });
            modelBuilder.Entity<User>().HasMany(u => u.Friends);
        }

        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
