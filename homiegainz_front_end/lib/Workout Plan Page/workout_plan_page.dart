import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/Workout%20Plan%20Page/create_workout_page.dart';
import 'package:homiegainz_front_end/util/add_floating_button.dart';
import '../../util/globals.dart' as globals;
import '../util/requests.dart';
import 'Front/workout_card.dart';

class WorkoutPlanPage extends StatefulWidget {
  const WorkoutPlanPage({Key? key}) : super(key: key);

  @override
  State<WorkoutPlanPage> createState() => _WorkoutPlanPageState();
}

class _WorkoutPlanPageState extends State<WorkoutPlanPage> {
  Requests requests = Requests();
  List<WorkoutCard> userWorkouts = [];

  @override
  Widget build(BuildContext context) {
    Future<String> getUserWorkouts = requests.makeGetRequestWithAuth(
        "http://10.0.2.2:9000/workoutPlans/${globals.workoutPlanID}",
        globals.username,
        globals.password);

    return SafeArea(
        child: Scaffold(
            floatingActionButton:
                const AddFloatingButton(widgetPage: CreateWorkout()),
            body: FutureBuilder<String>(
                future: getUserWorkouts,
                builder: (context, snapshot) {
                  if (snapshot.hasData) {
                    userWorkouts.clear();
                  }
                  List<dynamic> workoutInformation =
                      json.decode(snapshot.data!);
                  print(workoutInformation.toString());

                  for (var workout in workoutInformation) {
                    userWorkouts.add(WorkoutCard(
                      workoutID: workout["id"],
                      workoutName: workout["name"],
                      description: workout["description"],
                      exercises: workout["exercises"],
                    ));
                  }

                  return Column(children: [
                    const Text("Your Workout Plan",
                        style: TextStyle(
                            fontSize: 35, fontWeight: FontWeight.bold)),
                  ]);
                })));
  }
}
