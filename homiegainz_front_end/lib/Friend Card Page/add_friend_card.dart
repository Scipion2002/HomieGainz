import 'dart:convert';

import 'package:flutter/material.dart';
import '../../../util/requests.dart';
import '../../../util/globals.dart' as globals;

class AddFriendCard extends StatefulWidget {
  AddFriendCard({Key? key, this.userId = 0, this.username = 'Rxittles'})
      : super(key: key);

  int userId;
  String username;

  @override
  State<AddFriendCard> createState() => _AddFriendCardState();
}

class _AddFriendCardState extends State<AddFriendCard> {
  Requests requests = Requests();
  
  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
        constraints: const BoxConstraints(
          maxWidth: 350,
        ),
        child: Card(
          margin: const EdgeInsets.all(10),
          elevation: 2,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(10),
          ),
          child: Column(
            children: [
              Container(
                  alignment: Alignment.centerLeft,
                  margin: const EdgeInsets.only(left: 15, top: 5, bottom: 5),
                  child: Row(
                    children: [
                      Text(
                        widget.username,
                        style: const TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      const Spacer(),
                      IconButton(
                        icon: const Icon(Icons.add),
                        alignment: Alignment.centerLeft,
                        onPressed: () async {
                          requests.makeGetRequestWithAuth("http://10.0.2.2:9000/friendships/sendFriendRequest/${globals.userID}/${widget.userId}", globals.username, globals.password);
                        },
                      ),
                    ],
                  )),
            ],
          ),
        ));
  }
}
