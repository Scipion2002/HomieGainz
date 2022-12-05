import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/Exercise%20Page/Front/exercise_card_list.dart';
import 'package:homiegainz_front_end/util/to_prev_page.dart';

class WorkoutInfo extends StatefulWidget {
  const WorkoutInfo({Key? key,
    this.workoutName = "",
    this.imgUrl = "",
    this.exercises = const [],}) : super(key: key);

  final String workoutName;
  final String? imgUrl;
  final List<dynamic> exercises;

  @override
  State<WorkoutInfo> createState() => _WorkoutInfoState();
}

class _WorkoutInfoState extends State<WorkoutInfo> {

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
          body: SingleChildScrollView(
            child: Column(
              children: [
                const ToPrevPage(),
                Text(widget.workoutName,
                    style:
                    const TextStyle(fontSize: 35, fontWeight: FontWeight.bold)),
                if (widget.imgUrl != null)
                  Card(
                    margin: const EdgeInsets.all(10),
                    elevation: 2,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: ClipRRect(
                      borderRadius: const BorderRadius.all(Radius.circular(10)),
                      child: Image.network(
                        widget.imgUrl!,
                        width: 350,
                        height: 275,
                        fit: BoxFit.cover,
                      ),
                    ),
                  ),
                if (widget.imgUrl == null)
                  Card(
                    margin: const EdgeInsets.all(10),
                    elevation: 2,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: const ClipRRect(
                      borderRadius: BorderRadius.only(
                          topLeft: Radius.circular(10),
                          topRight: Radius.circular(10)),
                      child: Image(
                        image: AssetImage("assets/images/HomieGainzImg.png"),
                        width: 350,
                        height: 150,
                        fit: BoxFit.cover,
                      ),
                    ),
                  ),
                ExerciseCardList(
                  exercises: widget.exercises,
                ),
              ],
            ),
          ),
        ));
  }
}
