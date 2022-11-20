import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/util/to_prev_page.dart';

class ExerciseInfo extends StatelessWidget {
  final String exerciseName;
  final String targetMuscle;
  final int setAmt;
  final int repAmt;
  final String description;

  const ExerciseInfo({
    Key? key,
    this.exerciseName = '',
    this.targetMuscle = '',
    this.setAmt = 0,
    this.repAmt = 0,
    this.description = '',
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      body: SingleChildScrollView(
        child: Column(children: [
          const ToPrevPage(),
          Text(exerciseName,
              style:
              const TextStyle(fontSize: 35, fontWeight: FontWeight.bold)),

          Text(description, style: const TextStyle(fontSize: 15),),
          Text("Muscle Targeted: $targetMuscle", style: const TextStyle(fontSize: 20),),
          Text("Amount of sets: $setAmt", style: const TextStyle(fontSize: 20)),
          Text("Amount of repetitions: $repAmt", style: const TextStyle(fontSize: 20)),

        ],),
      ),
    ));
  }
}
