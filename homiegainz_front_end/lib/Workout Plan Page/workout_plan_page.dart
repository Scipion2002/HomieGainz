import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/Workout%20Plan%20Page/create_workout_page.dart';
import 'package:homiegainz_front_end/util/add_floating_button.dart';
import '../../util/globals.dart' as globals;
import '../util/requests.dart';
import 'Front/workout_card.dart';

class WorkoutPlanPage extends StatelessWidget {
  const WorkoutPlanPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {

    Requests requests = Requests();
    Future<String> getUserWorkouts = requests.makeGetRequestWithAuth("http://10.0.2.2:9000/workoutPlans/${globals.workoutPlanID}", globals.username, globals.password);

    return SafeArea(
      child: Scaffold(
        floatingActionButton: const AddFloatingButton(widgetPage: CreateWorkout()),
          body: Column(
        children: [
          const Text("Your Workout Plan",
              style:
              TextStyle(fontSize: 35, fontWeight: FontWeight.bold)),
          WorkoutCard(
            workoutID: 1,
            workoutName: "upper body",
            description:
                "This workout is meant for you to work those muscles up!",
            exercises: const [
              {
                'Name': "push up",
                'TargetMuscle': "biceps",
                'SetAmt': 3,
                'RepAmt': 15,
                'Description': "This exercise is to get your biceps tensed and working!"
              }
              ,
              {
                'Name': "pull up",
                'TargetMuscle': "back",
                'SetAmt': 3,
                'RepAmt': 5,
                'Description': "This exercise is to get your back tensed and working!"
              }
            ],
          ),
          WorkoutCard()
        ],
      )),
    );
  }
}
