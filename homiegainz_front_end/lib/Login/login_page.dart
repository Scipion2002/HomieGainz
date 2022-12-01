import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:homiegainz_front_end/util/page_navigation.dart';
import 'package:page_transition/page_transition.dart';
import '../../util/globals.dart' as globals;
import '../../util/requests.dart';
import 'alert_pop_up.dart';
import 'create_account.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    TextEditingController _usernameController = TextEditingController();
    TextEditingController _passwordController = TextEditingController();
    Requests requests = Requests();

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
                                  if (_usernameController.text.isEmpty ||
                                      _passwordController.text.isEmpty) {
                                    showDialog<void>(
                                        context: context,
                                        builder: (BuildContext context) {
                                          return AlertPopUp(
                                            title: 'Login Fields Empty',
                                            content:
                                            'Login Form is not filled out completely',
                                          );
                                        });
                                  } else {
                                    requests
                                        .makeGetRequest(
                                        "http://10.0.2.2:9000/users/login/${_usernameController.text}/${_passwordController.text}")
                                        .then((value){
                                          try{
                                            print(json.decode(value));
                                            if(value.contains("true")){
                                              globals.isLoggedIn = true;
                                              requests
                                                  .makeGetRequest("http://10.0.2.2:9000/users/GetUser/${_usernameController.text}")
                                                  .then((value) {
                                                globals.userID = json.decode(value)['id'];
                                                globals.username = json.decode(value)['username'];
                                                globals.password = json.decode(value)['password'];
                                                globals.email = json.decode(value)['email'];
                                                globals.age = json.decode(value)['age'];
                                                globals.height = json.decode(value)['height'];
                                                globals.weight = json.decode(value)['weight'];
                                                globals.workoutPlanID = json.decode(value)["workoutPlan"]["id"];
                                                globals.mealPlanID = json.decode(value)["mealPlan"]["id"];
                                                _usernameController.text = "";
                                                _passwordController.text = "";
                                                Navigator.push(
                                                    context,
                                                    PageTransition(
                                                      type: PageTransitionType.bottomToTop,
                                                      child: const PageNavigation(),
                                                    ));
                                              });
                                            }
                                          }catch (e){
                                            showDialog<void>(
                                                context: context,
                                                builder: (BuildContext context) {
                                                  return AlertPopUp(
                                                    title: 'Login Failed',
                                                    content:
                                                    'Login Information was incorrect try again',
                                                  );
                                                });
                                          }
                                    });

                                  }
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
