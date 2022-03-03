# ProgrammingThingsAssignment1
Repos for ProgrammingThings Assignment1
CONNOR JENKINS PROGRAMMING THINGS ASSIGNMENT 1 - ZUMO-SEARCH&RESCUE

Tasks : 

Task 1: Manual control of the Zumo.
The Zumo can be driven down the corridor from a GUI* (see comments below) e.g. using w, a, s, d and
‘stop’ ‘buttons’ or a text field. You are controlling the Zumo at this point. Communication is via the xBee
communication channel (not over a USB cable).

Task 2: Autonomous control of the Zumo
The Zumo automatically keeps within the corridor by using the line sensors to turn away from the walls (this
is an adaptation of the boundary checking and line-following examples looked at in the tutorials). This
means you only start the Zumo moving; after that, it is navigating itself along the corridor. It stops when it
encounters a ‘wall’ in front of it (i.e. comes to a corner). If Zumo hits one of the side walls of the corridor, it
modifies its path to keep within the walls of the corridor.

Task 3: Turning Corners
At the end of task 2, the Zumo recognises that it has reached a corner and stops. It should then return
manual control to the human navigator (you) by:
1. Sending a message using the XBee indicating that fact. The messages received from the Zumo
should appear in a text area in the GUI.
2. It then deactivates the autonomous behaviour from task 2 (which is keeping the Zumo between the
corridor walls); this allows the (human) controller to turn the robot. When that turn is complete, the
human navigator (you) signals that by sending another keypress (eg 'C' or 'c' for complete).
3. This then reactivates the autonomous behaviour of task 2, so that the Zumo can drive itself down
the corridor again.

Task 4: The Zumo turns autonomously around a corner
This is an extension of Task 3. When the Zumo recognises it is at the end of a corridor (such as at the end of
task 2), it sends a message through the XBee that appears in the text area on the GUI, the same as for task 3.
The user can then press 'L' or 'R' to rotate the Zumo 90° to the left or 90° to the right. To complete the
rotation and the movements, wheel position encoders can be used to measure the space covered by each
wheel. Additionally, the on board gyroscope may be used to sense the rotation. Once the turn is complete,
the Zumo should automatically return to the autonomous behaviour of task 2, so that the Zumo can drive
itself down the corridor again.

Task 5: The Zumo searches a room.
The (human) navigator will first stop the robot (outside the room) and then signal that the robot is about to
enter a room by sending an appropriate button press or text field data (e.g. “Ro” for room and 'R' or ‘L’ for
right/left). The Zumo will then use the rotation algorithm from task 4 to rotate towards the room to perform
a search. An appropriate message should appear in the GUI, giving that room a number and identifying
whether the room is on the left or right of the corridor. The Zumo should also record that information. The
Zumo should then (autonomously) move into the room to perform a scan of the room, using the proximity
sensors, for objects. Depending on the size of the room, proximity sensors may require the Zumo to roam
the room to complete the search. If an object is detected, the Zumo reports that back using the XBee link.
This report needs to be seen inside the GUI you have created. The message should identify which room the
object is in. After the scan is complete, the Zumo should return back into the corridor autonomously, using
the wheel encoders to identify its position.

Task 6: The T-junction
In the T-junction, you can turn either way and search the remaining corridor and rooms as in Tasks 4 & 5.
However, depending which way you have turned, when you reach the end of the corridor, the Zumo should
stop and wait until it is told to turn around and retrace it’s steps (using the ‘B’ key to initiate a 180 degree
turn). The Zumo turns around and then goes to search the other half of the corridor. It should navigate the
half of the corridor just searched, autonomously, and ignore any instructions to turn into rooms or back
down the main corridor. These instructions must be sent though, so that the robot knows it has passed 

Overview

This Github respository includes both the GUI and the Arduino code for the Programming Things assignment : Search & rescue. Above are the required tasks to be completed. Below i have mentioned the tasks i have attempted.

Included with this repository is a PDF report, documenting additional information surrounding the work produced. A youtube video previewing the functionality of the UI and the zumo completing certain tasks. 

Below i have also included a table noting the different input codes related to my code for easier referencing and additional relevant information. 


Tasks Attempted:
Task 1  : Task 2 : Task 3 : Task 4 : Task 5

Tasks Unattempted:
Task 6 : Task 7

Youtube Link to demonstration


Additional Information

Receiver Codes

1 = Wall Detected.
2 = Forward
3 = Reverse
4 = Left
5 = Right
6 = Stopped
7 = reset wall detected
8 = Stop for a room
9 = Search a room.
10 = Right turn was made.
11 = Left turn was made.
12 = objectwasfound.

To use the ZUMO GUI follow the following Instructions.
-Ensure the Xbee module is plugged into the host device.
-Open the ZUMO GUI.exe.
-Select the Com PORT with the Xbee Module, the baud rate doesn’t need changing.
*If the Com port with the Xbee module cannot be found, re-plug the Xbee module, and restart the GUI*
-Once the com Port has been selected, click Open. The Xbee module and your zumo should then been connected.
You are then able to use any of the functions available on the GUI.


