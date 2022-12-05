import 'package:flutter/material.dart';

import '../../util/to_prev_page.dart';

class MealInfo extends StatefulWidget {
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

  final String? imageUrl;
  final String mealName;
  final String description;
  final int mealID;
  final String ingredients;
  final String directions;

  @override
  State<MealInfo> createState() => _MealInfoState();
}

class _MealInfoState extends State<MealInfo> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const ToPrevPage(),
            Text(widget.mealName,
                style:
                    const TextStyle(fontSize: 35, fontWeight: FontWeight.bold)),
            if (widget.imageUrl != null)
              Card(
                margin: const EdgeInsets.all(10),
                elevation: 2,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(10),
                ),
                child: ClipRRect(
                  borderRadius: const BorderRadius.all(Radius.circular(10)),
                  child: Image.network(
                    widget.imageUrl!,
                    width: 350,
                    height: 275,
                    fit: BoxFit.cover,
                  ),
                ),
              ),

            if (widget.imageUrl == null)
              Card(
                margin: const EdgeInsets.all(10),
                elevation: 2,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(10),
                ),
                child: const ClipRRect(
                  borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(10),
                      topRight: Radius.circular(10)),
                  child: Image(
                    image: AssetImage("assets/images/HomieGainzImg.png"),
                    width: 350,
                    height: 150,
                    fit: BoxFit.cover,
                  ),
                ),
              ),

            Container(
              margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10),
              child: const Text("Description",
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10),
              child: Text(widget.description, style: const TextStyle(fontSize: 15)),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10),
              child: const Text("Ingredients",
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10),
              child: Text(widget.ingredients, style: const TextStyle(fontSize: 15)),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10),
              child: const Text("Directions",
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10),
              child: Text(widget.directions, style: const TextStyle(fontSize: 15)),
            ),
          ],
        ),
      ),
    ));
  }
}
