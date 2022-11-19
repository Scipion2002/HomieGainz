import 'package:flutter/material.dart';

import 'exercise.dart';

class ExerciseList extends StatelessWidget {
  List<dynamic> exercises;

  ExerciseList({Key? key, this.exercises = const []}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    List<Widget> exerciseList = [
      const Text('Exercises',
          style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold))
    ];

    for (var exercise in exercises) {
      print(exercise);
      exerciseList.add(Exercise(
          workoutName: exercise['Name'],
          targetMuscle: exercise['TargetMuscle'],
          setAmt: exercise['SetAmt'],
          repAmt: exercise['RepAmt'],
          description: exercise['Description']));
    }
    return Container(
      margin: const EdgeInsets.symmetric(vertical: 10),
      child: Column(children: exerciseList,),
    );
  }
}
