import 'package:flutter/material.dart';
import 'package:page_transition/page_transition.dart';
import 'Account Stuff/account_header.dart';
import 'settings_page.dart';

class ProfilePage extends StatefulWidget {
  const ProfilePage({Key? key}) : super(key: key);

  @override
  State<ProfilePage> createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(children: [
        Container(
          margin: const EdgeInsets.only(right: 15, top: 15),
          alignment: Alignment.topRight,
          child: IconButton(
            icon: const Icon(Icons.settings_outlined, size: 25),
            onPressed: () {
              Navigator.push(
                context,
                PageTransition(
                    type: PageTransitionType.rightToLeft,
                    child: const SettingsPage()),
              );
            },
          ),
        ),
        AccountHeader(
          username: 'Scipion2002',
        ),
        //const MealAppBar(),
      ]),
    );
  }
}
