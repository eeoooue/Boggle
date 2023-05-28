import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

String getRandomBoggleFace() {
  return 'X';
}

Container getBoggleTile() {
  String faceText = getRandomBoggleFace();

  return Container(
    color: Colors.white,
    alignment: Alignment.center,
    child: SizedBox(
      width: 72,
      height: 72,
      child: Align(
        alignment: Alignment.center,
        child: Text(
          textAlign: TextAlign.center,
          faceText,
          style: const TextStyle(fontSize: 36),
        ),
      ),
    ),
  );
}

Row getBoggleRow() {
  return Row(
    mainAxisAlignment: MainAxisAlignment.spaceAround,
    children: [
      getBoggleTile(),
      getBoggleTile(),
      getBoggleTile(),
      getBoggleTile(),
    ],
  );
}

SizedBox getBoggleBox() {
  return SizedBox(
    width: 360,
    height: 360,
    child: Column(
      mainAxisAlignment: MainAxisAlignment.spaceAround,
      children: [
        getBoggleRow(),
        getBoggleRow(),
        getBoggleRow(),
        getBoggleRow(),
      ],
    ),
  );
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  final double tileSize = 25;

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Word Search'),
          backgroundColor: Colors.blueAccent,
        ),
        body: Column(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            const Text(
              '3:00',
              style: TextStyle(fontSize: 42),
            ),
            Container(
              alignment: Alignment.center,
              color: const Color.fromARGB(255, 219, 219, 219),
              child: getBoggleBox(),
            ),
            const Text(
              '? ? ?',
              style: TextStyle(fontSize: 42, color: Colors.grey),
            ),
          ],
        ),
        bottomNavigationBar: BottomNavigationBar(items: const [
          BottomNavigationBarItem(icon: Icon(Icons.refresh), label: 'refresh'),
          BottomNavigationBarItem(
              icon: Icon(Icons.settings), label: 'settings'),
        ]),
      ),
    );
  }
}
