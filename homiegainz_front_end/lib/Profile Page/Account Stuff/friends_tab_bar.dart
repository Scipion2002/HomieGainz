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

  @override
  Widget build(BuildContext context) {
    // Future<String> getFriendList = requests
    //     .makeGetRequest("http://localhost:9000/friendships/${globals.userID}");

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
                  Tab(icon: Icon(Icons.person_add_alt_1),),
                  Tab(icon: Icon(FontAwesomeIcons.dumbbell),)
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
                        FriendCard(),
                        FriendCard(
                          username: 'Dragonliver',
                        )
                        // Container(
                        //   margin: const EdgeInsets.only(top: 15),
                        //   child: SingleChildScrollView(
                        //     child: FutureBuilder<String>(
                        //         future: getFriendList,
                        //         builder: (context, snapshot) {
                        //           if (snapshot.hasData) {
                        //             userFriendList.clear();
                        //             List<dynamic> friends =
                        //                 json.decode(snapshot.data!)["results"];
                        //
                        //             for (var friend in friends) {
                        //               userFriendList.add(FriendCard(
                        //                 userId: friend['Id'],
                        //                 username: friend['Username']
                        //               ));
                        //             }
                        //
                        //             return Column(
                        //               children: userFriendList,
                        //             );
                        //           } else if (snapshot.hasError) {
                        //             return Text('${snapshot.error}');
                        //           }
                        //
                        //           return Center(
                        //               heightFactor: 20,
                        //               child: Container(
                        //                 alignment: Alignment.center,
                        //                 child: const CircularProgressIndicator(
                        //                   color: Colors.tealAccent,
                        //                 ),
                        //               ));
                        //         }),
                        //   ),
                        // ),
                      ],
                    ))),
                Container(margin: const EdgeInsets.only(top: 10),child: SingleChildScrollView(child: Column( children: [FriendRequestCard()],),),),
                Container(margin: const EdgeInsets.only(top: 10),child:  SingleChildScrollView(child: Column( children: [ChallengeRequestCard()],),),)
              ],
            ),
          ),
        ),
      ),
    );
  }
}
