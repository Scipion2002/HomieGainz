import 'package:flutter/material.dart';

class EditMealPage extends StatefulWidget {
  EditMealPage({
    Key? key,
    this.imageUrl =
        "https://i.pinimg.com/736x/ba/92/7f/ba927ff34cd961ce2c184d47e8ead9f6.jpg",
    this.mealName = "",
    this.description = "",
    this.mealID = 0,
    this.ingredients = "",
    this.directions = "",
  }) : super(key: key);

  String imageUrl;
  String mealName;
  String description;
  int mealID;
  String ingredients;
  String directions;

  @override
  State<EditMealPage> createState() => _EditMealPageState();
}

class _EditMealPageState extends State<EditMealPage> {
  @override
  Widget build(BuildContext context) {
    return Container();
  }
}
