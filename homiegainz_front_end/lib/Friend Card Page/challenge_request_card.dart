import 'package:flutter/material.dart';

class ChallengeRequestCard extends StatefulWidget {
  ChallengeRequestCard({Key? key, this.userId = 0, this.username = 'Rxittles', this.workoutId = 0, this.workoutName = 'Killer Push-ups'}) : super(key: key);

  int userId;
  String username;
  int workoutId;
  String workoutName;

  @override
  State<ChallengeRequestCard> createState() => _ChallengeRequestCardState();
}

class _ChallengeRequestCardState extends State<ChallengeRequestCard> {
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
                          // Navigator.push(
                          //   context,
                          //   PageTransition(
                          //       type: PageTransitionType.rightToLeft,
                          //       child: EditInfoPage(editProfileInfo: widget.editProfileInfo, accountInfo: widget.accountInfo,)),
                          // );
                        },
                      ),
                      IconButton(
                        icon: const Icon(Icons.cancel),
                        alignment: Alignment.centerLeft,
                        onPressed: () {
                          // Navigator.push(
                          //   context,
                          //   PageTransition(
                          //       type: PageTransitionType.rightToLeft,
                          //       child: EditInfoPage(editProfileInfo: widget.editProfileInfo, accountInfo: widget.accountInfo,)),
                          // );
                        },
                      ),
                    ],
                  )),
            ],
          ),
        ));
  }
}
