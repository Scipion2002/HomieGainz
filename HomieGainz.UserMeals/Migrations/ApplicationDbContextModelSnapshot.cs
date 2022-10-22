﻿// <auto-generated />
using System;
using HomieGainz.ApplicationDb.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomieGainz.ApplicationDb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.Property<int>("ExercisesId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutsId")
                        .HasColumnType("int");

                    b.HasKey("ExercisesId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("ExerciseWorkout");
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.MealDb.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Directions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IngredientList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is a simple meal that will give you enough proteins to hit that gym hard!",
                            Directions = "First, get that salmon going, add a little of lemon pepper and that is all you need",
                            IngredientList = "Salmon, spices",
                            Name = "Salmon"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Nice and easy salad that will make you want to have every day",
                            Directions = "First, cut those veggies and then finish it up with putting everything together",
                            IngredientList = "Lettuce, Tomato, Broccoli, Carrot",
                            Name = "Salad"
                        });
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.MealDb.MealPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MealPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This Meal plan will have a lot of veggies and will have a tons of low calorie food",
                            Name = "Low Calories"
                        });
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.UserDb.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<int?>("MealPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MealPlanId");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.WorkoutDb.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RepAmt")
                        .HasColumnType("int");

                    b.Property<int>("SetAmt")
                        .HasColumnType("int");

                    b.Property<string>("TargetMuscle")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.WorkoutDb.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.WorkoutDb.WorkoutPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutPlans");
                });

            modelBuilder.Entity("MealMealPlan", b =>
                {
                    b.Property<int>("MealPlansId")
                        .HasColumnType("int");

                    b.Property<int>("MealsId")
                        .HasColumnType("int");

                    b.HasKey("MealPlansId", "MealsId");

                    b.HasIndex("MealsId");

                    b.ToTable("MealMealPlan");
                });

            modelBuilder.Entity("WorkoutWorkoutPlan", b =>
                {
                    b.Property<int>("WorkoutPlansId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutsId")
                        .HasColumnType("int");

                    b.HasKey("WorkoutPlansId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("WorkoutWorkoutPlan");
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.HasOne("HomieGainz.ApplicationDb.Db.WorkoutDb.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomieGainz.ApplicationDb.Db.WorkoutDb.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.UserDb.User", b =>
                {
                    b.HasOne("HomieGainz.ApplicationDb.Db.MealDb.MealPlan", "MealPlan")
                        .WithMany("Users")
                        .HasForeignKey("MealPlanId");

                    b.HasOne("HomieGainz.ApplicationDb.Db.WorkoutDb.WorkoutPlan", "WorkoutPlan")
                        .WithMany("Users")
                        .HasForeignKey("WorkoutPlanId");

                    b.Navigation("MealPlan");

                    b.Navigation("WorkoutPlan");
                });

            modelBuilder.Entity("MealMealPlan", b =>
                {
                    b.HasOne("HomieGainz.ApplicationDb.Db.MealDb.MealPlan", null)
                        .WithMany()
                        .HasForeignKey("MealPlansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomieGainz.ApplicationDb.Db.MealDb.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkoutWorkoutPlan", b =>
                {
                    b.HasOne("HomieGainz.ApplicationDb.Db.WorkoutDb.WorkoutPlan", null)
                        .WithMany()
                        .HasForeignKey("WorkoutPlansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomieGainz.ApplicationDb.Db.WorkoutDb.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.MealDb.MealPlan", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HomieGainz.ApplicationDb.Db.WorkoutDb.WorkoutPlan", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
