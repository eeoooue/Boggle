import 'package:flutter/material.dart';
import 'dart:math';

void main() {
  runApp(const MyApp());
}

class BoggleDie {
  int seed = 0;
  BoggleDie(int pSeed) {
    seed = pSeed;
  }

  List<String> getOptions() {
    List<String> options = List.filled(6, "X");
    options[0] = "A";
    options[1] = "B";
    options[2] = "C";
    options[3] = "D";
    options[4] = "E";
    options[5] = "F";

    return options;
  }

  String getText() {
    Random rand = Random();
    int i = rand.nextInt(6);

    List<String> options = getOptions();
    return options[i];
  }
}

int getBoggleDie(int i) {
  return i;
}

String getRandomBoggleFace() {
  return 'X';
}

SizedBox getBoggleTile(int value) {
  BoggleDie die = BoggleDie(value);
  // String faceText = getRandomBoggleFace();
  String faceText = die.getText();

  return SizedBox(
    height: 90,
    width: 90,
    child: Card(
      color: Colors.red,
      child: Center(
          child: Text(
        faceText,
        textAlign: TextAlign.center,
        style: const TextStyle(fontSize: 42),
      )),
    ),
  );
}

Row getBoggleRow(List<int> values) {
  return Row(
    mainAxisAlignment: MainAxisAlignment.spaceAround,
    children: [
      getBoggleTile(values[0]),
      getBoggleTile(values[1]),
      getBoggleTile(values[2]),
      getBoggleTile(values[3]),
    ],
  );
}

SizedBox getBoggleBox() {
  List<int> values0 = List.filled(4, 0);
  List<int> values1 = List.filled(4, 0);
  List<int> values2 = List.filled(4, 0);
  List<int> values3 = List.filled(4, 0);

  return SizedBox(
    width: 360,
    height: 360,
    child: Column(
      mainAxisAlignment: MainAxisAlignment.spaceAround,
      children: [
        getBoggleRow(values0),
        getBoggleRow(values1),
        getBoggleRow(values2),
        getBoggleRow(values3),
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
