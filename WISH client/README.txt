
================= K�nda buggar ===========================
- Ifall roboten st�ngs av via str�mbrytaren uppfattar inte programmet detta. 
   Finns det n�gon enkel fix f�r detta?   
  
- Xboxhandkontroll m�ste vara ansluten f�r att kunna starta kontakten med roboten. 
 (Enkel fix, beh�ver endast �ndras i vad som g�rs d� man trycker p� start)
   
- Ifall man kryssar programmet intr�ffar samma fel som punkt 3. 
   
================== Att g�ra ===============================

- Xboxhandkontrolls check ska endast ske n�r knappen Manuellt l�ge klickas p�. 
  S� att man kan starta programmet och v�lja autonomt, bevaka sensorv�rden utan krav p�
  inkopplad Xboxkontroll. 
  
- Axlarna i sensorv�rdena b�r vara anpassade till en specifik data. Som det �r nu finns endast
  2 olika sorters ChartAreas, en f�r signed och en f�r unsigned data. 
  
- Graferna visar endast senaste v�rdet av en data, har det kommit flera v�rden fr�n samma sensor under
  ett tick visas endast det ena. Detta skapar problem f�r att anv�nda graferna till fels�kning av 
  avvikande sensorv�rden. 
  
- Textbox f�r output av styrbeslut, kod implementerad men bortkommenterad i tickupdate. 
  Denna m�ste testas n�r styrmodulen implementerat s�ndning av styrbeslut. 
  Typ ok�nd idag och dummyv�rde inlagt i koden. 
  
- Implementation d�r de analoga knapparna p� baksidan av kontrollen implementeras. 
  De ska ge olika h�jdl�gen beroende p� hur l�ngt de �r intryckta. (Endast en av de). 
  Range till robot: 0-50, typ: ok�nd. 
  
- InitializeGUI() b�r �terst�lla GUI till grundl�get precis d� man startat programmet. 
  Detta g�r att man enkelt kan �terst�lla GUI vid olika exceptions utan att programmet kraschar. 
  



=================== �tg�rdade implementationer, testade och fullt fungerande ==========================

- Kunna v�lja om roboten ska vara i Autonomt eller Manuellt l�ge. �r den i autonomt l�ge ska den kunna 
  �ndras till manuellt l�ge och tv�rtom. 
  Xbox-kontroll b�r v�ljas omm Manuellt l�ge �r valt. 
  
=================== �tg�rdade buggar och dess l�sningar ===============================================
