-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: entrant
-- ------------------------------------------------------
-- Server version	8.0.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `speciality`
--

DROP TABLE IF EXISTS `speciality`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `speciality` (
  `speciality_code` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `speciality_name` varchar(70) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `number_of_places` int(10) unsigned DEFAULT NULL,
  `passing_score` int(10) unsigned DEFAULT NULL,
  `exam_1` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `exam_2` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `exam_3` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `cost` int(11) DEFAULT NULL,
  PRIMARY KEY (`speciality_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `speciality`
--

LOCK TABLES `speciality` WRITE;
/*!40000 ALTER TABLE `speciality` DISABLE KEYS */;
INSERT INTO `speciality` VALUES ('-',NULL,NULL,NULL,NULL,NULL,NULL,NULL),('01.03.02','Прикладная математика и информатика',6,240,'Русский язык','Математика','Информатика и ИКТ',190000),('01.03.04','Прикладная математика',7,255,'Русский язык','Математика','Информатика и ИКТ',200000),('03.03.01','Прикладные математика и физика',7,230,'Русский язык','Математика','Физика',185000),('04.03.02','Химия, физика и механика материалов',8,230,'Русский язык','Химия','Физика',177000),('05.03.03','Картография и геоинформатика',6,250,'Русский язык','География','Информатика и ИКТ',165000),('05.03.04','Гидрометеорология',6,230,'Русский язык','География','Биология',155000),('08.03.01','Строительство',8,240,'Русский язык','Математика','Физика',190000),('09.03.01','Информатика и вычислительная техника',9,255,'Русский язык','Математика','Информатика и ИКТ',200000),('09.03.03','Прикладная информатика',9,255,'Русский язык','Математика','Информатика и ИКТ',200000),('18.03.01','Химическая технология',8,240,'Русский язык','Химия','Математика',200000),('37.03.01','Психология',5,230,'Русский язык','Биология','Математика',185000),('38.03.01','Экономика',7,225,'Русский язык','Математика','Обществознание',190000),('40.03.01','Юриспруденция',5,230,'Русский язык','История','Обществознание',150000),('41.03.04','Политология',4,250,'Русский язык','История','Обществознание',180000),('46.03.01','История',4,237,'Русский язык','История','Обществознание',160000),('—',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `speciality` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-11-22 16:46:07
