#include <Bounce.h>
#include <usb_keyboard.h>

const int Up_Pin = 0;
const int Down_Pin = 1;
const int Left_Pin = 2;
const int Right_Pin = 3;
const int Full_Pin = 4;

Bounce UpBounce = Bounce(Up_Pin, 10);
Bounce DownBounce = Bounce(Down_Pin, 10);
Bounce LeftBounce = Bounce(Left_Pin, 10);
Bounce RightBounce = Bounce(Right_Pin, 10);
Bounce FullBounce = Bounce(Full_Pin, 10);

char UpKey = KEY_UP;
char DownKey = KEY_DOWN;
char LeftKey = KEY_LEFT;
char RightKey = KEY_RIGHT;
char FullKey = KEY_F11;


void setup()
{
  pinMode(Up_Pin, INPUT);
  pinMode(Down_Pin, INPUT);
  pinMode(Left_Pin, INPUT);
  pinMode(Right_Pin, INPUT);
  pinMode(Full_Pin, INPUT);
  Serial.begin(9600);
  
}

void loop ()
{
  UpBounce.update();
  DownBounce.update();
  LeftBounce.update();
  RightBounce.update();
  FullBounce.update();
  
  if(UpBounce.risingEdge())
  {
    Keyboard.set_key1(UpKey);
    Keyboard.send_now();  
  }
  
  if (UpBounce.fallingEdge())
  {
    Keyboard.set_key1(0);
    Keyboard.send_now(); 
  }
  
  if(DownBounce.risingEdge())
  {
    Keyboard.set_key2(DownKey);
    Keyboard.send_now();  
  }
  
  if (DownBounce.fallingEdge())
  {
    Keyboard.set_key2(0);
    Keyboard.send_now(); 
  }
  
  if(LeftBounce.risingEdge())
  {
    Keyboard.set_key3(LeftKey);
    Keyboard.send_now();  
  }
  
  if (LeftBounce.fallingEdge())
  {
    Keyboard.set_key3(0);
    Keyboard.send_now(); 
  }
  
  if(RightBounce.risingEdge())
  {
    Keyboard.set_key4(RightKey);
    Keyboard.send_now();  
  }
  
  if (RightBounce.fallingEdge())
  {
    Keyboard.set_key4(0);
    Keyboard.send_now(); 
  }
  
  if (FullBounce.risingEdge())
  {
    Keyboard.set_key4(FullKey);
    Keyboard.send_now();
    
  }
  
    if (FullBounce.fallingEdge())
  {
    Keyboard.set_key4(0);
    Keyboard.send_now();
    
  }
}

