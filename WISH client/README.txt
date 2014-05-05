
================= Kända buggar ===========================

------ Inga som är kända just nu ------

   
================== Att göra ===============================
  
- Textbox för output av styrbeslut, kod implementerad men bortkommenterad i tickupdate. 
  Denna måste testas när styrmodulen implementerat sändning av styrbeslut. 
  Typ okänd idag och dummyvärde inlagt i koden. 

=================== Ej åtgärdade buggar pga tidsbrist =================================================

- Ifall roboten stängs av via strömbrytaren uppfattar inte programmet detta. 
   Finns det någon enkel fix för detta?  
  Svar: Finns ingen standard implementation för detta via seriell USB överföring. 
        En lösning är att läsa av om man får data från Bluetoothen. 
        Lämnas olöst tillsvidare, ordnas i mån av tid.  
		
=================== Implementationer i mån av tid =====================================================

- Graferna visar endast senaste värdet av en data, har det kommit flera värden från samma sensor under
  ett tick visas endast det ena. Detta skapar problem för att använda graferna till felsökning av 
  avvikande sensorvärden. 
  
- Implementation där de analoga knapparna på baksidan av kontrollen implementeras. 
  De ska ge olika höjdlägen beroende på hur långt de är intryckta. (Endast en av de). 
  Range till robot: 0-50, typ: okänd. 
  
=================== Åtgärdade implementationer, testade och fullt fungerande ==========================

- Kunna välja om roboten ska vara i Autonomt eller Manuellt läge. Är den i autonomt läge ska den kunna 
  ändras till manuellt läge och tvärtom. 
  Xbox-kontroll bör väljas omm Manuellt läge är valt. 

- Xboxhandkontrolls check ska endast ske när knappen Manuellt läge klickas på. 
  Så att man kan starta programmet och välja autonomt, bevaka sensorvärden utan krav på
  inkopplad Xboxkontroll. 

- Initialize() bör återställa GUI till grundläget precis då man startat programmet. 
  Detta gör att man enkelt kan återställa GUI vid olika exceptions utan att programmet kraschar.

- Axlarna i sensorvärdena bör vara anpassade till en specifik data. Som det är nu finns endast
  2 olika sorters ChartAreas, en för signed och en för unsigned data. 
  Lösning: Finns nu tre olika sorters ChartAreas. Även bytt bakgrund till vitt.   
  
=================== Åtgärdade buggar och dess lösningar ===============================================

- Ifall man kryssar programmet inträffar samma fel som punkt 3. 

- Xboxhandkontroll måste vara ansluten för att kunna starta kontakten med roboten. 
 (Enkel fix, behöver endast ändras i vad som görs då man trycker på start)