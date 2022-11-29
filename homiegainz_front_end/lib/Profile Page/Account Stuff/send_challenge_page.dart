import 'dart:collection';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/Profile%20Page/Account%20Stuff/send_workout_card.dart';
import 'package:homiegainz_front_end/util/to_prev_page.dart';
import '../../util/globals.dart' as globals;
import '../../util/requests.dart';

class SendChallengePage extends StatefulWidget {
  SendChallengePage({Key? key, this.userId = 0}) : super(key: key);

  int userId;

  @override
  State<SendChallengePage> createState() => _SendChallengePageState();
}

class _SendChallengePageState extends State<SendChallengePage> {
  Requests requests = Requests();
  List<SendWorkoutCard> userWorkouts = [];

  @override
  Widget build(BuildContext context) {
    Future<String> getUserWorkouts = requests.makeGetRequestWithAuth(
        "http://10.0.2.2:9000/workoutPlans/${globals.workoutPlanID}",
        globals.username,
        globals.password);

    return SafeArea(
        child: Scaffold(
            body: SingleChildScrollView(
              child: Column(children: [
                const ToPrevPage(),
                FutureBuilder<String>(
                  future: getUserWorkouts,
                  builder: (context, snapshot) {
                    if (snapshot.hasData) {
                      userWorkouts.clear();

                      LinkedHashMap<String, dynamic> workoutInformation =
                      json.decode(snapshot.data!);

                      List<dynamic> workouts =
                      workoutInformation["workouts"];

                      for (var workout in workouts) {

                        userWorkouts.add(SendWorkoutCard(
                          userId: widget.userId,
                          workoutId: workout["id"],
                          workoutName: workout["name"],
                        ));
                      }
                      return Column(children: userWorkouts);
                    } else if (snapshot.hasError) {
                      return Text('${snapshot.error}');
                    }
                    return Center(
                        heightFactor: 20,
                        child: Container(
                          alignment: Alignment.center,
                          child: const CircularProgressIndicator(
                            color: Colors.tealAccent,
                          ),
                        ));
                  }),],)
            )));
  }
}
