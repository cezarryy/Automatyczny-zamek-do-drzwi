#include <SPI.h>  //importowanie bibliotek
#include <MFRC522.h>
#include <IRremote.h>
#define trigPin A2  //wybor pinow
#define echoPin A1
#define doszlo 6
#define MotorL 8
#define MotorR 4
#define closed 7
#define otwarte 5
#define SS_PIN 10
#define RST_PIN 9
const int RECV_PIN = 3;

IRrecv irrecv(RECV_PIN);          //stworzenie obiektu irrecv i przypisanie pinu, przez ktory dochodzi do odbioru sygnalu(odbiornik w układzie TSOP31236) z nadajnika IR(pilot)
decode_results results;           //stworzenie obiektu klasy decode_results, który bedzie uzywany przez obiekt irrecv do przekazywania informacji do programu. 
MFRC522 rfid(SS_PIN, RST_PIN);     // stworzenie obiektu MFRC522 

// DEKLARACJA TABLICY Z NUMERAMI KART  ***********************************************************************************************************************

String idnumber="";     //zmienna ktora bedzie zapisywac aktualnie odczytany kod przylozonej karty
String karta[4] = {"00000000", "00000000","00000000","00000000"};

//DEKLARACJA ZMIENNYCH ******************************************************************************************

 bool access = false; 
 int odleglosc;
 int czyDoszlo;
 int czyZamkniete;
 int czyOtwarte;
 int TrwaZamykanie=0;
 int TrwaOtwieranie=0;
 int marker = 0;
 String inputString="";
 boolean stringComplete=false;
 String commandString="";
 char buf[33];
 int IRcode=0;

//
void setup() 
{
  Serial.begin(9600);   //ustawienie predkosci transmisji
  SPI.begin();          //inicjacja magistrali SPI
  rfid.PCD_Init();      //inicjacja wczesniej stworzonego obiektu MFRC522

  //czujnik HC-SR04, ustawienie funkcji pinow
  pinMode(trigPin, OUTPUT); //Pin wyzwalajacy  
  pinMode(echoPin, INPUT); //Pin echo, będacy wejsciem zwraca obliczona wartosc
  
  //*piny do ktorych podlaczane sa krancowki, domyslnie stan wysoki a w momencie zalaczenia podciagane do masy.
  pinMode(closed, INPUT_PULLUP);    //zamkniecie
  pinMode(otwarte, INPUT_PULLUP);   //otwarcie
  pinMode(doszlo, INPUT_PULLUP);    // domknięcie *//

  //Ustawienie funkcji pinow sterujacych kierunkiem silnika
  pinMode(MotorL, OUTPUT);      
  pinMode(MotorR, OUTPUT);
  
}

