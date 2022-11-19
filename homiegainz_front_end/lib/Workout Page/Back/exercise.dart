import 'package:flutter/material.dart';

class Exercise extends StatelessWidget {
  Exercise(
      {Key? key,
      this.workoutName = '',
      this.targetMuscle = '',
      this.setAmt = 0,
      this.repAmt = 0,
      this.description = ''})
      : super(key: key);

  String workoutName;
  String targetMuscle;
  int setAmt;
  int repAmt;
  String description;

  @override
  Widget build(BuildContext context) {
    return Container(
        margin: const EdgeInsets.only(
          left: 25,
        ),
        child: Row(
                children: [
                  Text(workoutName,
                      style: const TextStyle(
                        fontSize: 20,
                      )),
                  Container(
                      margin: const EdgeInsets.only(left: 15),
                      child: Text(
                        targetMuscle,
                        style: const TextStyle(fontSize: 20),
                      )),
                  Container(
                      margin: const EdgeInsets.only(left: 15),
                      child: Text(
                        setAmt.toString(),
                        style: const TextStyle(fontSize: 20),
                      )),
                  Container(
                      margin: const EdgeInsets.only(left: 15),
                      child: Text(
                        repAmt.toString(),
                        style: const TextStyle(fontSize: 20),
                      ))
                ],
              ));

  }
}
