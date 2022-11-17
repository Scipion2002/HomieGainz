import 'package:flutter/material.dart';

import '../util/search_bar.dart';

class SearchPage extends StatefulWidget {
  const SearchPage({Key? key}) : super(key: key);

  @override
  State<SearchPage> createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      appBar: AppBar(
        title: const SearchBar(),
      ),
      body: const Center(child: Text("Search for workout, meal or friend! Use the filter above to specify"),),
    ));
  }
}
