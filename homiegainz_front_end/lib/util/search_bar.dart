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


  @override
  Widget build(BuildContext context) {
    TextEditingController _searchController = TextEditingController();
    return Container();
  }
}
