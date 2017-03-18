# SnappetChallenge
At [Snappet](http://www.snappet.org), we care about data and we care about code. When we interview for development positions, we want to see code and we want to discuss code. That's why we want candidates to show some work on our challenge. This challenge is not meant to cost you tons of time. A few hours should be enough. The challenge is defined very broadly. You could spend weeks on it, or half an hour. We understand that in 2 hours, you can only do so much. Don't worry about completeness, work on something that works and shows your skills.

### Language
From the next paragraph on, this challenge is worded in Dutch. Snappet is a Dutch organisation. We are present in several European countries and part of our development team is based in Russia, but still, most of the organisation is Dutch. We all speak English, standups, code and documentation are in English, but being able to operate in a Dutch environment is a required skill. So use whatever tools you can to make sense of the rest of the challenge if you are not a Dutch speaker. It is part of the exercise. :)

### De opdracht
In deze repository vind je een folder Data met daarin work.csv en work.json. Beiden bevatten dezelfde data, je hoeft er maar ��n te gebruiken (wat jij handig vindt). In dit bestand zitten de werkresultaten van de kinderen in ��n klas over een maand. 

Maak een rapport of scherm of wat ook dat een leerkracht een overzicht geeft van hoe zijn klas vandaag heeft gewerkt en waaraan. Het is nu dinsdag 2015-03-24 11:30:00 UTC. De antwoorden van na dat tijdstip worden dus nog niet getoond.

Maak een pull request aan waarin je in ieder geval een readme hebt opgenomen die uitlegt wat je moet doen om het resultaat te kunnen bekijken.

### Achtergrond informatie
- Alle tijden zijn in UTC
- Er is een attribuut Progress. Dit geeft de verandering in de inschatting van de vaardigheid van de leerling op een leerdoel. Daar zitten psychometrische modellen achter die rekening houden met de moeilijkheid van de opgave, of de opgave al eerder door deze leerling is gemaakt, etc. Er zijn meerdere situaties waarbij de Progress 0 is. Bijvoorbeeld als we nog geen goede calibratie van de moeilijkheid van de opgave hebben. Of als de leerling nog te weinig opgaven in een leerdoel heeft gemaakt om een goede schatting van de vaardigheid te maken.
- Aangezien deze dataset alleen wijzigingen laat zien en geen absolute waarde, kan je aan deze dataset niet zien wat de vaardigheid van iedere leerling is. Dat hoeft ook niet in de resultaten terug te komen.

### Vrijheid
Deze opdracht is expres ruim geformuleerd. Je mag de technieken en tools gebruiken die je het liefst gebruikt. Je mag je tijd besteden aan de aspecten die je zelf het belangrijkst vindt. Er is geen tijd om alles te doen: maak een keuze. Bij Snappet werken we met C#, .NET, Javascript, JQuery en Knockout.JS. Maar we denken dat een goede programmeur op een ander platform zich dat snel genoeg eigen maakt. 
Je mag frameworks en libraries gebruiken. Je mag de data in een ander formaat omzetten of importeren in databases. Dan wel in de readme uitleggen hoe een ander het werkend kan krijgen.
De minimale requirement in de opdracht is "waar heeft mijn klas vandaag aan gewerkt". Dat kan in een lijstje, in een grafisch vorm, het kan als getallen of kleuren. Je kan het vergelijken met vorige week of een gemiddelde score. Probeer te bedenken wat voor een leerkracht in de klas het belangrijkst is.

Solution
===

Thank you for choosing me for this challenge. I'm happy to present this solution for your attention.

Solution Overview
---

Front end part is implemented as a javascript application that is implemented with knockoutjs, jquery and skeleton.css.
Back end part is implemented with ASP.NET WebApi2 and Autofac.

The goal for the solution is to process original submitted answers jsonn file into memory in a form prepared for generating reports.
I've applied SOLID principles on the back end part and have structured classes so it should be easy to follow.
Frontend part is implemented using modular approach. You can see a single module *snappet* that contains all definitions specific for the application.

How to run
---

In order to run the solution please open it with Microsoft Visual Studio 2015 or another IDE that can build and run solutions for technologies described above.
Set *Snappet.Borisov.Test.WebApp* as a StartUp Project and run the solution.
When Visual Studio finishes compilation process it should automatically open a web browser and show a page with an overview of submitted answers for today (2015-03-24 11:30 UTC).
If that didn't happened you could try to open the url http://localhost:18502/ in a web browser manually.
I hope I've done everything well and you will be able to run the solution without any hussle.

Enjoy!