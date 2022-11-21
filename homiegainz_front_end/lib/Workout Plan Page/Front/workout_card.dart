import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import '../../Edit_pages/edit_workout_page.dart';
import '../../util/globals.dart' as globals;
import '../Back/workout_info.dart';

class WorkoutCard extends StatefulWidget {
   WorkoutCard({Key? key,
    this.imageUrl = "https://i.pinimg.com/736x/ba/92/7f/ba927ff34cd961ce2c184d47e8ead9f6.jpg",
    this.workoutName = "",
    this.description = "",
    this.workoutID = 0,
    this.exercises = const [],
    this.beingEdited = false,
    this.isAdded = false}) : super(key: key);

  final String imageUrl;
  final String workoutName;
  final String description;
  final int workoutID;
  final List<dynamic> exercises;
  final bool beingEdited;
  bool isAdded;
  @override
  State<WorkoutCard> createState() => _WorkoutCardState();
}

class _WorkoutCardState extends State<WorkoutCard> {
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
                  description: widget.description,
                  imgUrl: widget.imageUrl,
                  exercises: widget.exercises,
                )
                    : EditWorkoutPage(
                  workoutName: widget.workoutName,
                  description: widget.description,
                  exercises: widget.exercises,
                  imgUrl: widget.imageUrl,
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
            ClipRRect(
              borderRadius: const BorderRadius.only(
                  topLeft: Radius.circular(10),
                  topRight: Radius.circular(10)),
              child: Image.network(
                widget.imageUrl,
                width: 350,
                height: 150,
                fit: BoxFit.cover,
              ),
            ),
            Container(
              alignment: Alignment.centerLeft,
              margin: const EdgeInsets.only(left: 15, top: 5, bottom: 5),
              child: Text(
                widget.workoutName,
                style: const TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                ),
              ),
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

                      // if (widget.isAdded) {
                      //   requests
                      //       .makeGetRequest(
                      //       "http://10.0.2.2:8888/meal/save/${widget.mealID}/${globals.username}")
                      //       .then((value) {
                      //   });
                      // } else {
                      //   requests
                      //       .makeGetRequest(
                      //       "http://10.0.2.2:8888/meal/unsave/${widget.mealID}/${globals.username}")
                      //       .then((value) {
                      //   });
                      // }
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
