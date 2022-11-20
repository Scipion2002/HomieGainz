import 'package:flutter/material.dart';

import 'Front/workout_card.dart';

class WorkoutPlanPage extends StatelessWidget {
  const WorkoutPlanPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
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
