import 'package:flutter/material.dart';

class WorkoutPlanPage extends StatelessWidget {
  const WorkoutPlanPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      body: Column(
        children: const [Text("Workout Plan Page", textAlign: TextAlign.center,
          style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),)],
      ),
    ));
  }
}
