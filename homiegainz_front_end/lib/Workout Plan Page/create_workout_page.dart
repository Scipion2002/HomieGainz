import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/Exercise%20Page/Front/exercise_card.dart';
import 'package:homiegainz_front_end/Exercise%20Page/Front/exercise_card_list.dart';
import '../../util/to_prev_page.dart';
import '../../util/requests.dart';
import '../../util/globals.dart' as globals;
import 'dart:convert';
import 'package:http/http.dart' as http;

class CreateWorkout extends StatefulWidget {
  const CreateWorkout({Key? key}) : super(key: key);

  @override
  State<CreateWorkout> createState() => _CreateWorkoutState();
}

class _CreateWorkoutState extends State<CreateWorkout> {
  TextEditingController nameOfWorkoutController = TextEditingController();
  TextEditingController nameOfExerciseController = TextEditingController();
  TextEditingController descriptionOfExerciseController =
      TextEditingController();
  TextEditingController targetMuscleController = TextEditingController();
  TextEditingController repAmtController = TextEditingController();
  TextEditingController setAmtController = TextEditingController();
  Requests request = Requests();

  List<dynamic> exercises = [];

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: SingleChildScrollView(
          child: Column(
            children: [
              const ToPrevPage(),
              const Text(
                'Create Workout',
                style: TextStyle(fontSize: 28, fontWeight: FontWeight.bold),
              ),
              Container(
                margin: const EdgeInsets.only(top: 30, bottom: 15),
                child: const Text(
                  'Workout Name',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                ),
              ),
              Container(
                margin:
                    const EdgeInsets.symmetric(horizontal: 15, vertical: 15),
                child: TextField(
                    controller: nameOfWorkoutController,
                    decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: "Enter Workout Name...",
                        labelText: 'Enter Workout Name')),
              ),
              if (exercises.isNotEmpty)
                SizedBox(
                  height: 150,
                  width: MediaQuery.of(context).size.width - 15,
                  child: SingleChildScrollView(child: ExerciseCardList(exercises: exercises,),)

                ),
              Container(
                margin: const EdgeInsets.only(top: 25, bottom: 15),
                child: const Text(
                  'Exercise name',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                ),
              ),
              Container(
                margin:
                    const EdgeInsets.symmetric(horizontal: 15, vertical: 15),
                child: TextField(
                    controller: nameOfExerciseController,
                    decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: "Enter Exercise Name...",
                        labelText: 'Enter Exercise Name')),
              ),
              Container(
                margin: const EdgeInsets.symmetric(vertical: 15),
                child: const Text(
                  'Description of Exercise',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                ),
              ),
              Container(
                margin: const EdgeInsets.symmetric(horizontal: 15),
                child: TextField(
                    controller: descriptionOfExerciseController,
                    decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: "Enter Description...",
                        labelText: 'Enter Description')),
              ),
              Container(
                margin: const EdgeInsets.symmetric(vertical: 15),
                child: const Text(
                  'Target Muscle',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                ),
              ),
              Container(
                margin: const EdgeInsets.symmetric(horizontal: 15),
                child: TextField(
                    controller: targetMuscleController,
                    decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: "Enter target muscle...",
                        labelText: 'Enter target muscle')),
              ),
              Container(
                margin: const EdgeInsets.symmetric(vertical: 15),
                child: const Text(
                  'Amount of repetitions',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                ),
              ),
              Container(
                margin: const EdgeInsets.symmetric(horizontal: 15),
                child: TextField(
                    controller: repAmtController,
                    decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: "Enter Rep Amt...",
                        labelText: 'Enter Rep Amount')),
              ),
              Container(
                margin: const EdgeInsets.symmetric(vertical: 15),
                child: const Text(
                  'Amount of rounds',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                ),
              ),
              Container(
                margin: const EdgeInsets.symmetric(horizontal: 15),
                child: TextField(
                    controller: setAmtController,
                    decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: "Enter Set Amt...",
                        labelText: 'Enter Set Amount')),
              ),
              Container(
                alignment: Alignment.center,
                margin: const EdgeInsets.only(top: 5, bottom: 5),
                child: ElevatedButton(
                  onPressed: () async {
                    Map<String, dynamic> newExercise = {
                      "Name": nameOfExerciseController.text,
                      "TargetMuscle": targetMuscleController.text,
                      "Description": descriptionOfExerciseController.text,
                      "SetAmt": int.parse(setAmtController.text),
                      "RepAmt": int.parse(repAmtController.text)
                    };
                    setState(() {
                      exercises.add(newExercise);
                    });
                    print(exercises);
                  },
                  child: const Text(
                    'Add Exercise',
                    style: TextStyle(color: Colors.black),
                  ),
                ),
              ),
              Container(
                alignment: Alignment.center,
                margin: const EdgeInsets.only(top: 5, bottom: 5),
                child: ElevatedButton(
                    onPressed: () async {
                      if (nameOfWorkoutController.text.isNotEmpty &&
                          descriptionOfExerciseController.text.isNotEmpty &&
                          repAmtController.text.isNotEmpty &&
                          setAmtController.text.isNotEmpty &&
                          targetMuscleController.text.isNotEmpty) {
                        Map<String, dynamic> newWorkout = {
                          "Name": nameOfWorkoutController.text,
                          "Exercises": exercises,
                        };

                        request
                            .makePostRequestWithAuth(
                                "http://10.0.2.2:9000/workouts", newWorkout, globals.username, globals.password)
                            .then((value) {
                          // print(value);
                          request
                            .makeGetRequestWithAuth(
                              "addWorkoutToPlan/${json.decode(value)["id"]}/${globals.workoutPlanID}", globals.username, globals.password);
                        });
                        Navigator.of(context).pop();
                      } else {
                        await showDialog<void>(
                            context: context,
                            builder: (BuildContext context) {
                              return AlertDialog(
                                title:
                                    const Text('Not all the fields are used'),
                                content: const Text(
                                    'Please, fill at least the fields (Name, Rep amount and Set amount) with the information of the workout.'),
                                actions: <Widget>[
                                  TextButton(
                                    onPressed: () {
                                      Navigator.pop(context);
                                    },
                                    child: const Text('OK'),
                                  ),
                                ],
                              );
                            });
                      }
                    },
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.blue, // background
                    ),
                    child: const Text(
                      'Create Workout',
                      style: TextStyle(color: Colors.black),
                    )),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
