import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/Exercise%20Page/Front/exercise_card_list.dart';
import 'package:homiegainz_front_end/util/to_prev_page.dart';

class WorkoutInfo extends StatelessWidget {
  final String workoutName;
  final String description;
  final String imgUrl;
  final List<dynamic> exercises;

  const WorkoutInfo({
    Key? key,
    this.workoutName = "",
    this.description = "",
    this.imgUrl = "",
    this.exercises = const [],
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const ToPrevPage(),
            Text(workoutName,
                style:
                const TextStyle(fontSize: 35, fontWeight: FontWeight.bold)),
            Card(
              margin: const EdgeInsets.all(10),
              elevation: 2,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10),
              ),
              child: ClipRRect(
                borderRadius: const BorderRadius.all(Radius.circular(10)),
                child: Image.network(
                  imgUrl,
                  width: 350,
                  height: 275,
                  fit: BoxFit.cover,
                ),
              ),
            ),
            ExerciseCardList(
              exercises: exercises,
            ),
          ],
        ),
      ),
    ));
  }
}
