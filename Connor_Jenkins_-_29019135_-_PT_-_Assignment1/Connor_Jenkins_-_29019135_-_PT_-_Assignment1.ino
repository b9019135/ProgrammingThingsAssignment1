#include <Zumo32U4.h>
#include <Wire.h>
#include <PololuBuzzer.h>

Zumo32U4Motors motors;
Zumo32U4LineSensors linedetection; //Used in the assistance of detecting black lines.
Zumo32U4Buzzer buzzer;
Zumo32U4ProximitySensors ObjectDetection; //Used in the assistance of detecting objects.

#define QTR_THRESHOLD 700 // Microseconds (Change depending on lighting and surface conditions)

#define numberofsensors 3
unsigned int linesensorvalues[numberofsensors];

boolean runautomatic;
boolean walldetected;

boolean rightturnmade; //To be used to store whether a left or right turn has been made upon entering a room.
boolean leftturnmade;  //To be used to store whether a left or right turn has been made upon entering a room.

boolean objectfound;  //To be used to store whether an Object has been found within a room.

unsigned long leftdetectedcountdown; //Used in the assistance of detecting walls;
unsigned long rightdetectedcountdown; //Used in the assistance of detecting walls;


void setup() {

  // uncomment if motors incorrect
  //motors.flipLeftMotor(true);
  //motors.flipRightMotor(true);

  Serial1.begin(9600); //Baud rate.


  linedetection.initThreeSensors(); //Initalising line sensors.
  ObjectDetection.initThreeSensors(); //initalising proximity Sensors.

  runautomatic = false; //controls whether or not the zumo should be ran automatically or manually. false = manual. true = automatic.
  walldetected = false; //Handles whether a wall has been detected.
  leftdetectedcountdown = 0; 
  rightdetectedcountdown = 0;

  rightturnmade = false; 
  leftturnmade = false;

  objectfound = true;
}


void automatic() //Includes operations which allow the zumo robot to run autonomously.  
{
  linedetection.read(linesensorvalues); //reading in the line sensor values.

  detectwall(); //Detectwall will be ran continuously.

  if (walldetected) //if both the left and right sensor has been in contact with a wall within the last 15 ms there is a wall.
  {
    motors.setLeftSpeed(0);
    motors.setRightSpeed(0);
    Serial1.print("1"); //Output code 1 represents a wall has been detected.
    delay(50);
    runautomatic = false; //if a wall has been detected the automatic process will be stopped.

  } else if (linesensorvalues[0] > QTR_THRESHOLD) //left sensor & left wall
  {
    // buzzer.playNote(NOTE_A(4), 2000, 10);
    reverse(); //Upon touching a left wall the robot will reverse.
    delay(300);
    automaticright(); //After reversing the robot will turn right.
    delay(300);
    automaticforward(); //It will then continue to move foward.
  }
  else if (linesensorvalues[numberofsensors - 1] > QTR_THRESHOLD) //right sensor & right wall
  {
    //buzzer.playNote(NOTE_B(4), 1000, 10);
    reverse(); //Upon touching a right wall the robot will reverse.
    delay(300);
    automaticleft(); //After reversing the robot will turn right.
    delay(300);
    automaticforward(); //It will then continue to move foward.
  }
  else
  {
    forward(); //continue forward.
  }


}

void detectwall() //Includes operations to assist with wall detection.
{
  if (linesensorvalues[0] > QTR_THRESHOLD) //upon hitting the QTR_Threshhold the leftdetectedcountdown is made to equal the current millis(); (Time since arduino started)
  {
    leftdetectedcountdown = millis(); 
  }

  if (linesensorvalues[numberofsensors - 1] > QTR_THRESHOLD) //upon hitting the QTR_Threshhold the rightdetectedcountdown is made to equal the current millis(); (Time since arduino started)
  {
    rightdetectedcountdown = millis();
  }

  if (rightdetectedcountdown > 15 && leftdetectedcountdown > 15) //
  {
    walldetected = true; //If both sensors reach a value greater than 15, a wall is detected.
  }

  //if a single sensor is only hit, after 50 ms it will be reset.

  if (leftdetectedcountdown > 50)
  {
    leftdetectedcountdown = 0;
  }

  if (rightdetectedcountdown > 50)
  {
    rightdetectedcountdown = 0;
  }
}

void resetwall() //Reset wall occurs when the user tells the robot to turn upon reaching a wall.
{
  walldetected = false;
  rightdetectedcountdown = 0;
  leftdetectedcountdown = 0;
}


void stopforroom() //Stopforroom occurs when the user tells the robot to stopforroom. The user is provided within a popup, where they can either turn left, or turn right.
{
  hault();
}

