import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import '../../Edit_pages/edit_workout_page.dart';
import '../../util/globals.dart' as globals;
import '../../util/requests.dart';
import '../Back/workout_info.dart';

class WorkoutCard extends StatefulWidget {
   WorkoutCard({Key? key,
    this.imageUrl = "https://i.pinimg.com/736x/ba/92/7f/ba927ff34cd961ce2c184d47e8ead9f6.jpg",
    this.workoutName = "",
    this.workoutID = 0,
    this.exercises = const [],
    this.beingEdited = false,
    this.isAdded = false}) : super(key: key);

   String? imageUrl;
  final String workoutName;
  final int workoutID;
  final List<dynamic> exercises;
  final bool beingEdited;
  bool isAdded;
  @override
  State<WorkoutCard> createState() => _WorkoutCardState();
}

class _WorkoutCardState extends State<WorkoutCard> {
  Requests requests = Requests();
  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
        constraints: const BoxConstraints(
        maxWidth: 350,
    ),child: GestureDetector(
      onTap: () {
        Navigator.push(
            context,
            MaterialPageRoute<void>(
                builder: (BuildContext context) => !widget.beingEdited
                    ? WorkoutInfo(
                  workoutName: widget.workoutName,
                  imgUrl: widget.imageUrl,
                  exercises: widget.exercises,
                )
                    : EditWorkoutPage(
                  workoutName: widget.workoutName,
                  exercises: widget.exercises,
                  imgUrl: widget.imageUrl!,
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
            if(widget.imageUrl != null)
            ClipRRect(
              borderRadius: const BorderRadius.only(
                  topLeft: Radius.circular(10),
                  topRight: Radius.circular(10)),
              child: Image.network(
                widget.imageUrl!,
                width: 350,
                height: 150,
                fit: BoxFit.cover,
              ),
            ),

            if(widget.imageUrl == null)
              const ClipRRect(
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

            Container(
              margin: const EdgeInsets.only(left: 15, top: 5, bottom: 5),
              child: Center(child: Text(
                "Workout: ${widget.workoutName}",
                style: const TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                ),
              ),)
            ),
            Container(
              alignment: Alignment.center,
              child: Row(children: [
                Expanded(
                  flex: 1,
                  child: IconButton(
                    icon: Icon(!widget.isAdded
                        ? Icons.add
                        : FontAwesomeIcons.minus),
                    onPressed: () {
                      setState(() {
                        widget.isAdded = !widget.isAdded;
                      });

                      if (widget.isAdded) {
                        requests
                            .makeGetRequestWithAuth(
                            "http://10.0.2.2:9000/workoutPlans/addWorkoutToPlan/${widget.workoutID}/${globals.workoutPlanID}", globals.username, globals.password)
                            .then((value) {
                              print(json.decode(value));
                        });
                      } else {
                        requests
                            .makeGetRequestWithAuth(
                            "http://10.0.2.2:9000/workoutPlans/deleteWorkoutFromPlan/${widget.workoutID}/${globals.workoutPlanID}", globals.username, globals.password)
                            .then((value) {
                          print(json.decode(value));
                        });
                      }
                    },
                  ),
                ),
              ]),
            ),
          ],
        ),
      ),
    ));
  }
}