// GŁÓWNA PETLA PROGRAMU*************************************************************************************
void loop() {  
   // Odczyt stanow logicznych na pinach i zmierzenie odleglosci
  czyOtwarte=digitalRead(otwarte);
  odleglosc=zmierzOdleglosc();
  czyDoszlo=digitalRead(doszlo);
  czyZamkniete=digitalRead(closed);
  
 //ODBIERANIE SYGNALU PODCZERWIENI************************************************* 
  if (czyZamkniete==0  ){
     irrecv.enableIRIn();   //aktywacja odbierania sygnału(tylko jesli drzwi zamkniete)
     delay(200);
  }
  
   if (irrecv.decode(&results) ) //zapisanie odebranego kodu
   {
    irrecv.resume();  //zresetuj odbiornik i przygotuj do odebrania nastepnego kodu
    
    delay(100);

    IRcode=results.value;     //przypisz odczytana wartosc do zmiennej IRcode
  }
  
// ODCZYT KART  ***********************************************************************************************************************

 if (rfid.PICC_IsNewCardPresent() && rfid.PICC_ReadCardSerial())      //wczytanie przylozoenej do czujnika karty
  {  

    //odczytanie segmentow kodu karty zapisanej szesnastokowo i zapisanie w zmiennej idnumber
    
   for(int i=0;i<=3;i++) 
   {
    idnumber += String(rfid.uid.uidByte[i],HEX);
                      
   }
 
    for(int j=0;j<sizeof(buf);j++)  //zerowanie tablicy buf
       { buf[j] = 0;
       }

// PORÓWNYWANIE KART Z BAZĄ  ***********************************************************************************************************************
     for(int x = 0; x < sizeof(karta)/sizeof(karta[0]); x++)
     {

                  if( String(idnumber)==String(karta[x])&&(czyOtwarte==1 && czyZamkniete ==0 && TrwaZamykanie==0 && TrwaOtwieranie==0))
                   {
                    marker = x+1;
                    itoa(marker,buf,10); //zapisanie przekonwertowanej wartosci marker do buf przesylanej nizej do programu z interfejsem
                    Serial.write(buf);
                    delay(400);
                    access = true;
                    break;
                   }  
                  
      }

            idnumber="";
             if (access == false&&(czyOtwarte==1 && czyZamkniete ==0 && TrwaZamykanie==0 && TrwaOtwieranie==0))
              {
                Serial.write("4");
                delay(400);
                
                 }
  }
  
 //ZAMYKANIE  ***********************************************************************************************************************
   
    if (czyZamkniete==0  && czyDoszlo==0 && TrwaOtwieranie==0 && TrwaZamykanie==1 && czyOtwarte==1){              //warunki wylaczenia silnika gdy poprzednim zdarzeniem bylo zamykanie
      stopsilnik();
      TrwaZamykanie=0;
      IRcode=0x0;
      delay(100);
      
      
    }
    else if (czyDoszlo == 0 && czyZamkniete==1 && TrwaOtwieranie==0 && TrwaZamykanie==0 && czyOtwarte==0){        //warunki zamykania
    
    zamykanie();
    TrwaZamykanie=1;
    IRcode=0x0;
    delay(100);
    
   }
   else if(czyDoszlo==1 && TrwaZamykanie==1){           //natychmiastowe otwarcie drzwi gdy podczas trwania zamykania drzwi doszlo do otwarcia drzwi
    otwieranie();
    TrwaZamykanie=0;
    TrwaOtwieranie=1;
    delay(100);
   }

   
    
 //OTWIERANIE  ***********************************************************************************************************************
  
    
       if (czyOtwarte==0 && czyZamkniete == 1 && czyDoszlo==1 && TrwaOtwieranie==1 && TrwaZamykanie==0 )          //warunki wylaczenia silnika gdy poprzednim zdarzeniem bylo otwieranie
          { 
          stopsilnik();
          TrwaOtwieranie=0;
          access=false;
          delay(100);
          IRcode=0;
          
          
          }
   else if( (czyOtwarte==1 && czyZamkniete ==0 && TrwaZamykanie==0 && TrwaOtwieranie==0) && (access==true || IRcode==16 || odleglosc<10) )        //warunki otwierania
    {
          if (odleglosc<10)
             {    
              Serial.write("5");          //wyslanie zdarzenia "otwarcia przez otwieranie" do programu z interfejsem zdarzeń.
              }
    
           if (IRcode==16 )
              {  
              Serial.write("0");          //wyslanie zdarzenia "otwarcia przez sygnal IR" do programu z interfejsem zdarzeń.
              delay(200);
              }
             
      otwieranie();
      access=false;
      TrwaOtwieranie=1;
      delay(100);
      IRcode=0;
    }
   
  
  delay(100);

// AKTYWACJA I DEZAKTYWACJA UŻYTKOWNIKÓW  ***********************************************************************************************************************

  if(stringComplete) //jesli odczyta znak \n wysyłany z aplikacji
{ 
  stringComplete = false; 
  getCommand();       //pobiera komende przesylana z aplikacji
  
///////////////////////////////// KARTA 1  ***********************************************************************************************************************   
  if(commandString.equals("act1"))
  {
    karta[0]="3989a299";
  } 
  if(commandString.equals("dis1"))
  {
    karta[0]="00000000";
  }
 ///////////////////////////////// KARTA 2   ***********************************************************************************************************************
  if(commandString.equals("act2"))
  {
    karta[1]="fb779a1b";
  }
  if(commandString.equals("dis2"))
  {
    karta[1]="00000000";
  }
///////////////////////////////// KARTA 3  ***********************************************************************************************************************
  if(commandString.equals("act3"))
  {
    karta[2]="ba1be68b";
  }
  if(commandString.equals("dis3"))
  {
    karta[2]="00000000";
  }

///////////////////////////////// OTWIRANIE Z POZIOMU APLIKACJI *************************************************************************************************************
  if(commandString.equals("open")&&(czyOtwarte==1 && czyZamkniete ==0 && TrwaZamykanie==0 && TrwaOtwieranie==0))
  {
    otwieranie();
    TrwaOtwieranie=1;
      delay(100);
  }
  }
  
  inputString="";
}
  // MIERZENIE ODLEGLOSCI ***********************************************************************************************************************
  
int zmierzOdleglosc() {
  
  long czas, dystans;
 
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
 
  czas = pulseIn(echoPin, HIGH);    // zmierzona odległość reprezentowana jest przez impuls (stan wysoki) na pinie echo. Jego długość jest proporcjonalna do odległości
  dystans = czas / 58;              //liczba 58 wynika z czasu przez jaki dźwięk pokonuje odległość 1 cm oraz wzoru na odległość jaką przedstawił producent.
 
  return dystans;
}
// FUNKCJE OTWIERANIA,ZAMYKANIA,STOPU ***********************************************************************************************************************

  void otwieranie(){
    digitalWrite(MotorR, HIGH); 
    digitalWrite(MotorL, LOW);
  }
  void zamykanie(){
    digitalWrite(MotorR, LOW); 
    digitalWrite(MotorL, HIGH);
  }
  void stopsilnik(){
    digitalWrite(MotorR, LOW); 
    digitalWrite(MotorL, LOW);
    
  }

//KOMUNIKACJA Z INTERFEJSEM - PORT SZEREGOWY ***********************************************************************************************************************

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,5); //odczytuj polecenie od znaku o indeksie 1 do znaku o indeksie 5
  }
}

void serialEvent() 
{
  while (Serial.available())
  {
    char inChar = (char)Serial.read();  // Pobieranie nowego bajtu danych
    inputString += inChar;          // dodawanie do istniejacej zmiennej string
    
    if (inChar == '\n') 
    {           
      stringComplete = true;// Jesli nastepnym znakiem jest znak nastepnej lini, zakoncz pobieranie danych
    }
    
  }
}



 
