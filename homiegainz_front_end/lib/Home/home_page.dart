import 'package:flutter/material.dart';

import '../util/requests.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  Requests requests = Requests();

  @override
  Widget build(BuildContext context) {
    // Future<String>? futureMealInfo =
    // requests.makeGetRequest("http://localhost:9000/meals");

    return Container();
  }
}
