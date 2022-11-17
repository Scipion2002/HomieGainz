import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/util/page_navigation.dart';
import 'package:page_transition/page_transition.dart';

import 'create_account.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    TextEditingController _usernameController = TextEditingController();
    TextEditingController _passwordController = TextEditingController();

    return SafeArea(
      child: Scaffold(
        body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              margin: const EdgeInsets.only(top: 55),
              child: const Image(
                  image: AssetImage("assets/images/HomieGainzImg.png")),
            ),
            const Center(
                heightFactor: 2,
                child: Text(
                  "Login",
                  textAlign: TextAlign.center,
                  style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
                )),
            Container(
                margin:
                    const EdgeInsets.symmetric(horizontal: 15, vertical: 25),
                child: TextField(
                  controller: _usernameController,
                  decoration: const InputDecoration(
                      prefixIcon: Icon(Icons.account_circle_outlined,
                          color: Colors.grey),
                      focusedBorder: OutlineInputBorder(
                        borderSide: BorderSide(color: Colors.green),
                      ),
                      enabledBorder: OutlineInputBorder(
                          borderSide: BorderSide(color: Colors.blue)),
                      hintText: 'Enter Username...',
                      labelText: 'Enter Username',
                      labelStyle: TextStyle(color: Colors.grey),
                      focusColor: Colors.green),
                )),
            Container(
                margin:
                    const EdgeInsets.symmetric(horizontal: 15, vertical: 25),
                child: TextField(
                  controller: _passwordController,
                  decoration: const InputDecoration(
                      prefixIcon: Icon(Icons.account_circle_outlined,
                          color: Colors.grey),
                      focusedBorder: OutlineInputBorder(
                        borderSide: BorderSide(color: Colors.green),
                      ),
                      enabledBorder: OutlineInputBorder(
                          borderSide: BorderSide(color: Colors.blue)),
                      hintText: 'Enter Password...',
                      labelText: 'Enter Password',
                      labelStyle: TextStyle(color: Colors.grey),
                      focusColor: Colors.green),
                )),
            Container(
                margin: const EdgeInsets.only(top: 25, bottom: 25),
                child: Row(
                  children: [
                    Expanded(
                        flex: 1,
                        child: Container(
                            alignment: Alignment.center,
                            child: ElevatedButton(
                                style: ElevatedButton.styleFrom(
                                  backgroundColor: Colors.blue, // background
                                ),
                                onPressed: () {
                                  Navigator.push(
                                      context,
                                      PageTransition(
                                        type: PageTransitionType.bottomToTop,
                                        child: const PageNavigation(),
                                      ));
                                },
                                child: const Text('Log In',
                                    style: TextStyle(color: Colors.black))))),
                    Expanded(
                        flex: 1,
                        child: Container(
                            alignment: Alignment.center,
                            child: ElevatedButton(
                                style: ElevatedButton.styleFrom(
                                  backgroundColor: Colors.blue, // background
                                ),
                                onPressed: () {
                                  Navigator.push(
                                      context,
                                      PageTransition(
                                        type: PageTransitionType.bottomToTop,
                                        child: const CreateAccount(),
                                      ));
                                },
                                child: const Text('Sign Up',
                                    style: TextStyle(color: Colors.black)))))
                  ],
                )),
          ],
        ),
      ),
    ));
  }
}
