import 'package:flutter/material.dart';

import '../../Edit_pages/edit_exercise_page.dart';
import '../Back/exercise_info.dart';

class ExerciseCard extends StatefulWidget {
  ExerciseCard(
      {Key? key,
      this.exerciseName = '',
      this.targetMuscle = '',
      this.setAmt = 0,
      this.repAmt = 0,
      this.description = '',
      this.beingEdited = false})
      : super(key: key);

  String exerciseName;
  String targetMuscle;
  int setAmt;
  int repAmt;
  String description;
  final bool beingEdited;

  @override
  State<ExerciseCard> createState() => _ExerciseCardState();
}

class _ExerciseCardState extends State<ExerciseCard> {
  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
        constraints: const BoxConstraints(
          maxWidth: 350,
        ),
        child: GestureDetector(
          onTap: () {
            Navigator.push(
                context,
                MaterialPageRoute<void>(
                  builder: (BuildContext context) => !widget.beingEdited
                      ? ExerciseInfo(
                          exerciseName: widget.exerciseName,
                          description: widget.description,
                          targetMuscle: widget.targetMuscle,
                          setAmt: widget.setAmt,
                          repAmt: widget.repAmt,
                        )
                      : EditExercisePage(
                          exerciseName: widget.exerciseName,
                          description: widget.description,
                          targetMuscle: widget.targetMuscle,
                          setAmt: widget.setAmt,
                          repAmt: widget.repAmt,
                        ),
                ));
          },
          child: Card(
            margin: const EdgeInsets.all(10),
            elevation: 2,
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(10),
            ),
            child: Column(
              children: [
                Container(
                    alignment: Alignment.centerLeft,
                    margin: const EdgeInsets.only(left: 15, top: 5, bottom: 5),
                    child: Row(
                      children: [
                        Text(
                          widget.exerciseName,
                          style: const TextStyle(
                            fontSize: 20,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        Container(
                          margin: const EdgeInsets.only(left: 20),
                            child: Text(
                          "Reps: ${widget.repAmt}",
                          style: const TextStyle(
                            fontSize: 20,
                            fontWeight: FontWeight.bold,
                          ),
                        )),
                        Container(
                          margin: const EdgeInsets.only(left: 20),
                        child: Text(
                            "Sets: ${widget.setAmt}",
                            style: const TextStyle(
                              fontSize: 20,
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                        )

                      ],
                    )),
              ],
            ),
          ),
        ));
  }
}
