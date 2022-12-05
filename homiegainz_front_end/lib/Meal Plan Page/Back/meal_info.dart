import 'package:flutter/material.dart';

import '../../util/to_prev_page.dart';

class MealInfo extends StatelessWidget {
  const MealInfo({
    Key? key,
    this.imageUrl =
        "https://i.pinimg.com/736x/ba/92/7f/ba927ff34cd961ce2c184d47e8ead9f6.jpg",
    this.mealName = "",
    this.description = "",
    this.mealID = 0,
    this.ingredients = "",
    this.directions = "",
  }) : super(key: key);

  final String imageUrl;
  final String mealName;
  final String description;
  final int mealID;
  final String ingredients;
  final String directions;

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
          body: SingleChildScrollView(
            child: Column(
              children: [
                const ToPrevPage(),
                Text(mealName,
                    style:
                    const TextStyle(fontSize: 35, fontWeight: FontWeight.bold)),
                Card(
                  margin: const EdgeInsets.all(10),
                  elevation: 2,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10),
                  ),
                  child: ClipRRect(
                    borderRadius: const BorderRadius.all(Radius.circular(10)),
                    child: Image.network(
                      imageUrl,
                      width: 350,
                      height: 275,
                      fit: BoxFit.cover,
                    ),
                  ),
                ),
                Container(margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10), child: const Text("Description", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),),
                Container(margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10), child: Text(description, style: const TextStyle(fontSize: 15)),),
                Container(margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10), child: const Text("Ingredients", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),),
                Container(margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10), child: Text(ingredients, style: const TextStyle(fontSize: 15)),),
                Container(margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10), child: const Text("Directions", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),),
                Container(margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10), child: Text(directions, style: const TextStyle(fontSize: 15)),),
              ],
            ),
          ),
        ));
  }
}
