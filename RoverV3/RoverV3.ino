/*
  UDPSendReceive.pde:
 This sketch receives UDP message strings, prints them to the serial port
 and sends an "acknowledge" string back to the sender

 A Processing sketch is included at the end of file that can be used to send
 and received messages for testing with a computer.

 created 21 Aug 2010
 by Michael Margolis

 This code is in the public domain.
 */


#include <SPI.h>         // needed for Arduino versions later than 0018
#include <Ethernet.h>
#include <EthernetUdp.h>         // UDP library from: bjoern@cs.stanford.edu 12/30/2008


// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
byte mac[] = {
  0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED
};
IPAddress ip(192, 168, 0, 104);

unsigned int localPort = 8888;      // local port to listen on

// buffers for receiving and sending data
char packetBuffer[UDP_TX_PACKET_MAX_SIZE]; //buffer to hold incoming packet,
char  ReplyBuffer[] = "acknowledged";       // a string to send back

char inbound[UDP_TX_PACKET_MAX_SIZE];

// An EthernetUDP instance to let us send and receive packets over UDP
EthernetUDP Udp;



//Motor Parameters

const int MotoSpeed = 200; //Motor Speed
const int RunTime = 500;

const int FLMoto = 3; //Motor Enable
const int FLDir = 2;  //Motor Direction

const int FRMoto = 5; //Enable
const int FRDir = 4; //Direction

const int RLMoto = 6; //Enable
const int RLDir = 7; //Direction

const int RRMoto = 9; //Enable
const int RRDir = 8; //Direction

const int Sonar1 = A1; //Sonar1
const int Sonar2 = A2; //     2
const int Sonar3 = A3; //     3
const int Sonar4 = A4; //     4



void setup() {

  pinMode(FLMoto, OUTPUT);
  pinMode(FLDir, OUTPUT);
  pinMode(FRMoto, OUTPUT);
  pinMode(FRDir, OUTPUT);
  pinMode(RLMoto, OUTPUT);
  pinMode(RLDir, OUTPUT);
  pinMode(RRMoto, OUTPUT);
  pinMode(RRDir, OUTPUT);
  
  //Set soanr pins for input
  pinMode(Sonar1, INPUT);
  pinMode(Sonar2, INPUT);
  pinMode(Sonar3, INPUT);
  pinMode(Sonar4, INPUT);
  
  // start the Ethernet and UDP:
  Ethernet.begin(mac, ip);
  Udp.begin(localPort);

  Serial.begin(9600);
}

