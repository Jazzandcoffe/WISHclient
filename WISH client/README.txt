
================= Kända buggar ===========================

1. Variabeln _lastData används av både tickuppdateringen av GUI och eventet som höjs av Bluetooth.
   Konflikt kan då inträffa om de försöker nå samma minne samtidigt. (Trådkonflikt)
   
   Ej testad lösning: Lagt till random objektet locker, Bluetooth-eventet låser locker. 
   Även tickuppdateringen av GUI låser locker. Detta ska göra att om någon tråd ska
   göra något kontrollerar de ifall locker är låst eller upplåst innan de går vidare.
   Är det låst ska den vänta tills det blir upplåst.    
   
   -----------------------
  
2. Xboxhandkontroll måste vara ansluten för att kunna starta kontakten med roboten. 
   (Enkel fix, behöver endast ändras i vad som görs då man trycker på start)
   
3. Då stop-knappen används under körning kan exception kastas av bt_transfer i bluetooth.cs 
   Antagligen försöker den stänga porten samtidigt som en överföring via bluetooth sker. 
   
4. Ifall man kryssar programmet inträffar samma fel som punkt 3. 
   
================== Att göra ===============================
- Tangentbordsstyrningen måste anpassas enligt bussprotokoll.xslx på dropbox. Olika hastigheter införda
  som tangentbordsstyrningen måste ta hänsyn till. 

- Full implementation av tangentbordsstyrning med tick. (Gamla lösningen finns bortkommenterad)

- Val av användaren att använda tangentbordsstyrning eller xbox-kontroll i GUI. Ska kunna väljas efter att
  kontakten till Bluetooth är öppnad. (Användaren ska inte kunna göra valet innan). 
  
- Kunna välja om roboten ska vara i Autonomt eller Manuellt läge. Är den i autonomt läge ska den kunna 
  ändras till manuellt läge och tvärtom. 
  Xbox-kontroll och tangentbordsinmatning bör väljas omm Manuellt läge är valt. 
  
  
=================== Pågående arbete under projektets gång ================
- Förbättra designen i GUI. Nuvarande design är för att få ut det man vill just nu av programmet. 
Ingen hänsyn är tagen till hur det ser ut. 

- Lägga in saker i GUI som man vill ha. 


