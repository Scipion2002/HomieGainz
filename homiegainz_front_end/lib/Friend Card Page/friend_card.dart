import 'package:flutter/material.dart';
import 'package:page_transition/page_transition.dart';

class FriendCard extends StatefulWidget {
  FriendCard({Key? key, this.userId = 0, this.username = 'Rxittles'})
      : super(key: key);

  int userId;
  String username;

  @override
  State<FriendCard> createState() => _FriendCardState();
}

class _FriendCardState extends State<FriendCard> {
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
                        icon: const Icon(Icons.keyboard_double_arrow_right_outlined),
                        alignment: Alignment.centerLeft,
                        onPressed: () {
                          // Navigator.push(
                          //   context,
                          //   PageTransition(
                          //       type: PageTransitionType.rightToLeft,
                          //       child: EditInfoPage(editProfileInfo: widget.editProfileInfo, accountInfo: widget.accountInfo,)),
                          // );
                        },
                      ),
                    ],
                  )),
            ],
          ),
        ));
  }
}
