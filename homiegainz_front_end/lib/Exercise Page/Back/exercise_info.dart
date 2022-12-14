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
        child: Column(
          children: [
            const ToPrevPage(),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10),
              child: Text(exerciseName,
                  style: const TextStyle(
                      fontSize: 35, fontWeight: FontWeight.bold)),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10),
              child: const Text("Description",
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10),
              child: Text(
                description,
                style: const TextStyle(fontSize: 15),
              ),
            ),
            Container(margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10), child: const Text("Muscle Targeted", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10),
              child: Text(
                targetMuscle,
                style: const TextStyle(fontSize: 20),
              ),
            ),
            Container(margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10), child: const Text("Amount of sets", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10),
              child: Text("$setAmt",
                  style: const TextStyle(fontSize: 20)),
            ),
            Container(margin: const EdgeInsets.symmetric(vertical: 5, horizontal: 10), child: const Text("Amount of repetitions", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 10),
              child: Text("$repAmt",
                  style: const TextStyle(fontSize: 20)),
            ),
          ],
        ),
      ),
    ));
  }
}
