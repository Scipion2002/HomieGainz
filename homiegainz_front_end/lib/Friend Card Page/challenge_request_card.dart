import 'package:flutter/material.dart';
import '../../../util/requests.dart';
import '../../../util/globals.dart' as globals;

class ChallengeRequestCard extends StatefulWidget {
  ChallengeRequestCard(
      {Key? key,
      this.userId = 0,
      this.username = 'Rxittles',
      this.workoutId = 0,
      this.workoutName = 'Killer Push-ups'})
      : super(key: key);

  int userId;
  String username;
  int workoutId;
  String workoutName;

  @override
  State<ChallengeRequestCard> createState() => _ChallengeRequestCardState();
}

class _ChallengeRequestCardState extends State<ChallengeRequestCard> {
  Requests requests = Requests();

  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
        constraints: const BoxConstraints(
          maxWidth: 400,
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
                        "Challenger: ${widget.username} \nWorkout: ${widget.workoutName}",
                        style: const TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      const Spacer(),
                      IconButton(
                        icon: const Icon(Icons.check_circle),
                        alignment: Alignment.centerLeft,
                        onPressed: () {
                          requests.makeGetRequestWithAuth(
                              "http://10.0.2.2:9000/challenges/acceptRequest/${globals.userID}/${widget.userId}/${widget.workoutId}",
                              globals.username,
                              globals.password);
                        },
                      ),
                      IconButton(
                        icon: const Icon(Icons.cancel),
                        alignment: Alignment.centerLeft,
                        onPressed: () {
                          requests
                              .makeGetRequestWithAuth(
                              "http://10.0.2.2:9000/challenges/rejectRequest/${globals.userID}/${widget.userId}/${widget.workoutId}",
                              globals.username,
                              globals.password);
                        },
                      ),
                    ],
                  )),
            ],
          ),
        ));
  }
}
