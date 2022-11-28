import 'dart:collection';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:homiegainz_front_end/Friend%20Card%20Page/challenge_request_card.dart';
import 'package:homiegainz_front_end/Friend%20Card%20Page/friend_request_card.dart';
import '../../../util/requests.dart';
import '../../../util/globals.dart' as globals;

import '../../Friend Card Page/friend_card.dart';

class FriendAppBar extends StatefulWidget {
  const FriendAppBar({Key? key}) : super(key: key);

  @override
  _MealAppBar createState() => _MealAppBar();
}

class _MealAppBar extends State<FriendAppBar> {
  Requests requests = Requests();
  List<FriendCard> userFriendList = [];
  List<FriendRequestCard> userFriendRequests = [];
  List<ChallengeRequestCard> userChallengeRequests = [];

  @override
  Widget build(BuildContext context) {
    Future<String> getFriendList = requests
        .makeGetRequestWithAuth("http://10.0.2.2:9000/users/getFriendList/${globals.userID}", globals.username, globals.password);

    Future<String> getFriendRequestsList = requests
        .makeGetRequestWithAuth("http://10.0.2.2:9000/friendships/${globals.userID}", globals.username, globals.password);

    Future<String> getChallengeRequestsList = requests
        .makeGetRequestWithAuth("http://10.0.2.2:9000/challenges/${globals.userID}", globals.username, globals.password);

    return Expanded(
      child: Container(
        margin: const EdgeInsets.only(top: 25),
        child: DefaultTabController(
          length: 3,
          child: Scaffold(
            appBar: AppBar(
              shadowColor: Colors.white,
              toolbarHeight: 1,
              bottom: const TabBar(
                tabs: [
                  Tab(icon: Icon(Icons.people_alt_rounded)),
                  Tab(
                    icon: Icon(Icons.person_add_alt_1),
                  ),
                  Tab(
                    icon: Icon(FontAwesomeIcons.dumbbell),
                  )
                ],
              ),
            ),
            body: TabBarView(
              children: [
                Container(
                    margin: const EdgeInsets.only(top: 10),
                    child: SingleChildScrollView(
                        child: Column(
                      children: [
                        Container(
                          margin: const EdgeInsets.only(top: 15),
                          child: SingleChildScrollView(
                            child: FutureBuilder<String>(
                                future: getFriendList,
                                builder: (context, snapshot) {
                                  if (snapshot.hasData) {
                                    userFriendList.clear();
                                    List<dynamic> friends =
                                        json.decode(snapshot.data!);

                                    for (var friend in friends) {
                                      userFriendList.add(FriendCard(
                                        userId: friend['id'],
                                        username: friend['username']
                                      ));
                                    }

                                    return Column(
                                      children: userFriendList,
                                    );
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
                                }),
                          ),
                        ),
                      ],
                    ))),
                Container(
                  margin: const EdgeInsets.only(top: 15),
                  child: SingleChildScrollView(
                    child: FutureBuilder<String>(
                        future: getFriendRequestsList,
                        builder: (context, snapshot) {
                          if (snapshot.hasData) {
                            userFriendRequests.clear();
                            List<dynamic> requests =
                            json.decode(snapshot.data!);

                            for (var request in requests) {
                              userFriendRequests.add(FriendRequestCard(
                                  userId: request['fromUser']['id'],
                                  username: request['fromUser']['username'],
                                  
                              ));
                            }

                            return Column(
                              children: userFriendRequests,
                            );
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
                        }),
                  ),
                ),
                Container(
                  margin: const EdgeInsets.only(top: 15),
                  child: SingleChildScrollView(
                    child: FutureBuilder<String>(
                        future: getChallengeRequestsList,
                        builder: (context, snapshot) {
                          if (snapshot.hasData) {
                            userChallengeRequests.clear();
                            List<dynamic> challenges =
                            json.decode(snapshot.data!);

                            for (var challenge in challenges) {
                              userChallengeRequests.add(ChallengeRequestCard(
                                userId: challenge['fromUser']['id'],
                                username: challenge['fromUser']['username'],
                                workoutId: challenge['workout']['id'],
                                workoutName: challenge['workout']['name']
                              ));
                            }

                            return Column(
                              children: userChallengeRequests,
                            );
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
                        }),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
