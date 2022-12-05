import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

import '../../Edit_pages/edit_meal_page.dart';
import '../Back/meal_info.dart';

class MealCard extends StatefulWidget {
  MealCard(
      {Key? key,
      this.imageUrl =
          "https://i.pinimg.com/736x/ba/92/7f/ba927ff34cd961ce2c184d47e8ead9f6.jpg",
      this.mealName = "",
      this.description = "",
      this.mealID = 0,
      this.ingredients = "",
      this.directions = "",
      this.beingEdited = false,
      this.isAdded = false})
      : super(key: key);

  final String? imageUrl;
  final String mealName;
  final String description;
  final int mealID;
  final String ingredients;
  final String directions;
  final bool beingEdited;
  bool isAdded;

  @override
  State<MealCard> createState() => _MealCardState();
}

class _MealCardState extends State<MealCard> {
  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
        constraints: const BoxConstraints(
          maxWidth: 350,
        ),child: GestureDetector(
      onTap: () {
        Navigator.push(
            context,
            MaterialPageRoute<void>(
              builder: (BuildContext context) => !widget.beingEdited
                  ? MealInfo(
                mealName: widget.mealName,
                description: widget.description,
                imageUrl: widget.imageUrl,
                ingredients: widget.ingredients,
                directions: widget.directions
              )
                  : EditMealPage(
                  mealName: widget.mealName,
                  description: widget.description,
                  imageUrl: widget.imageUrl!,
                  ingredients: widget.ingredients,
                  directions: widget.directions
              ),
            ));
      },
      child: Card(
        margin: const EdgeInsets.all(10),
        elevation: 2,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(10),
        ),
        child: Column(
          children: [
            if(widget.imageUrl != null)
            ClipRRect(
              borderRadius: const BorderRadius.only(
                  topLeft: Radius.circular(10),
                  topRight: Radius.circular(10)),
              child: Image.network(
                widget.imageUrl!,
                width: 350,
                height: 150,
                fit: BoxFit.cover,
              ),
            ),

            if(widget.imageUrl == null)
              const ClipRRect(
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
            Container(
              alignment: Alignment.center,
              margin: const EdgeInsets.only(top: 5, bottom: 5),
              child: Text(
                widget.mealName,
                style: const TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
                margin: const EdgeInsets.only(left: 15, top: 5, bottom: 5),
              child: Row(children: const [
                Expanded(
                  flex: 1,
                  child: Text("", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),)
                )
              ]),
            ),
          ],
        ),
      ),
    ));
  }
}
