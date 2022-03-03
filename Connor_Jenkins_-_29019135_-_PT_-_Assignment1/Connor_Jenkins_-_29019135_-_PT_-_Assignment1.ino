#include <Zumo32U4.h>


Zumo32U4Motors motors;


void setup() {
  // put your setup code here, to run once:

  Serial1.begin(9600);
  Serial.begin(9600);

}

void loop() {
  // put your main code here, to run repeatedly:

  int incomingcommand =0; //Data incoming from serial.

  if (Serial1.available() > 0) {

    incomingcommand = Serial1.read();

    switch(incomingcommand) {
      case 'f':
      motors.setLeftSpeed(100);
      motors.setRightSpeed(100);
      delay(2);
      break;
      case 'b':
      motors.setLeftSpeed(-100);
      motors.setRightSpeed(-100);
      delay(5);
      break;
      case 'l':
      motors.setLeftSpeed(100);
      motors.setRightSpeed(0);
      delay(5);
      break;
      case 'r':
      motors.setLeftSpeed(0);
      motors.setRightSpeed(100);
      delay(5);
      break;
      case 's':
      motors.setLeftSpeed(0);
      motors.setRightSpeed(0);
      delay(5);
      break;
    }


  }
    
  }

 
