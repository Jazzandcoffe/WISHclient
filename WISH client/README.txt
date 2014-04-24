
================= K�nda buggar ===========================

1. Variabeln _lastData anv�nds av b�de tickuppdateringen av GUI och eventet som h�js av Bluetooth.
   Konflikt kan d� intr�ffa om de f�rs�ker n� samma minne samtidigt. (Tr�dkonflikt)
   
   Ej testad l�sning: Lagt till random objektet locker, Bluetooth-eventet l�ser locker. 
   �ven tickuppdateringen av GUI l�ser locker. Detta ska g�ra att om n�gon tr�d ska
   g�ra n�got kontrollerar de ifall locker �r l�st eller uppl�st innan de g�r vidare.
   �r det l�st ska den v�nta tills det blir uppl�st.    
   
   -----------------------
  
2. Xboxhandkontroll m�ste vara ansluten f�r att kunna starta kontakten med roboten. 
   (Enkel fix, beh�ver endast �ndras i vad som g�rs d� man trycker p� start)
   
3. D� stop-knappen anv�nds under k�rning kan exception kastas av bt_transfer i bluetooth.cs 
   Antagligen f�rs�ker den st�nga porten samtidigt som en �verf�ring via bluetooth sker. 
   
4. Ifall man kryssar programmet intr�ffar samma fel som punkt 3. 
   
================== Att g�ra ===============================
- Tangentbordsstyrningen m�ste anpassas enligt bussprotokoll.xslx p� dropbox. Olika hastigheter inf�rda
  som tangentbordsstyrningen m�ste ta h�nsyn till. 

- Full implementation av tangentbordsstyrning med tick. (Gamla l�sningen finns bortkommenterad)

- Val av anv�ndaren att anv�nda tangentbordsstyrning eller xbox-kontroll i GUI. Ska kunna v�ljas efter att
  kontakten till Bluetooth �r �ppnad. (Anv�ndaren ska inte kunna g�ra valet innan). 
  
- Kunna v�lja om roboten ska vara i Autonomt eller Manuellt l�ge. �r den i autonomt l�ge ska den kunna 
  �ndras till manuellt l�ge och tv�rtom. 
  Xbox-kontroll och tangentbordsinmatning b�r v�ljas omm Manuellt l�ge �r valt. 
  
  
=================== P�g�ende arbete under projektets g�ng ================
- F�rb�ttra designen i GUI. Nuvarande design �r f�r att f� ut det man vill just nu av programmet. 
Ingen h�nsyn �r tagen till hur det ser ut. 

- L�gga in saker i GUI som man vill ha. 