void searchroom() //Includes operations to assist with searching a room.
{
  objectfound = false; //ensuring objectfound is false upon entering a new room.
  int count = 0;
  forward();
  delay(500);
  hault();

  while (count < 1000) //while the count is less than 1000 the robot will keep turning, the robot should complete a 420 degree turn.
  {
    motors.setLeftSpeed(-100); //zumo robot will do a 420 degree turn and scan the room.
    motors.setRightSpeed(100);
    Detection(); //detection is ran alongside the turning.
    count++;
  }
  if (count >= 1000) //once the count is greater than 1000, the zumo will stop, then return to the path.
  {
    hault();
    Serial1.print("h");
    delay(300);
    if (rightturnmade = true) //if a right turn was made upon entry, a right turn is required upon exit.
    {
      forward();
      delay(500);
      right();
      delay(50);
      automatic();
      rightturnmade = false;
    }
    else if (leftturnmade = true) //if a left turn was made upon entry, a left turn is required upon exit.
    {
      forward();
      delay(500);
      left();
      delay(50);
      automatic();
      leftturnmade = false;
    }

  }
}

void Detection() //Includes operations to assist with object detection.
{
  int right_sensor = 0;
  int left_sensor = 0;
  ObjectDetection.read(); //reads the proximity sensors.
  right_sensor = ObjectDetection.countsFrontWithRightLeds(); //assigning the Right Sensor to the right_sensor variable.
  left_sensor = ObjectDetection.countsFrontWithLeftLeds();   //assigning the left Sensor to the left_sensor variable.

  if (left_sensor >= 5 || right_sensor >= 5) //If the value read, is greater than 5, we assume an object as been detected. Else we assume no object has been detected.
  {
    Serial1.print("o"); //Output code o represents an object has been detected.
    objectfound = true; //if an object has been detected, object found is set as true.
  } else
  {
    Serial1.print("p"); //Output code p represents no object has been detected.
  }

}

void returnback() //Includes operations to assist in the return of the zumo upon reaching the end of a T juction.
{
  motors.setLeftSpeed(-100);
  motors.setRightSpeed(100);
  delay(4000);
  automatic();
}

void forward() //Manual control - Zumo moves forward.
{
  Serial1.print("2");
  delay(50);
  motors.setLeftSpeed(100);
  motors.setRightSpeed(100);
  delay(2);
}

void automaticforward() //automatic control - Zumo moves forward and repeats the automatic process.
{
  Serial1.print("2");
  delay(50);
  motors.setLeftSpeed(100);
  motors.setRightSpeed(100);
  automatic();

}

void reverse() //manual control - zumo moves in reverse.
{
  Serial1.print("3");
  delay(50);
  motors.setLeftSpeed(-100);
  motors.setRightSpeed(-100);
  delay(2);
}

void left() //manual control - zumo turns left then stops.
{
  Serial1.print("4");
  delay(50);
  motors.setLeftSpeed(-100);
  motors.setRightSpeed(100);
  delay(1570); //robot will turn for 1570 ms.
  hault();
}

void automaticleft() //Automatic control - zumo will keep turning left until it is clear.
{
  Serial1.print("4");
  delay(50);
  motors.setLeftSpeed(-100);
  motors.setRightSpeed(100);
}

void right() //manual control - zumo turns right then stops.
{
  Serial1.print("5");
  delay(50);
  motors.setLeftSpeed(100);
  motors.setRightSpeed(-100);
  delay(1570); //robot will turn for 1570 ms.
  hault();

}

void automaticright() //Automatic control - zumo will keep turning right until it is clear.
{
  Serial1.print("5");
  delay(50);
  motors.setLeftSpeed(100);
  motors.setRightSpeed(-100);
}

void hault() // Everything haults. The zumo comes to a standstill.
{
  Serial1.print("6");
  delay(50);
  // buzzer.playNote(NOTE_C(4), 1000, 10);
  motors.setLeftSpeed(0);
  motors.setRightSpeed(0);
  delay(2);
  runautomatic = false;
}

void commands(int control) // manages the users inputs from the GUI.
{
  switch (control) {
    case 'f':  //Output code f represents forward
      forward();
      break;
    case 'b': //Output code b represents reversing
      reverse();
      break;
    case 'l': //Output code l represents left
      left();
      break;
    case 'r': //Output code r represents right
      right();
      break;
    case 's': //Output code s represents stop
      hault();
      break;
    case 'a': //Output code a represents automatic.
      runautomatic = true;
      break;
    case '7': //Output code 7  represents reset detected wall.
      resetwall();
      break;
    case '8': //Output code 8 represents stop for a room
      stopforroom();
      break;
    case '9': //Output code 9 represents search a room.
      searchroom();
      break;
    case '10': ////Output code 10 represents a rightturn being made.
      rightturnmade = true;
      break;
    case '11': //Output code 11 represents a left turn being made.
      leftturnmade = true;
      break;
    case 'v': //Output code v represents the returning of a zumo at a T juction.
      returnback();
      break;

  }
}

void loop() {

  int control; //contains the command sent by the user.

  if (Serial1.available() > 0) {
    control = Serial1.read(); 
    commands(control); //The incoming command is passed into a switch.
  } else
  {
    if (runautomatic) //Upon selecting automatic within the UI, runautomatic is set to true, and the automatic process is ran.
    {
      automatic();
    }
  }
}