void loop() {
  // if there's data available, read a packet
  int packetSize = Udp.parsePacket();
  if (packetSize)
  {
    Serial.print("Received packet of size ");
    Serial.println(packetSize);
    Serial.print("From ");
    IPAddress remote = Udp.remoteIP();
    for (int i = 0; i < 4; i++)
    {
      Serial.print(remote[i], DEC);
      if (i < 3)
      {
        Serial.print(".");
      }
    }
    Serial.print(", port ");
    Serial.println(Udp.remotePort());

    // read the packet into packetBufffer
    Udp.read(packetBuffer, UDP_TX_PACKET_MAX_SIZE);
    Serial.println("Contents:");
    Serial.println(packetBuffer);

    if (packetBuffer[0] == 'R')
    {
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('R');
       Udp.endPacket();
    }

    if (packetBuffer[0] == 'W')
    {
      if (analogRead(Sonar1) > 15)
      {
        digitalWrite(FLDir, HIGH);
        digitalWrite(FRDir, LOW);
        digitalWrite(RLDir, HIGH);
        digitalWrite(RRDir, LOW);
        
        for (int i = 0; i <= MotoSpeed; i++)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        delay(RunTime);
        
        for (int i = MotoSpeed; i >= 0; i--)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        digitalWrite(FLMoto, LOW);
        digitalWrite(FRMoto, LOW);
        digitalWrite(RLMoto, LOW);
        digitalWrite(RRMoto, LOW);
      
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('C');
       Udp.endPacket();
      }
      else
      {
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('O');
       Udp.endPacket();
      }
    }

   if (packetBuffer[0] == 'S')
    {
      if (analogRead(Sonar2) > 15)
      {
      digitalWrite(FLDir, LOW);
      digitalWrite(FRDir, HIGH);
      digitalWrite(RLDir, LOW);
      digitalWrite(RRDir, HIGH);
      
      for (int i = 0; i <= MotoSpeed; i++)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        delay(RunTime);
        
        for (int i = MotoSpeed; i >= 0; i--)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        digitalWrite(FLMoto, LOW);
        digitalWrite(FRMoto, LOW);
        digitalWrite(RLMoto, LOW);
        digitalWrite(RRMoto, LOW);
      
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('C');
       Udp.endPacket();
      }
      else
      {
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('O');
       Udp.endPacket();
      }
    }

         if (packetBuffer[0] == 'Q')
    {
      if (analogRead(Sonar2) > 15 && analogRead(Sonar3) > 15 && analogRead(Sonar1) >15 && analogRead(Sonar4) > 15)
      {
      digitalWrite(FLDir, LOW);
      digitalWrite(FRDir, LOW);
      digitalWrite(RLDir, LOW);
      digitalWrite(RRDir, LOW);
      
      for (int i = 0; i <= MotoSpeed; i++)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        delay(RunTime*(2/3));
        
        for (int i = MotoSpeed; i >= 0; i--)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        digitalWrite(FLMoto, LOW);
        digitalWrite(FRMoto, LOW);
        digitalWrite(RLMoto, LOW);
        digitalWrite(RRMoto, LOW);
      
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('C');
       Udp.endPacket();
      }
      else
      {
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('O');
       Udp.endPacket();
      }
    }
    
    //If E, Check All Sonars, If safe move motor and reply with 'C', otherwise reply with 'O'
    if (packetBuffer[0] == 'E')
    {
      if (analogRead(Sonar2) > 15 && analogRead(Sonar3) > 15 && analogRead(Sonar1) >15 && analogRead(Sonar4) > 15)
      {
      digitalWrite(FLDir, HIGH);
      digitalWrite(FRDir, HIGH);
      digitalWrite(RLDir, HIGH);
      digitalWrite(RRDir, HIGH);
      
      for (int i = 0; i <= MotoSpeed; i++)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        delay(RunTime*(2/3));
        
        for (int i = MotoSpeed; i >= 0; i--)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        digitalWrite(FLMoto, LOW);
        digitalWrite(FRMoto, LOW);
        digitalWrite(RLMoto, LOW);
        digitalWrite(RRMoto, LOW);
      
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('C');
       Udp.endPacket();
      }
      else
      {
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('O');
       Udp.endPacket();
      }
    }
    
        //If A, Check Left Side Sonar, If safe move motor and reply with 'C', otherwise reply with 'O'
        if (packetBuffer[0] == 'A')
    {
      if (analogRead(Sonar4) > 15)
      {  
      digitalWrite(FLDir, LOW);
      digitalWrite(FRDir, LOW);
      digitalWrite(RLDir, HIGH);
      digitalWrite(RRDir, HIGH);
      
      for (int i = 0; i <= MotoSpeed; i++)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        delay(RunTime);
        
        for (int i = MotoSpeed; i >= 0; i--)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        digitalWrite(FLMoto, LOW);
        digitalWrite(FRMoto, LOW);
        digitalWrite(RLMoto, LOW);
        digitalWrite(RRMoto, LOW);
      
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('C');
       Udp.endPacket();
      }
      else
      {
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('O');
       Udp.endPacket();
      }
    }
    
        //If D, Check Right Side Sonar, If safe move motor and reply with 'C', otherwise reply with 'O'
        if ( packetBuffer[0] == 'D')
    {
      if (analogRead(Sonar3) > 15)
      {
      digitalWrite(FLDir, HIGH);
      digitalWrite(FRDir, HIGH);
      digitalWrite(RLDir, LOW);
      digitalWrite(RRDir, LOW);
      
      for (int i = 0; i <= MotoSpeed; i++)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        delay(RunTime);
        
        for (int i = MotoSpeed; i >= 0; i--)
        {
          analogWrite(FLMoto, i);
          analogWrite(FRMoto, i);
          analogWrite(RLMoto, i);
          analogWrite(RRMoto, i);
          delay (1);
          
        } 
      
        digitalWrite(FLMoto, LOW);
        digitalWrite(FRMoto, LOW);
        digitalWrite(RLMoto, LOW);
        digitalWrite(RRMoto, LOW);
      
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('C');
       Udp.endPacket();
      }
      else
      {
       Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
       Udp.write('O');
       Udp.endPacket();
      }
    }

    

  }
  delay(10);
}


/*
  Processing sketch to run with this example
 =====================================================

 // Processing UDP example to send and receive string data from Arduino
 // press any key to send the "Hello Arduino" message


 import hypermedia.net.*;

 UDP udp;  // define the UDP object


 void setup() {
 udp = new UDP( this, 6000 );  // create a new datagram connection on port 6000
 //udp.log( true ); 		// <-- printout the connection activity
 udp.listen( true );           // and wait for incoming message
 }

 void draw()
 {
 }

 void keyPressed() {
 String ip       = "192.168.1.177";	// the remote IP address
 int port        = 8888;		// the destination port

 udp.send("Hello World", ip, port );   // the message to send

 }

 void receive( byte[] data ) { 			// <-- default handler
 //void receive( byte[] data, String ip, int port ) {	// <-- extended handler

 for(int i=0; i < data.length; i++)
 print(char(data[i]));
 println();
 }
 */


