import 'dart:convert';

import 'package:flutter/material.dart';
import '../../../util/requests.dart';
import '../../../util/globals.dart' as globals;

class SendWorkoutCard extends StatefulWidget {
  SendWorkoutCard({Key? key, this.userId = 0, this.workoutId = 0, this.workoutName = ""})
      : super(key: key);

  int userId;
  int workoutId;
  String workoutName;

  @override
  State<SendWorkoutCard> createState() => _SendWorkoutCardState();
}

class _SendWorkoutCardState extends State<SendWorkoutCard> {
  Requests requests = Requests();

  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
        constraints: const BoxConstraints(
          maxWidth: 350,
        ),
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
                        widget.workoutName,
                        style: const TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      const Spacer(),
                      IconButton(
                        icon: const Icon(Icons.send),
                        alignment: Alignment.centerLeft,
                        onPressed: () async {
                          requests.makeGetRequestWithAuth("http://10.0.2.2:9000/challenges/sendChallengeRequest/${globals.userID}/${widget.userId}/${widget.workoutId}", globals.username, globals.password);
                        },
                      ),
                    ],
                  )),
            ],
          ),
        ));
  }
}
