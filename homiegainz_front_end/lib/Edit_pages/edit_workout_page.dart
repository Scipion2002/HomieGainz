import 'package:flutter/material.dart';

class EditWorkoutPage extends StatefulWidget {
  final String workoutName;
  final String description;
  final String imgUrl;
  final List<dynamic> exercises;

  const EditWorkoutPage({
    Key? key,
    this.workoutName = "",
    this.description = "",
    this.exercises = const [],
    this.imgUrl = "",
  }) : super(key: key);

  @override
  State<EditWorkoutPage> createState() => _EditWorkoutPageState();
}

class _EditWorkoutPageState extends State<EditWorkoutPage> {
  @override
  Widget build(BuildContext context) {
    return Container();
  }
}
