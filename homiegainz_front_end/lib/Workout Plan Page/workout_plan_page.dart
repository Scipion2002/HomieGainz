import 'dart:collection';
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

                    LinkedHashMap<String, dynamic> workoutInformation =
                    json.decode(snapshot.data!);


                    List<dynamic> workouts = workoutInformation["workouts"]["\$values"];
                    for (var workout in workouts) {
                      requests.makeGetRequestWithAuth("http://10.0.2.2:9000/workouts/${workout["id"]}", globals.username, globals.password)
                      userWorkouts.add(WorkoutCard(
                        workoutID: workout["id"],
                        workoutName: workout["name"],
                        description: workout["description"],
                        exercises: workout["exercises"],
                      ));
                    }

                    return Column(children:
                      userWorkouts
                    );
                  } else if (snapshot.hasError){
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
                })));
  }
}
