import 'package:flutter/material.dart';

import 'exercise_card.dart';

class ExerciseCardList extends StatelessWidget {
  List<dynamic> exercises;

  ExerciseCardList({Key? key, this.exercises = const []}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    List<Widget> exerciseList = [
      const Text('Exercises',
          style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold))
    ];

    for (var exercise in exercises) {
      exerciseList.add(ExerciseCard(
          exerciseName: exercise['name'],
          targetMuscle: exercise['targetMuscle'],
          setAmt: exercise['setAmt'],
          repAmt: exercise['repAmt'],
          description: exercise['description']));
    }
    return Container(
      margin: const EdgeInsets.symmetric(vertical: 10),
      child: Column(children: exerciseList,),
    );
  }
}
