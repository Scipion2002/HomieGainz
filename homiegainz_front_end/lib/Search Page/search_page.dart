import 'dart:collection';
import 'dart:convert';

import 'package:flutter/material.dart';
import '../Workout Plan Page/Front/workout_card.dart';
import '../../util/globals.dart' as globals;
import '../util/requests.dart';
import '../util/search_bar.dart';

class SearchPage extends StatefulWidget {
  const SearchPage({Key? key}) : super(key: key);

  @override
  State<SearchPage> createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage>
    with SingleTickerProviderStateMixin {
  String filter = "workout";
  List<Widget> userSearch = [];
  Future<String>? futureSearchInfo;
  bool _isActive = false;
  Requests requests = Requests();

  @override
  Widget build(BuildContext context) {
    TextEditingController _searchController = TextEditingController();
    return SafeArea(
        child: Scaffold(
            appBar: AppBar(
              title: Row(
                children: [
                  if (!_isActive)
                    Text("Search Page",
                        style: Theme.of(context).appBarTheme.titleTextStyle),
                  Expanded(
                    child: Align(
                      alignment: Alignment.centerRight,
                      child: AnimatedSize(
                        duration: const Duration(milliseconds: 250),
                        child: _isActive
                            ? Container(
                          width: double.infinity,
                          height: 40,
                          decoration: BoxDecoration(
                              color: Colors.white12,
                              borderRadius: BorderRadius.circular(4.0)),
                          child: TextField(
                            controller: _searchController,
                            decoration: InputDecoration(
                                hintText: 'Search for something',
                                prefixIcon: IconButton(
                                  onPressed: () {
                                    print(_searchController.text);
                                    print(filter);
                                    if (filter == "workout") {
                                      // futureSearchInfo =
                                      requests
                                          .makeGetRequest(
                                          "http://10.0.2.2:9000/workouts/ByName/${_searchController.text}")
                                          .then((value){
                                            showData(value);
                                        //
                                        // return value;
                                      });
                                    }
                                  },
                                  icon: const Icon(Icons.search),
                                ),
                                suffixIcon: IconButton(
                                    onPressed: () {
                                      setState(() {
                                        _isActive = false;
                                      });
                                    },
                                    icon: const Icon(Icons.close))),
                          ),
                        )
                            : IconButton(
                            onPressed: () {
                              setState(() {
                                _isActive = true;
                              });
                            },
                            icon: const Icon(Icons.search)),
                      ),
                    ),
                  ),
                ],
              )
            ),
            body: SingleChildScrollView(
              child: Column(
                children: [
                  RadioListTile(
                    title: const Text("Workout"),
                    value: "workout",
                    groupValue: filter,
                    onChanged: (value) {
                      setState(() {
                        filter = value.toString();
                        print(filter);
                      });
                    },
                  ),
                  RadioListTile(
                    title: const Text("Meal"),
                    value: "meal",
                    groupValue: filter,
                    onChanged: (value) {
                      setState(() {
                        filter = value.toString();
                        print(filter);
                      });
                    },
                  ),
                  RadioListTile(
                    title: const Text("User"),
                    value: "user",
                    groupValue: filter,
                    onChanged: (value) {
                      setState(() {
                        filter = value.toString();
                        print(filter);
                      });
                    },
                  ),
                  const Divider(),
                  Column(children: userSearch,)
                //   FutureBuilder<String>(
                //       future: futureSearchInfo,
                //       builder: (context, snapshot) {
                //         switch (snapshot.connectionState) {
                //           case ConnectionState.waiting:
                //             return const Text(
                //               "Search for something!",
                //               style: TextStyle(fontSize: 15),
                //             );
                //           default:
                //             if (snapshot.hasData) {
                //               LinkedHashMap information =
                //                   json.decode(snapshot.data!);
                //               print(information);
                //               userSearch.clear();
                //               if (filter.contains("workout")) {
                //                 userSearch.add(WorkoutCard(
                //                   workoutID: information["id"],
                //                   workoutName: information["name"],
                //                   exercises: information["exercises"],
                //                 ));
                //               }
                //               return Column(
                //                 children: userSearch,
                //               );
                //             } else if (snapshot.hasError) {
                //               return Text('${snapshot.error}');
                //             }
                //             return const Text(
                //               "Im cool lol",
                //               style: TextStyle(fontSize: 15),
                //             );
                //         }
                //       })
                ],
              ),
            )));
  }

  void showData(vale) {
    LinkedHashMap<String, dynamic> data = json.decode(vale);

    print(data);

      setState(() {
        userSearch.add(WorkoutCard(
          workoutID: data["id"],
          workoutName: data["name"],
          exercises: data["exercises"],
        ));
      });
  }
}
