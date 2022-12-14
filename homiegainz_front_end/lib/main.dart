import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/Login/login_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'HomieGainz',
      theme: ThemeData.dark(),
      home: const LoginPage(),
    );
  }
}