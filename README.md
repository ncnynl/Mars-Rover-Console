# Mars-Rover-Console
The Rover Console comes in three parts; the ROV, the Camera Control, and ROV control.

#ROV
The ROV is built around an off-the-shelf chassis. It uses and arduino uno with two motor shields and an ethernet shield. It also uses 4 ultrason sensors to detect obsticles infront of it. The ethernet shield provides a link to the network that contains the controlling PC. The motor shields control speed and direction of the motors. The protocal used uses a simple handshake method to ensure that the rover is responding to the data sent by the computer. 

#Camera Control
The camera control side uses an off-the-shelf IP camera along with Blue Iris camera software to provide a first person view of the rover. Kids are able to pan and tilt the camera. This is done using a teensy emulating a keyboard to send the button presses to Blue Iris. The mars Randon Data app is a background application that publishes random data to a text file. This data is read by Blue Iris and displayed as HUD data to the kids.

#Rover Control
The rover control is a PC application written in C# to send and receive data from the rover. It uses UDP to push packets to the rover. The rover replies to the packet upon completion of the given instruction. If data is not received by the rover, the pc handles it as a connection error and allows the user to try again. 
