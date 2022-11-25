import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:homiegainz_front_end/Login/questionaire_page.dart';
import '../util/requests.dart';
import 'alert_pop_up.dart';
import '../util/to_prev_page.dart';
import '../../util/globals.dart' as globals;

class CreateAccount extends StatelessWidget {

  const CreateAccount({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    TextEditingController _usernameController = TextEditingController();
    TextEditingController _emailController = TextEditingController();
    TextEditingController _weightController = TextEditingController();
    TextEditingController _heightController = TextEditingController();
    TextEditingController _ageController = TextEditingController();
    TextEditingController _passwordController = TextEditingController();
    TextEditingController _confirmPasswordController = TextEditingController();
    Requests requests = Requests();

    return SafeArea(
        child: Scaffold(
            body: SingleChildScrollView(
                child: Column(children: [
      const ToPrevPage(),
      Container(
        margin: const EdgeInsets.only(top: 7),
        child:
            const Image(image: AssetImage("assets/images/HomieGainzImg.png")),
      ),
      const Center(
        heightFactor: 2,
        child: Text(
          "Create Account",
          textAlign: TextAlign.center,
          style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
        ),
      ),
        Container(
            margin: const EdgeInsets.only(top: 35, left: 15, right: 15),
            child: TextField(
              controller: _usernameController,
              decoration: const InputDecoration(
                  prefixIcon:
                      Icon(Icons.account_circle_outlined, color: Colors.grey),
                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(color: Colors.tealAccent),
                  ),
                  enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.grey)),
                  hintText: 'Enter Username...',
                  labelText: 'Enter Username',
                  labelStyle: TextStyle(color: Colors.grey)),
            )),
        Container(
            margin: const EdgeInsets.only(top: 35, left: 15, right: 15),
            child: TextField(
              controller: _emailController,
              decoration: const InputDecoration(
                  prefixIcon: Icon(Icons.email, color: Colors.grey),
                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(color: Colors.tealAccent),
                  ),
                  enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.grey)),
                  hintText: 'Enter Email...',
                  labelText: 'Enter Email',
                  labelStyle: TextStyle(color: Colors.grey)),
            )),
                  Container(
                      margin: const EdgeInsets.only(top: 35, left: 15, right: 15),
                      child: TextField(
                        controller: _weightController,
                        decoration: const InputDecoration(
                            prefixIcon:
                            Icon(FontAwesomeIcons.weightScale, color: Colors.grey),
                            focusedBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.tealAccent),
                            ),
                            enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.grey)),
                            hintText: 'Enter Weight...',
                            labelText: 'Enter Weight',
                            labelStyle: TextStyle(color: Colors.grey)),
                      )),
                  Container(
                      margin: const EdgeInsets.only(top: 35, left: 15, right: 15),
                      child: TextField(
                        controller: _heightController,
                        decoration: const InputDecoration(
                            prefixIcon:
                            Icon(FontAwesomeIcons.ruler, color: Colors.grey),
                            focusedBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.tealAccent),
                            ),
                            enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.grey)),
                            hintText: 'Enter Height...',
                            labelText: 'Enter Height',
                            labelStyle: TextStyle(color: Colors.grey)),
                      )),
        Container(
            margin: const EdgeInsets.only(top: 35, left: 15, right: 15),
            child: TextField(
              controller: _ageController,
              decoration: const InputDecoration(
                  prefixIcon:
                      Icon(Icons.calendar_today_outlined, color: Colors.grey),
                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(color: Colors.tealAccent),
                  ),
                  enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.grey)),
                  hintText: 'Enter Age...',
                  labelText: 'Enter Age',
                  labelStyle: TextStyle(color: Colors.grey)),
            )),
        Container(
            margin: const EdgeInsets.only(top: 35, left: 15, right: 15),
            child: TextField(
              controller: _passwordController,
              obscureText: true,
              decoration: const InputDecoration(
                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(color: Colors.tealAccent),
                  ),
                  enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.grey)),
                  prefixIcon: Icon(Icons.lock_outline, color: Colors.grey),
                  hintText: 'Enter Password...',
                  labelText: 'Enter Password',
                  labelStyle: TextStyle(color: Colors.grey)),
            )),
        Container(
            margin: const EdgeInsets.only(top: 35, left: 15, right: 15),
            child: TextField(
              obscureText: true,
              controller: _confirmPasswordController,
              decoration: const InputDecoration(
                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(color: Colors.tealAccent),
                  ),
                  enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.grey)),
                  prefixIcon: Icon(Icons.lock_outline, color: Colors.grey),
                  hintText: 'Confirm Password...',
                  labelText: 'Confirm Password',
                  labelStyle: TextStyle(color: Colors.grey)),
            )),
        Container(
            margin: const EdgeInsets.only(top: 10),
            alignment: Alignment.center,
            child: ElevatedButton(
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.tealAccent, // background
                ),
                onPressed: () {
                  // Checking to see if form is complete
                  if (_usernameController.text.isEmpty ||
                      _emailController.text.isEmpty ||
                      _weightController.text.isEmpty ||
                      _heightController.text.isEmpty ||
                      _ageController.text.isEmpty ||
                      _passwordController.text.isEmpty ||
                      _confirmPasswordController.text.isEmpty) {
                    showDialog<void>(
                        context: context,
                        builder: (BuildContext context) {
                          return AlertPopUp(
                            title: 'Incomplete Form',
                            content:
                                'Please check all fields have been filled out correctly',
                          );
                        });
                  } else {
                    if (_passwordController.text !=
                        _confirmPasswordController.text) {
                      showDialog<void>(
                          context: context,
                          builder: (BuildContext context) {
                            return AlertPopUp(
                              title: 'Passwords Do Not Match',
                              content:
                                  'Please check that password and confirm password match',
                            );
                          });
                    }
                    else{
                      Map<String, dynamic> newUser = {
                        "name": _usernameController.text,
                        "username": _usernameController.text,
                        "password": _passwordController.text,
                        "email": _emailController.text,
                        "weight" : _weightController.text,
                        "height" : _heightController.text,
                        "age": _ageController.text,
                      };

                      requests
                          .makePostRequest("http://10.0.2.2:9000/users", newUser)
                      .then((value) {
                        print(json.decode(value));
                        globals.userID = json.decode(value)['id'];
                        globals.username = json.decode(value)['username'];
                        globals.password = json.decode(value)['password'];
                        print(globals.userID);
                        print(globals.username);
                        print(globals.password);
                      });

                      Navigator.of(context).pushAndRemoveUntil(
                          MaterialPageRoute(
                              builder: (context) => const QuestionnairePage()),
                              (Route<dynamic> route) => false);
                    }
                  }
                },
                child: const Text('Sign Up',
                    style: TextStyle(color: Colors.black))))
      ])))
            );
  }
}
