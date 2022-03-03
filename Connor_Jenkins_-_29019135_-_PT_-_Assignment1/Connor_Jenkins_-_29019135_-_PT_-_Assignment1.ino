#include <Zumo32U4.h>
#include <Wire.h>
#include <PololuBuzzer.h>

Zumo32U4Motors motors;
Zumo32U4LineSensors linedetection;
Zumo32U4Buzzer buzzer;

#define QTR_THRESHOLD 700 // Microseconds (Change depending on lighting and surface conditions)

#define numberofsensors 3
unsigned int linesensorvalues[numberofsensors];

boolean runautomatic;
boolean walldetected;

unsigned long leftdetectedcountdown;
unsigned long rightdetectedcountdown;


void setup() {
  // put your setup code here, to run once:

  Serial1.begin(9600);
  linedetection.initThreeSensors();
  runautomatic = false; //controls whether or not the zumo should be ran automatically or manually. false = manual. true = automatic.
  walldetected = false;
  leftdetectedcountdown = 0;
  rightdetectedcountdown = 0;


}


void automatic()
{
  linedetection.read(linesensorvalues);

  detectwall();

  if (walldetected) //if both the left and right sensor has been in contact with a wall within the last 15 ms there is a wall.
  {
    motors.setLeftSpeed(0);
    motors.setRightSpeed(0);
    Serial1.print("1");
    delay(50);
    runautomatic = false;

  } else if (linesensorvalues[0] > QTR_THRESHOLD) //left sensor & left wall
  {
    // buzzer.playNote(NOTE_A(4), 2000, 10);
    reverse();
    delay(300);
    automaticright();
    delay(300);
    automaticforward();
  }
  else if (linesensorvalues[numberofsensors - 1] > QTR_THRESHOLD) //right sensor & right wall
  {
    //buzzer.playNote(NOTE_B(4), 1000, 10);
    reverse();
    delay(300);
    automaticleft();
    delay(300);
    automaticforward();
  }
  else
  {
    forward(); //continue forward.
  }


}

void detectwall() //Manages wall detection.
{
  if (linesensorvalues[0] > QTR_THRESHOLD)
  {
    leftdetectedcountdown = millis(); // begins a timer relating to the left sensor.
  }

  if (linesensorvalues[numberofsensors - 1] > QTR_THRESHOLD)
  {
    rightdetectedcountdown = millis(); // beins a timer relating to the right sensor.
  }

  if (rightdetectedcountdown > 15 && leftdetectedcountdown > 15)
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
    case 'f':
      forward();
      break;
    case 'b':
      reverse();
      break;
    case 'l':
      left();
      break;
    case 'r':
      right();
      break;
    case 's':
      hault();
      break;
    case 'a':
      runautomatic = true;
      break;
    case '7':
      resetwall();
      break;
  }
}


void loop() {

  int control;

  if (Serial1.available() > 0) {
    control = Serial1.read();
    commands(control);
  } else
  {
    if (runautomatic)
    {
      automatic();
    }
  }
}

 
