import 'dart:collection';
import 'dart:convert';

import 'package:flutter/material.dart';
import '../../util/globals.dart' as globals;
import '../util/requests.dart';
import 'Front/meal_card.dart';

class MealPlanPage extends StatefulWidget {
  const MealPlanPage({Key? key}) : super(key: key);

  @override
  State<MealPlanPage> createState() => _MealPlanPageState();
}

class _MealPlanPageState extends State<MealPlanPage> {
  Requests requests = Requests();
  List<MealCard> userMeals = [];

  @override
  Widget build(BuildContext context) {

    Future<String> getUserMeals = requests.makeGetRequestWithAuth(
        "http://10.0.2.2:9000/mealPlans/${globals.mealPlanID}",
        globals.username,
        globals.password);

    return SafeArea(
      child: Scaffold(
          body: SingleChildScrollView(child: FutureBuilder<String>(
            future: getUserMeals,
            builder: (context, snapshot){
              if(snapshot.hasData){
                userMeals.clear();

                LinkedHashMap<String, dynamic> mealInformation = json.decode(snapshot.data!);
                print(mealInformation);

                List<dynamic> meals = mealInformation["meals"];

                for (var meal in meals){
                  userMeals.add(MealCard(
                    mealID: meal["id"],
                    mealName: meal["name"],
                    description: meal["description"],
                    ingredients: meal["ingredientList"],
                    directions: meal["directions"],
                    isAdded: true,
                  ));
                }
                return Column(children: userMeals);
              } else if (snapshot.hasError) {
                return Text('${snapshot.error}');
              }
              return Center(
                  heightFactor: 20,
                  child: Container(
                    alignment: Alignment.center,
                    child: const CircularProgressIndicator(
                      color: Colors.tealAccent,
                    ),
                  ));
            },
          )) ),
    );
  }
}
