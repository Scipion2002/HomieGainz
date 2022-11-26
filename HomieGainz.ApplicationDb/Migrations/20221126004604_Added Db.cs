using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomieGainz.ApplicationDb.Migrations
{
    public partial class AddedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TargetMuscle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetAmt = table.Column<int>(type: "int", nullable: false),
                    RepAmt = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    ImgLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngredientList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Directions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealMealPlan",
                columns: table => new
                {
                    MealPlansId = table.Column<int>(type: "int", nullable: false),
                    MealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealMealPlan", x => new { x.MealPlansId, x.MealsId });
                    table.ForeignKey(
                        name: "FK_MealMealPlan_MealPlans_MealPlansId",
                        column: x => x.MealPlansId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealMealPlan_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    MealPlanId = table.Column<int>(type: "int", nullable: true),
                    WorkoutPlanId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_MealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "MealPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkout",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    WorkoutsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkout", x => new { x.ExercisesId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_ExerciseWorkout_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkout_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutWorkoutPlan",
                columns: table => new
                {
                    WorkoutPlansId = table.Column<int>(type: "int", nullable: false),
                    WorkoutsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutWorkoutPlan", x => new { x.WorkoutPlansId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_WorkoutWorkoutPlan_WorkoutPlans_WorkoutPlansId",
                        column: x => x.WorkoutPlansId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutWorkoutPlan_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<int>(type: "int", nullable: true),
                    ToUserId = table.Column<int>(type: "int", nullable: true),
                    WorkoutId = table.Column<int>(type: "int", nullable: true),
                    Accepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Challenges_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Challenges_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<int>(type: "int", nullable: true),
                    ToFriendId = table.Column<int>(type: "int", nullable: true),
                    Accepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friendships_Users_ToFriendId",
                        column: x => x.ToFriendId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Name", "RepAmt", "SetAmt", "TargetMuscle", "Video" },
                values: new object[,]
                {
                    { 1, "This exercise is one of the essentials, it will help you have a better control of your own weight and it will tune you up too!", "Push ups", 10, 3, "biceps/triceps", null },
                    { 2, "This exercise gives you the feeling of running but without it!", "Jumping Jacks", 35, 3, "Legs", null },
                    { 3, "This exercise helps your bottom abs", "Sit-ups", 15, 3, "bottom abdominals", null },
                    { 4, "This exercise helps your back get stronger and more defined", "pull-ups", 5, 3, "back", null },
                    { 5, "This exercise helps your biceps break down and re-build stronger", "curls", 12, 3, "biceps", null },
                    { 6, "This exercise helps your biceps break down and re-build stronger, it's on you the weight of the plates", "Leg Press", 12, 3, "legs", null }
                });

            migrationBuilder.InsertData(
                table: "MealPlans",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This Meal plan will have a lot of veggies and will have a tons of low calorie food", "Low Calories" },
                    { 2, "This mealplan is to bulk up and also be in shape", "High Calories" },
                    { 3, "This mealplan is to give you a nice and balanced calorie burn, while giving you enough to build up.", "Medium Calories" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Description", "Directions", "ImgLink", "IngredientList", "Name" },
                values: new object[,]
                {
                    { 1, "This is a simple meal that will give you enough proteins to hit that gym hard!", "First, get that salmon going, add a little of lemon pepper and that is all you need", null, "Salmon, spices", "Salmon" },
                    { 2, "Nice and easy salad that will make you want to have every day", "First, cut those veggies and then finish it up with putting everything together", null, "Lettuce, Tomato, Broccoli, Carrot", "Salad" },
                    { 3, "Easy and fast to make meal :)", "Get that rice started and while that is happening, cook the chicken. Once everything is done, add the pesto sauce and you're done!", null, "Chicken, pesto sauce, Rice", "Chicken Pesto & Rice" },
                    { 4, "Super fast meal to make that will give you the carbohydrates and protein you need", "Start preparing the chicken and in another pan, cook that egg. Put it together and enjoy! (give the chicken a spice of your choice to make it better!)", null, "Chicken Breast, egg", "Chicken breast & Egg" },
                    { 5, "fast meal that can be to go!", "Put bread on plate, open can of tuna, apply mayo to the bread and put the tuna. Done!", null, "Tuna, Sandwich bread, mayonaise", "Tuna Sandwich" },
                    { 6, "Chicken breast, Chipotle sauce, Salad", "cook that chicken while putting the salad on a bowl, add the sauce. After all that, cut the chicken breast into square pieces and place them on top of the salad. Done!", null, null, "Chicken Chipotle Salad" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Height", "MealPlanId", "Password", "UserId", "Username", "Weight", "WorkoutPlanId" },
                values: new object[,]
                {
                    { 1, 19, "aturro@student.neumont.edu", 6.0999999999999996, null, "TestPass", null, "Scipion2002", 164, null },
                    { 2, 20, "aturro@student.neumont.edu", 6.0, null, "DavidPass", null, "DNgo-Neumont", 156, null },
                    { 3, 21, "rbrunney@student.neumont.edu", 6.0, null, "RobPass", null, "Rxittles", 135, null }
                });

            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This plan is to help you bulk those muscles and make them bigger! The workouts will mostly be using heavy weights and doing exercises with them", "Bulk up" },
                    { 2, "This plan is filled with workouts that will make your muscles go in shock and it will also have mostly body-weight exercises", "Tune up" },
                    { 3, "This plan is made to make you lower your weight, get ready for some cardio workouts!", "Slim Down" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, "Upper Body" },
                    { 2, null, "Lower Body" },
                    { 3, null, "Cardio" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_FromUserId",
                table: "Challenges",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ToUserId",
                table: "Challenges",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_WorkoutId",
                table: "Challenges",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkout_WorkoutsId",
                table: "ExerciseWorkout",
                column: "WorkoutsId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FromUserId",
                table: "Friendships",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_ToFriendId",
                table: "Friendships",
                column: "ToFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_MealMealPlan_MealsId",
                table: "MealMealPlan",
                column: "MealsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MealPlanId",
                table: "Users",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkoutPlanId",
                table: "Users",
                column: "WorkoutPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutWorkoutPlan_WorkoutsId",
                table: "WorkoutWorkoutPlan",
                column: "WorkoutsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "ExerciseWorkout");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "MealMealPlan");

            migrationBuilder.DropTable(
                name: "WorkoutWorkoutPlan");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "WorkoutPlans");
        }
    }
}
