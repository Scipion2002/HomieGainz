import 'package:flutter/material.dart';

class EditExercisePage extends StatefulWidget {
  String exerciseName;
  String targetMuscle;
  int setAmt;
  int repAmt;
  String description;

  EditExercisePage({
    Key? key,
    this.exerciseName = '',
    this.targetMuscle = '',
    this.setAmt = 0,
    this.repAmt = 0,
    this.description = '',
  }) : super(key: key);

  @override
  State<EditExercisePage> createState() => _EditExercisePageState();
}

class _EditExercisePageState extends State<EditExercisePage> {
  @override
  Widget build(BuildContext context) {
    return Container();
  }
}
