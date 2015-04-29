-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Machine: 127.0.0.1
-- Gegenereerd op: 29 apr 2015 om 08:41
-- Serverversie: 5.6.17
-- PHP-versie: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Databank: `project`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `antwoorden`
--

CREATE TABLE IF NOT EXISTS `antwoorden` (
  `id` int(11) NOT NULL,
  `vraag_1` varchar(200) NOT NULL,
  `vraag_2` varchar(200) NOT NULL,
  `vraag_3` varchar(200) NOT NULL,
  `vraag_4` varchar(200) NOT NULL,
  `vraag_5` varchar(200) NOT NULL,
  `vraag_6` varchar(200) NOT NULL,
  `vraag_7` varchar(200) NOT NULL,
  `vraag_8` varchar(200) NOT NULL,
  `vraag_9` varchar(200) NOT NULL,
  `vraag_10` varchar(200) NOT NULL,
  `vraag_11` varchar(200) NOT NULL,
  `vraag_12` varchar(200) NOT NULL,
  `vraag_13` varchar(200) NOT NULL,
  `vraag_14` varchar(200) NOT NULL,
  `vraag_15` varchar(200) NOT NULL,
  `vraag_16` varchar(200) NOT NULL,
  `vraag_17` varchar(200) NOT NULL,
  `vraag_18` varchar(200) NOT NULL,
  `vraag_19` varchar(200) NOT NULL,
  `vraag_20` varchar(200) NOT NULL,
  `vraag_21` varchar(200) NOT NULL,
  `vraag_22` varchar(200) NOT NULL,
  `vraag_23` varchar(200) NOT NULL,
  `vraag_24` varchar(200) NOT NULL,
  `vraag_25` varchar(200) NOT NULL,
  `vraag_26` varchar(200) NOT NULL,
  `vraag_27` varchar(200) NOT NULL,
  `vraag_28` varchar(200) NOT NULL,
  `vraag_29` varchar(200) NOT NULL,
  `vraag_30` varchar(200) NOT NULL,
  `vraag_31` varchar(200) NOT NULL,
  `vraag_32` varchar(200) NOT NULL,
  `vraag_33` varchar(200) NOT NULL,
  `vraag_34` varchar(200) NOT NULL,
  `vraag_35` varchar(200) NOT NULL,
  `vraag_36` varchar(200) NOT NULL,
  `vraag_37` varchar(200) NOT NULL,
  `vraag_38` varchar(200) NOT NULL,
  `vraag_39` varchar(200) NOT NULL,
  `vraag_40` varchar(200) NOT NULL,
  `vraag_41` varchar(200) NOT NULL,
  `vraag_42` varchar(200) NOT NULL,
  `vraag_43` varchar(200) NOT NULL,
  `vraag_44` varchar(200) NOT NULL,
  `vraag_45` varchar(200) NOT NULL,
  `vraag_46` varchar(200) NOT NULL,
  `vraag_47` varchar(200) NOT NULL,
  `vraag_48` varchar(200) NOT NULL,
  `vraag_49` varchar(200) NOT NULL,
  `vraag_50` varchar(200) NOT NULL,
  `vraag_51` varchar(200) NOT NULL,
  `vraag_52` varchar(200) NOT NULL,
  `vraag_53` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `vragenlijst`
--

CREATE TABLE IF NOT EXISTS `vragenlijst` (
  `vraag_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'auto_increment',
  `vraag_thema` varchar(200) NOT NULL,
  `vraag` varchar(200) NOT NULL,
  PRIMARY KEY (`vraag_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=54 ;

--
-- Gegevens worden geëxporteerd voor tabel `vragenlijst`
--

INSERT INTO `vragenlijst` (`vraag_id`, `vraag_thema`, `vraag`) VALUES
(1, 'A) Hoofdthema: Leren en toepassen van kennis', 'Iets nieuws leren (zoals het leren omgaan met bijv. een nieuwe GSM, vaatwasmachine of afstandsbediening; leren ikv een hobby)'),
(2, 'A) Hoofdthema: Leren en toepassen van kennis', 'Zich kunnen concentreren zonder te worden afgeleid (zoals het volgen van een gesprek in een drukke omgeving, of het volgen van een Tv-programma)'),
(3, 'A) Hoofdthema: Leren en toepassen van kennis', 'Denken (zoals fantaseren, een mening vormen, met ideeën spelen, of nadenken)'),
(4, 'A) Hoofdthema: Leren en toepassen van kennis', 'Lezen (zoals boeken, instructies, kranten, in tekst of in braille)'),
(5, 'A) Hoofdthema: Leren en toepassen van kennis', 'Rekenen (zoals gepast betalen bij een winkel)'),
(6, 'A) Hoofdthema: Leren en toepassen van kennis', 'Oplossen van problemen (zoals een afspraak bij de dokter verzetten, of weten wat je moet doen als er iets stuk gaat in huis)'),
(7, 'A) Hoofdthema: Leren en toepassen van kennis', 'Keuzes maken (zoals kiezen wat je wil eten, welk TV-programma je wil zien)'),
(8, 'B) Hoofdthema: Algemene taken en activiteiten', 'Uitvoeren van dagelijkse routinehandelingen (zoals zich wassen, ontbijten)'),
(9, 'B) Hoofdthema: Algemene taken en activiteiten', 'Ondernemen van een eenvoudige taak op eigen initiatief (zoals een boodschappenlijstje opmaken, de vuilzak buitenzetten, de tafel dekken)'),
(10, 'B) Hoofdthema: Algemene taken en activiteiten', 'Ondernemen van complexe taken op eigen initiatief (zoals autorijden, boodschappen doen, uitgebreid koken)'),
(11, 'B) Hoofdthema: Algemene taken en activiteiten', 'Omgaan met stressvolle situaties(zoals het autorijden in druk verkeer of het verzorgen van meerdere kinderen)'),
(12, 'C) Hoofdthema: Communicatie', 'Begrijpen wat iemand vertelt of vraagt'),
(13, 'C) Hoofdthema: Communicatie', 'Begrijpen van non-verbale (niet gesproken) boodschappen (zoals pictogrammen, afbeeldingen, symbolen, lichaamstaal en gezichtsuitdrukkingen)'),
(14, 'C) Hoofdthema: Communicatie', 'Begrijpen van geschreven boodschappen (zoals het lezen van de krant)'),
(15, 'C) Hoofdthema: Communicatie', 'Spreken'),
(16, 'C) Hoofdthema: Communicatie', 'Zich uiten dmv lichaamstaal, handgebaren en gezichtsuitdrukkingen)'),
(17, 'C) Hoofdthema: Communicatie', 'Schrijven van berichten (bijv. een boodschappenlijstje maken, een e-mail schrijven)'),
(18, 'C) Hoofdthema: Communicatie', 'Het voeren van een gesprek'),
(19, 'C) Hoofdthema: Communicatie', 'Gebruiken van communicatieapparatuur en -technieken (zoals gebruik van telefoon, GSM, computer, hoorapparaat, etc)'),
(20, 'D) Hoofdthema: Mobiliteit', 'Zich kunnen bewegen en verplaatsen, met of zonder gebruik van hulpmiddelen zoals rolstoel, wandelstok of rollator (bijv. uit bed komen, wandelen, opstaan uit stoel)'),
(21, 'D) Hoofdthema: Mobiliteit', 'Gebruiken van hand en arm (grote bewegingen, zoals voorwerpen optillen en meenemen)'),
(22, 'D) Hoofdthema: Mobiliteit', 'Nauwkeurig gebruiken van handen (kleine bewegingen zoals grijpen en loslaten, schrijven, gebruik van sleutels of GSM, iets snijden met een mes)'),
(23, 'D) Hoofdthema: Mobiliteit', 'Gebruiken van openbaar vervoer (zoals de bus of de trein nemen)'),
(24, 'D) Hoofdthema: Mobiliteit', 'Besturen van vervoermiddel (zoals de auto of de fiets)'),
(25, 'E) Hoofdthema: Zelfverzorging', 'Zich wassen'),
(26, 'E) Hoofdthema: Zelfverzorging', 'Verzorgen van lichaamsdelen (bijv. tanden poetsen, nagels knippen, make-up gebruiken)'),
(27, 'E) Hoofdthema: Zelfverzorging', 'Zelfstandig naar het toilet kunnen gaan'),
(28, 'E) Hoofdthema: Zelfverzorging', 'Zich aankleden'),
(29, 'E) Hoofdthema: Zelfverzorging', 'Eten'),
(30, 'E) Hoofdthema: Zelfverzorging', 'Drinken'),
(31, 'E) Hoofdthema: Zelfverzorging', 'Letten op de gezondheid (gevarieerd eten, voldoende lichaamsbeweging, gezondheidsrisico’s vermijden)'),
(32, 'F) Hoofdthema: Huishouden', 'Gaan winkelen'),
(33, 'F) Hoofdthema: Huishouden', 'Bereiden van maaltijden'),
(34, 'F) Hoofdthema: Huishouden', 'Huishouden doen (onderhoud van huis en tuin, schoonmaken, kleren wassen)'),
(35, 'G) Hoofdthema: Omgaan met andere mensen', 'Op sociaal gepaste wijze contact maken met bekende en onbekende mensen (respectvol, rekening houden met de situatie, etc.)'),
(36, 'G) Hoofdthema: Omgaan met andere mensen', 'Intieme relaties en seksualiteit'),
(37, 'G) Hoofdthema: Omgaan met andere mensen', 'Omgaan met familieleden'),
(38, 'G) Hoofdthema: Omgaan met andere mensen', 'Omgaan met vrienden en kennissen'),
(39, 'G) Hoofdthema: Omgaan met andere mensen', 'Formele relaties (zoals omgang met collega’s, werkgever, dokters en verzorgenden)'),
(40, 'H) Hoofdthema: Belangrijke levensgebieden (opleiding, werk of financiële zaken)', 'Het volgen van een vorming, training en/of opleiding'),
(41, 'H) Hoofdthema: Belangrijke levensgebieden (opleiding, werk of financiële zaken)', 'Werken of andere zinvolle dagbesteding (zoals vrijwilligerswerk, het huishouden)'),
(42, 'H) Hoofdthema: Belangrijke levensgebieden (opleiding, werk of financiële zaken)', 'Financiële mogelijkheden voor jezelf en je gezin'),
(43, 'I) Hoofdthema: Maatschappelijk, sociaal en burgerlijk leven', 'Deelnemen aan het maatschappelijk leven (zoals gaan stemmen, een huwelijk of begrafenis bijwonen, lid zijn van een vereniging'),
(44, 'I) Hoofdthema: Maatschappelijk, sociaal en burgerlijk leven', 'Deelnemen aan het maatschappelijk leven (zoals gaan stemmen, een huwelijk of begrafenis bijwonen, lid zijn van een vereniging'),
(45, 'I) Hoofdthema: Maatschappelijk, sociaal en burgerlijk leven', 'Deelnemen aan het maatschappelijk leven (zoals gaan stemmen, een huwelijk of begrafenis bijwonen, lid zijn van een vereniging'),
(46, 'J) Hoofdthema: Emoties en gedrag', 'Somber, neerslachtig, depressief'),
(47, 'J) Hoofdthema: Emoties en gedrag', 'Angstgevoelens'),
(48, 'J) Hoofdthema: Emoties en gedrag', 'Onrealistische verwachtingen'),
(49, 'J) Hoofdthema: Emoties en gedrag', 'Sneller emotioneel (bijv. huilen)'),
(50, 'J) Hoofdthema: Emoties en gedrag', 'Sneller geïrriteerd en prikkelbaar'),
(51, 'J) Hoofdthema: Emoties en gedrag', 'Onverschilligheid'),
(52, 'J) Hoofdthema: Emoties en gedrag', 'Ontremming en problemen met controle van gedag (zoals het maken van ongepaste opmerkingen, overmatig eten,…)'),
(53, 'J) Hoofdthema: Emoties en gedrag', 'Sneller en vaker moe');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
