-- MySQL dump 10.13  Distrib 5.5.53, for Win64 (AMD64)
--
-- Host: localhost    Database: mps
-- ------------------------------------------------------
-- Server version	5.5.53-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `phrase`
--

DROP TABLE IF EXISTS `phrase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `phrase` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `text` varchar(150) DEFAULT NULL,
  `difficulty` int(11) DEFAULT NULL,
  `type` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phrase`
--

LOCK TABLES `phrase` WRITE;
/*!40000 ALTER TABLE `phrase` DISABLE KEYS */;
INSERT INTO `phrase` VALUES (1,'caine',0,0),(2,'pisica',0,0),(3,'veverita',0,0),(4,'iepure',0,0),(5,'vulpe',0,0),(6,'casa',0,0),(7,'pahar',0,0),(8,'verde',0,0),(9,'negru',0,0),(10,'albastru',0,0),(11,'enciclopedie',1,0),(12,'bombardament',1,0),(13,'mitropolie',1,0),(14,'episcopie',1,0),(15,'criminalistica',1,0),(16,'televiziune',1,0),(17,'cronologie',1,0),(18,'mobilier',1,0),(19,'tinichea',1,0),(20,'mineralizare',1,0),(21,'irefutabil',2,0),(22,'ireprosabil',2,0),(23,'distrofieendemicatireopata',2,0),(24,'feromicroazotombohidric',2,0),(25,'electroglotospectrografie',2,0),(26,'encefalomielopoliradiculonevrita',2,0),(27,'diclordifeniltriclormetilmetan',2,0),(28,'autopropulsare',2,0),(29,'protocromozom',2,0),(30,'imunopolizaharide',2,0),(31,'Ana are mere',0,1),(32,'Ce faci?',0,1),(33,'Eu vreau acasa.',0,1),(34,'Ei se cunosc.',0,1),(35,'Nu am treaba.',0,1),(36,'Revin imediat!',0,1),(37,'Ne cunoastem?',0,1),(38,'Vin la tine.',0,1),(39,'Covorul este rosu',0,1),(40,'Este o zi frumoasa',0,1),(41,'Ce zici, mergem la o piesa de teatru?',1,1),(42,'De aici de pe balcon se poate vedea padurea.',1,1),(43,'Crezi ca putem sa intram neinvitati?',1,1),(44,'Nu vorbi asa de tare, ca se trezeste!',1,1),(45,'Afara este frig si ninge!',1,1),(46,'Nu stiu ce sa fac dupa ce ajung acasa.',1,1),(47,'Nu vreau sa merg singur la petrecere.',1,1),(48,'Vrei sa vii sa cautam un restaurant?',1,1),(49,'Oare unde duce acest drum?',1,1),(50,'Crezi ca putem sa ne plimbam pe langa lac?',1,1),(51,'Vai! a spus Degetica. Afara e frig si ninge! Mai bine stai aici, in patutul tau cald, si eu am sa te ingrijesc.',2,1),(52,'Doamne, cat e de frumos! spuse Degetica randunicii in soapta.',2,1),(53,'Ramai cu bine, ramai cu bine! a spus randunica si a plecat in zbor iarasi inapoi',2,1),(54,'Nu vom mai pleca nicaieri fara tine. Data viitoare te vom invita!',2,1),(55,'Crezi ca este in regula sa plecam acum? Nu ii mai asteptam?',2,1),(56,'De ce crezi ca e suparata? nu ai facut nimic.',2,1),(57,'Nu am mai fost niciodata la tine acasa. Este asa frumos!',2,1),(58,'Desi locuiesti departe de mine, voi incerca sa te vizitez mai des.',2,1),(59,'Oare unde duce acel rau? Mi-as dori sa ajung la capatul lui.',2,1),(60,'Hai sa mergem sa vedem targul de craciun! Arata asa bine in poze!',2,1);
/*!40000 ALTER TABLE `phrase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `score` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Atanasiu Alexandru','alabala',0),(2,'Sirbu Lavinia','lalala',0),(3,'Murgan Ioana','portocale',0),(4,'Zavate Razvan','ciocolata',0),(5,'Gogoanta Mihaela','pramatie',0),(6,'Andrei Stanca','lalalala',0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-05 21:18:48
