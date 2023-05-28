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
    switch (seed) {
      case 0:
        {
          return ['A', 'A', 'E', 'E', 'G', 'N'];
        }
      case 1:
        {
          return ['A', 'B', 'B', 'J', 'O', 'O'];
        }
      case 2:
        {
          return ['A', 'C', 'H', 'O', 'P', 'S'];
        }
      case 3:
        {
          return ['A', 'F', 'F', 'K', 'P', 'S'];
        }
      case 4:
        {
          return ['A', 'O', 'O', 'T', 'T', 'W'];
        }
      case 5:
        {
          return ['C', 'I', 'M', 'O', 'T', 'U'];
        }
      case 6:
        {
          return ['D', 'E', 'I', 'L', 'R', 'X'];
        }
      case 7:
        {
          return ['D', 'E', 'L', 'R', 'V', 'Y'];
        }
      case 8:
        {
          return ['D', 'I', 'S', 'T', 'T', 'Y'];
        }
      case 9:
        {
          return ['E', 'E', 'G', 'H', 'N', 'W'];
        }
      case 10:
        {
          return ['E', 'E', 'I', 'N', 'S', 'U'];
        }
      case 11:
        {
          return ['E', 'H', 'R', 'T', 'V', 'W'];
        }
      case 12:
        {
          return ['E', 'I', 'O', 'S', 'S', 'T'];
        }
      case 13:
        {
          return ['E', 'L', 'R', 'T', 'T', 'Y'];
        }
      case 14:
        {
          return ['H', 'I', 'M', 'N', 'U', 'Qu'];
        }
      case 15:
        {
          return ['H', 'L', 'N', 'N', 'R', 'Z'];
        }
    }

    return ['H', 'L', 'N', 'N', 'R', 'Z'];
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

SizedBox getBoggleTile(int value, Random rand) {
  BoggleDie die = BoggleDie(value);
  String faceText = die.getText();
  int rotations = rand.nextInt(4);

  if (rand.nextInt(100) < 60) {
    rotations = 0;
  }

  return SizedBox(
    height: 90,
    width: 90,
    child: RotatedBox(
      quarterTurns: rotations,
      child: Card(
        color: Colors.blueAccent,
        child: Center(
            child: Text(
          faceText,
          textAlign: TextAlign.center,
          style: const TextStyle(fontSize: 45, color: Colors.white),
        )),
      ),
    ),
  );
}

Row getBoggleRow(List<int> values, Random rand) {
  return Row(
    mainAxisAlignment: MainAxisAlignment.spaceAround,
    children: [
      getBoggleTile(values[0], rand),
      getBoggleTile(values[1], rand),
      getBoggleTile(values[2], rand),
      getBoggleTile(values[3], rand),
    ],
  );
}

SizedBox getBoggleBox() {
  Random rand = Random();

  return SizedBox(
    width: 360,
    height: 360,
    child: Column(
      mainAxisAlignment: MainAxisAlignment.spaceAround,
      children: [
        getBoggleRow([0, 1, 2, 3], rand),
        getBoggleRow([4, 5, 6, 7], rand),
        getBoggleRow([8, 9, 10, 11], rand),
        getBoggleRow([12, 13, 14, 15], rand),
      ],
    ),
  );
}

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  final double tileSize = 25;

  SizedBox playGrid = getBoggleBox();

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
            const Row(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                Text(
                  '3:00',
                  style: TextStyle(fontSize: 42),
                ),
                SizedBox(
                  width: 60,
                  height: 60,
                  child: Card(
                    color: Colors.grey,
                    child: Center(
                      child: Icon(
                        Icons.play_arrow,
                        color: Colors.white,
                      ),
                    ),
                  ),
                ),
              ],
            ),
            Container(
              alignment: Alignment.center,
              child: playGrid,
            ),
            const Text(
              '. . .',
              style: TextStyle(fontSize: 42, color: Colors.grey),
            ),
          ],
        ),
        bottomNavigationBar: BottomNavigationBar(
            onTap: (value) => {
                  setState(() {
                    playGrid = getBoggleBox();
                  })
                },
            items: const [
              BottomNavigationBarItem(
                  icon: Icon(Icons.refresh), label: 'refresh'),
              BottomNavigationBarItem(
                  icon: Icon(Icons.settings), label: 'settings'),
            ]),
      ),
    );
  }
}
