import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/Workout%20Plan%20Page/Front/workout_card.dart';
import '../../util/globals.dart' as globals;
import '../util/requests.dart';

class SearchBar extends StatefulWidget {


  SearchBar({Key? key, this.filter = "", this.futureSearchInfo})
      : super(key: key);

  String filter;
  Future<String>? futureSearchInfo;

  @override
  State<SearchBar> createState() => _SearchBarState();
}

class _SearchBarState extends State<SearchBar>
    with SingleTickerProviderStateMixin {
  Requests requests = Requests();
  bool _isActive = false;

  @override
  Widget build(BuildContext context) {
    TextEditingController _searchController = TextEditingController();
    return Row(
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
                                print(widget.filter);
                                if (widget.filter == "workout") {
                                    widget.futureSearchInfo = requests
                                        .makeGetRequest(
                                            "http://10.0.2.2:9000/workouts/ByName/${_searchController.text}")
                                        .then((value) {
                                      return value;
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
    );
  }
}
