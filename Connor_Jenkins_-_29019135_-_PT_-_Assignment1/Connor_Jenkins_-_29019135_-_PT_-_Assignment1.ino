#include <Zumo32U4.h>
#include <Wire.h>
#include <PololuBuzzer.h>

Zumo32U4Motors motors;
Zumo32U4LineSensors linedetection;
Zumo32U4Buzzer buzzer;

#define QTR_THRESHOLD 700 // Microseconds (Change depending on lighting and surface conditions)

#define numberofsensors 3
unsigned int linesensorvalues[numberofsensors];

boolean walldetected;
unsigned long leftdetectedcountdown;
unsigned long rightdetectedcountdown;


void setup() {
  // put your setup code here, to run once:

  Serial1.begin(9600);
  linedetection.initThreeSensors();
  walldetected = false;
  leftdetectedcountdown = 0;
  rightdetectedcountdown = 0;
  

}
 

void automatic()
{
  linedetection.read(linesensorvalues);

if(linesensorvalues[numberofsensors - 1] > QTR_THRESHOLD)//right sensor & right wall
{
  //buzzer.playNote(NOTE_B(4), 1000, 10);
  reverse();
  delay(300); 
  automaticleft();
  delay(300);
  forward();
  
}else if(linesensorvalues[0] > QTR_THRESHOLD) //left sensor & left wall
{
  // buzzer.playNote(NOTE_A(4), 2000, 10);
  reverse();
  delay(300); 
  automaticright();
  delay(300);
  forward();
}
else if(walldetected) //if both the left and right sensor has been in contact with a wall within the last 30 ms there is a wall.
{
  Serial1.println("Please select a direction then press start again");
  goto pause;
}
else
{
  forward(); //continue forward.
}

pause:
hault();

}

void detectwall()
{
  if(linesensorvalues[0] > QTR_THRESHOLD)
  {
    leftdetectedcountdown = millis();
  }

  if(linesensorvalues[numberofsensors - 1] > QTR_THRESHOLD)
  {
    rightdetectedcountdown = millis();
  }

  if(rightdetectedcountdown > 50 && leftdetectedcountdown > 50)
  {
    walldetected = true;
    leftdetectedcountdown = 0;
    rightdetectedcountdown = 0;
  }
}

void forward()
{
      Serial1.println("Moving forward");
      motors.setLeftSpeed(100);
      motors.setRightSpeed(100);
      delay(2);
}

void reverse()
{
      Serial1.println("Moving backwards");
      motors.setLeftSpeed(-100);
      motors.setRightSpeed(-100);
      delay(2);
}

void left()
{
      Serial1.println("Turn left");
      motors.setLeftSpeed(-100);
      motors.setRightSpeed(100);
      delay(1570); //robot will turn for 1570 ms.
      hault();
      walldetected = false;
}

void automaticleft()
{
      Serial1.println("Turn left");
      motors.setLeftSpeed(-100);
      motors.setRightSpeed(100);
}

void right()
{
      Serial1.println("Turn right");
      motors.setLeftSpeed(100);
      motors.setRightSpeed(-100);
      delay(1570); //robot will turn for 1570 ms.
      hault();
      walldetected = false;
}

void automaticright()
{
      Serial1.println("Turn right");
      motors.setLeftSpeed(100);
      motors.setRightSpeed(-100);
}

void hault()
{
 // buzzer.playNote(NOTE_C(4), 1000, 10);
  motors.setLeftSpeed(0);
  motors.setRightSpeed(0);
  delay(2);
  
}

void commands(int movecommand)
{
    switch(movecommand) {
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
      if(Serial1.read() != 's' || !walldetected)
      {
        while(Serial1.read() != 's' || !walldetected){
        automatic();
        detectwall();
      }
      }
      else
      {
        return;
      }
      break;
    }
}


void loop() {
  
  int incomingcommand =0; //Data incoming from serial.

  if (Serial1.available() > 0) {
    incomingcommand = Serial1.read();
    commands(incomingcommand);
}
}

 
