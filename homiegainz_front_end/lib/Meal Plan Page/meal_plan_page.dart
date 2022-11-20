import 'package:flutter/material.dart';

import 'Front/meal_card.dart';

class MealPlanPage extends StatelessWidget {
  const MealPlanPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
          body: Column(
            children: [
              const Text("Your Meal Plan",
                  style:
                  TextStyle(fontSize: 35, fontWeight: FontWeight.bold)),
              MealCard(
                mealID: 1,
                mealName: "salad",
                description:
                "This meal is meant for you to get nutritious stuff on your belly!",
                ingredients: "Lettuce, Tomato, Carrot, Boiled Egg",
                directions: "chop up the veggies and put them together, do this while you wait for the egg to boil",
              ),
            ],
          )),
    );
  }
}
