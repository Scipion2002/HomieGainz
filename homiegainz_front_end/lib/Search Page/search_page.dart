import 'dart:collection';
import 'dart:convert';

import 'package:flutter/material.dart';
import '../Workout Plan Page/Front/workout_card.dart';

import '../util/search_bar.dart';

class SearchPage extends StatefulWidget {

  const SearchPage({Key? key}) : super(key: key);

  @override
  State<SearchPage> createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
  String filter = "workout";
  List<Widget> userSearch = [];
  Future<String>? futureSearchInfo;

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
            appBar: AppBar(
              title: SearchBar(
                filter: filter,
                futureSearchInfo: futureSearchInfo,
              ),
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
                  if(futureSearchInfo != null)
                  FutureBuilder<String>(
                      future: futureSearchInfo,
                      builder: (context, snapshot) {
                        if (snapshot.hasData) {
                          LinkedHashMap information =
                              json.decode(snapshot.data!);
                          print(information);
                          userSearch.clear();
                          if (filter.contains("workout")) {
                            userSearch.add(WorkoutCard(
                              workoutID: information["id"],
                              workoutName: information["name"],
                              exercises: information["exercises"],
                            ));
                          }
                          return Column(
                            children: userSearch,
                          );
                        } else if (snapshot.hasError) {
                          return Text('${snapshot.error}');
                        }

                        return const Text("Search for something!", style: TextStyle(fontSize: 15),);
                      }),
                ],
              ),
            )));
  }
}
