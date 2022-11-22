import 'package:flutter/material.dart';

import '../util/search_bar.dart';

class SearchPage extends StatefulWidget {
  const SearchPage({Key? key}) : super(key: key);

  @override
  State<SearchPage> createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
  String filter = "workout";

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
            appBar: AppBar(
              title: const SearchBar(),
            ),
            body: Column(
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
              ],
            )));
  }
}
