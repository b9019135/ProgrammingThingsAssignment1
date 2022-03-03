#include <Zumo32U4.h>
#include <Wire.h>
#include <PololuBuzzer.h>

Zumo32U4Motors motors;
Zumo32U4LineSensors linedetection;
Zumo32U4Buzzer buzzer;

#define QTR_THRESHOLD 700 // Microseconds (Change depending on lighting and surface conditions)

#define numberofsensors 3
unsigned int linesensorvalues[numberofsensors];


void setup() {
  // put your setup code here, to run once:

  Serial1.begin(9600);
  linedetection.initThreeSensors();

}


void automatic()
{
  linedetection.read(linesensorvalues);

if(linesensorvalues[0] > QTR_THRESHOLD) //left sensor
{
 // buzzer.playNote(NOTE_A(4), 2000, 10);
  reverse();
  delay(300);
  right();
  delay(300);
  forward();
}
else if(linesensorvalues[numberofsensors -1] > QTR_THRESHOLD) //right sensor
{
  //buzzer.playNote(NOTE_B(4), 1000, 10);
  reverse();
  delay(300);
  left();
  delay(100);
  forward();
}
else
{
  forward();
  delay(2);
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
      delay(2);
}
void right()
{
      Serial1.println("Turn right");
      motors.setLeftSpeed(100);
      motors.setRightSpeed(-100);
      delay(2);
}

void hault()
{
  buzzer.playNote(NOTE_C(4), 1000, 10);
  Serial1.println("Stopped");
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
      do{automatic();}while(movecommand != 's');
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

 
