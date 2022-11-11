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
-- Table structure for table `worker`
--

DROP TABLE IF EXISTS `worker`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `worker` (
  `worker_id` int(3) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `password` varchar(35) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `user_type` int(10) unsigned NOT NULL,
  `surname` varchar(35) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(35) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `last_name` varchar(35) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `hiring_date` date NOT NULL,
  `phone_number` varchar(17) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(35) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`worker_id`),
  KEY `user_type_idx` (`user_type`),
  CONSTRAINT `user_type_work` FOREIGN KEY (`user_type`) REFERENCES `users_type` (`type_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `worker`
--

LOCK TABLES `worker` WRITE;
/*!40000 ALTER TABLE `worker` DISABLE KEYS */;
INSERT INTO `worker` VALUES (001,'1',1,'Терентьев','Дмитрий','Константинович','2021-05-01','+7 (921) 457-7543','terentev@ma.il'),(002,'2',1,'Маленков','Даниил','Матвеевич','2021-05-31','+7 (956) 847-8995','malenkov@ma.il'),(003,'3',1,'Петрова','Анна','Михайловна','2021-05-31','+7 (974) 548-4545','petrova@ma.il'),(004,'4',1,'Чертов','Александр','Григорьевич','2021-05-31','+7 (955) 656-7641','chertov@ma.il'),(005,'5',1,'Яванский','Михаил','Сергеевич','2021-05-31','+7 (978) 454-5646','yavanskiy@ma.il'),(006,'6',2,'Мышкина','Эвелина','Леонидовна','2021-06-02','+7 (954) 785-4155','myshkina@ma.il'),(007,'7',2,'Тимуров','Тимур','Мамбетович','2021-06-02','+7 (985) 478-4512','timurov@ma.il'),(008,'8',2,'Иванов','Никита','Олегович','2021-06-02','+7 (978) 541-5477','ivanov@ma.il'),(009,'9',2,'Воронов','Игорь','Иванович','2021-06-03','+7 (985) 478-5411','voronov@ma.il'),(010,'10',2,'Соткин','Павел','Аркадьевич','2021-06-03','+7 (956) 587-4564','sotkin@ma.il'),(011,'11',2,'Синицын','Сергей','Александрович','2021-06-03','+7 (956) 458-7514','sinitsyn@ma.il'),(012,'12',2,'Сергеева','Алёна','','2021-06-05','+7 (985) 415-4878','sergeeva@ma.il'),(013,'13',2,'Актёров','Илья','Сафронович','2021-06-06','+7 (978) 453-4545','aktyorov@ma.il'),(014,'14',2,'Шевелёва','Надежда','Алесьевна','2021-06-07','+7 (954) 655-4656','shevelyova@ma.il'),(015,'15',2,'Смирнов','Алексей','Михайлович','2021-06-08','+7 (987) 456-5456','smirnov@ma.il'),(016,'16',2,'Зайцева','Елизавета','Павловна','2021-06-08','+7 (978) 465-4565','zaytseva@ma.il'),(017,'17',2,'Сорокин','Денис','Игоревич','2021-06-08','+7 (945) 456-4515','sorokin@ma.il'),(018,'18',2,'Вениаминов','Аристарх','Архимедович','2021-06-09','+7 (945) 646-5456','veniaminov@ma.il'),(019,'19',2,'Стаканова','Юлия','Витальевна','2021-06-10','+7 (956) 565-6561','stakanova@ma.il'),(020,'20',2,'Михайленко','Анна','Евгеньевна','2021-06-10','+7 (958) 686-5664','mihaylenko@ma.il'),(021,'21',2,'Белякова','Марина','Анатольевна','2021-06-11','+7 (945) 456-4564','belyakova@ma.il'),(022,'22',2,'Яблочкина','Ангелина','Алексеевна','2021-06-11','+7 (956) 564-6465','yablochkina@ma.il'),(023,'23',2,'Зимний','Моисей','Борисович','2021-06-15','+7 (945) 456-4564','zimniy@ma.il'),(024,'24',2,'Ступина','Надежда','Ивановна','2021-06-15','+7 (956) 456-4564','stupina@ma.il'),(025,'25',1,'Алексеенко','Оксана','Анатольевна','2021-06-15','+7 (986) 556-1466','alekseenko@ma.il'),(026,'26',2,'Окский','Фёдор','Романович','2021-06-16','+7 (931) 851-3315','okskiy@ma.il'),(027,'27',2,'Рыбникова','Дарья','','2021-06-16','+7 (945) 465-4655','rybnikova@ma.il'),(028,'28',2,'Сапрыкин','Никита','Иванович','2021-06-17','+7 (954) 654-5546','saprykin@ma.il'),(029,'29',2,'Манько','Пётр','Алексеевич','2021-06-17','+7 (956) 565-6464','manko@ma.il'),(030,'30',2,'Денисов','Кирилл','Васильевич','2021-06-18','+7 (915) 465-4564','denisov@ma.il'),(031,'31',1,'Халимов','Илья','','2021-06-20','+7 (945) 645-6156','halimov@ma.il');
/*!40000 ALTER TABLE `worker` ENABLE KEYS */;
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
