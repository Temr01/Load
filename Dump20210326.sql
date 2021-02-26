-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: 192.168.40.95    Database: ont
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `character_load`
--

DROP TABLE IF EXISTS `character_load`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `character_load` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `character_load`
--

LOCK TABLES `character_load` WRITE;
/*!40000 ALTER TABLE `character_load` DISABLE KEYS */;
INSERT INTO `character_load` VALUES (1,'нагрузка'),(2,'вакансия');
/*!40000 ALTER TABLE `character_load` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classwork`
--

DROP TABLE IF EXISTS `classwork`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classwork` (
  `id` int NOT NULL AUTO_INCREMENT,
  `age` bigint DEFAULT NULL,
  `specialnost` int DEFAULT NULL,
  `date_save` bigint DEFAULT NULL,
  `kvalification` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `specIDX_idx` (`specialnost`),
  CONSTRAINT `specIDX` FOREIGN KEY (`specialnost`) REFERENCES `specialnost` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classwork`
--

LOCK TABLES `classwork` WRITE;
/*!40000 ALTER TABLE `classwork` DISABLE KEYS */;
INSERT INTO `classwork` VALUES (1,2017,1,2012,'техник-программмист'),(2,2010,1,2001,'техник'),(5,2009,2,2003,'Техник');
/*!40000 ALTER TABLE `classwork` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disciplina`
--

DROP TABLE IF EXISTS `disciplina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disciplina` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `max_hours` bigint DEFAULT NULL,
  `stud_hours` bigint DEFAULT NULL,
  `learn_max_hours` bigint DEFAULT NULL,
  `classwork` int DEFAULT NULL,
  `_index` varchar(45) DEFAULT NULL,
  `count_exam` bigint DEFAULT NULL,
  `count_kurs_work` bigint DEFAULT NULL,
  `count_zachet` bigint DEFAULT NULL,
  `learn_classwork_hours` bigint DEFAULT NULL,
  `learn_lab_hours` bigint DEFAULT NULL,
  `learn_kurs_project_hours` bigint DEFAULT NULL,
  `one_semestr` bigint DEFAULT NULL,
  `two_semestr` bigint DEFAULT NULL,
  `three_semestr` bigint DEFAULT NULL,
  `four_semestr` bigint DEFAULT NULL,
  `five_semestr` bigint DEFAULT NULL,
  `six_semestr` bigint DEFAULT NULL,
  `seven_semestr` bigint DEFAULT NULL,
  `eigth_semestr` bigint DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ClassFRG_idx` (`classwork`),
  CONSTRAINT `ClassFRG` FOREIGN KEY (`classwork`) REFERENCES `classwork` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disciplina`
--

LOCK TABLES `disciplina` WRITE;
/*!40000 ALTER TABLE `disciplina` DISABLE KEYS */;
INSERT INTO `disciplina` VALUES (1,'МДК11.01',500,400,200,2,'123',123,343,234,23,34,54,23,34,23,34,45,34,23,34),(3,'МДК03.01',600,380,123,1,'324',5,13,26,23,8,11,23,25,23,23,23,23,27,11),(8,'Русский язык',123,123,123,2,'123',213,213,213,23,34,45,23,34,24,12,22,56,11,10),(9,'Математика',2345,567,554,1,'123',234,343,234,23,34,54,23,34,23,34,45,34,23,34),(10,'Английский язык',32,32,4,1,'324',213,232,32,42,3,23,24,2,3,32,44,2,23,3);
/*!40000 ALTER TABLE `disciplina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `form_learn`
--

DROP TABLE IF EXISTS `form_learn`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `form_learn` (
  `id` int NOT NULL,
  `form` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `form_learn`
--

LOCK TABLES `form_learn` WRITE;
/*!40000 ALTER TABLE `form_learn` DISABLE KEYS */;
INSERT INTO `form_learn` VALUES (1,'очное'),(2,'заочное'),(3,'очно-заочное');
/*!40000 ALTER TABLE `form_learn` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gruppa`
--

DROP TABLE IF EXISTS `gruppa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gruppa` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `cours` enum('1','2','3','4') DEFAULT NULL,
  `teacher` int DEFAULT NULL,
  `year_learn` int DEFAULT NULL,
  `form_learn` int DEFAULT NULL,
  `learn_plan` date DEFAULT NULL,
  `specialnost` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `teacherPKG_idx` (`teacher`),
  KEY `form_learnPKG_idx` (`form_learn`),
  KEY `spec_idx` (`specialnost`),
  CONSTRAINT `form_learnPKG` FOREIGN KEY (`form_learn`) REFERENCES `form_learn` (`id`),
  CONSTRAINT `spec` FOREIGN KEY (`specialnost`) REFERENCES `specialnost` (`id`),
  CONSTRAINT `teacherPKG` FOREIGN KEY (`teacher`) REFERENCES `teacher` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gruppa`
--

LOCK TABLES `gruppa` WRITE;
/*!40000 ALTER TABLE `gruppa` DISABLE KEYS */;
INSERT INTO `gruppa` VALUES (1,'ИПС-1','3',1,2017,3,'2021-03-25',1),(2,'РИПК-8','2',1,2002,2,'2016-01-01',2);
/*!40000 ALTER TABLE `gruppa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `load_teaches`
--

DROP TABLE IF EXISTS `load_teaches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `load_teaches` (
  `id` int NOT NULL AUTO_INCREMENT,
  `disciplina` int DEFAULT NULL,
  `group` int DEFAULT NULL,
  `type` int DEFAULT NULL,
  `character` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `disp` (`disciplina`) /*!80000 INVISIBLE */,
  KEY `groupIND` (`group`) /*!80000 INVISIBLE */,
  KEY `typeIND` (`type`) /*!80000 INVISIBLE */,
  KEY `characterIND` (`character`),
  CONSTRAINT `characterFRG` FOREIGN KEY (`character`) REFERENCES `character_load` (`id`),
  CONSTRAINT `dispFRG` FOREIGN KEY (`disciplina`) REFERENCES `disciplina` (`id`),
  CONSTRAINT `groupFRG` FOREIGN KEY (`group`) REFERENCES `gruppa` (`id`),
  CONSTRAINT `typeFRG` FOREIGN KEY (`type`) REFERENCES `type_load` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `load_teaches`
--

LOCK TABLES `load_teaches` WRITE;
/*!40000 ALTER TABLE `load_teaches` DISABLE KEYS */;
INSERT INTO `load_teaches` VALUES (1,1,1,2,1);
/*!40000 ALTER TABLE `load_teaches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `specialnost`
--

DROP TABLE IF EXISTS `specialnost`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `specialnost` (
  `id` int NOT NULL AUTO_INCREMENT,
  `code` varchar(45) DEFAULT NULL,
  `name` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specialnost`
--

LOCK TABLES `specialnost` WRITE;
/*!40000 ALTER TABLE `specialnost` DISABLE KEYS */;
INSERT INTO `specialnost` VALUES (1,'13.23.23','Программирование в компьютерных сетях'),(2,'13.34.09','Бухгалтер');
/*!40000 ALTER TABLE `specialnost` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) DEFAULT NULL,
  `middle_name` varchar(100) DEFAULT NULL,
  `last_name` varchar(100) DEFAULT NULL,
  `bithdate` date DEFAULT NULL,
  `pole` enum('Мужской','Женский') DEFAULT NULL,
  `gruppa` int DEFAULT NULL,
  `Counter` varchar(100) DEFAULT NULL,
  `Oblast` varchar(100) DEFAULT NULL,
  `Raion` varchar(100) DEFAULT NULL,
  `City` varchar(100) DEFAULT NULL,
  `Street` varchar(100) DEFAULT NULL,
  `NumberHome` varchar(50) DEFAULT NULL,
  `NumberKvartira` bigint DEFAULT NULL,
  `Yandex` bigint DEFAULT NULL,
  `number_student` bigint DEFAULT NULL,
  `phone` bigint DEFAULT NULL,
  `PasSeriya` bigint DEFAULT NULL,
  `PasNumber` bigint DEFAULT NULL,
  `CodePodrazd` bigint DEFAULT NULL,
  `PasDate` date DEFAULT NULL,
  `PasWho` varchar(200) DEFAULT NULL,
  `Polis` bigint DEFAULT NULL,
  `mother` varchar(100) DEFAULT NULL,
  `father` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `gruppaIND` (`gruppa`),
  CONSTRAINT `gruppaFRG` FOREIGN KEY (`gruppa`) REFERENCES `gruppa` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (1,'Жаулыбаев','Темирлан','Кайратович','2001-12-01','Мужской',1,'Россия','Оренбургская','Адамовский','Майский','Советская','9',6,124534,1245,89325402329,5314,488711,423543,'2015-03-15','УФМ по Оренбургской обл. в Адамовском р-не',5345433,'Акмарал','Кайрат'),(2,'Ропов','Андрей','Юрьевич','2000-01-01','Мужской',2,'США','Калифорния','Минктон','Минктон','Джерси','4',3,345675,2343,9037248,3456,564565,546456,'2023-01-14','USA American freedom',342433,'Djesci','Mike'),(3,'Arlert','Armin','Radim','1999-02-26','Мужской',2,'gtr','trg','trg','gr','rtg','435',45,345,453,435,345,345,45,'2021-01-28','rg',345,'345','345'),(4,'Каипова','Полина','Александровна','2000-02-02','Женский',1,'Россия','Оренбургская','Орский','Орск','советская','67',34,324567,5344,8965335623,4354,345454,234345,'2021-02-14','УФС России в Орске',34324,'Таисия','Павел'),(6,'Волков','Виктор','Сергеевич','2001-03-28','Мужской',1,'Россия','Оренбургская','Орский','Орск','Добровольского','15а',123,213432,325,89225552144,5453,157214,2144,'2020-04-20','УМВД России по городу Орск',43543,'','');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) DEFAULT NULL,
  `middle_name` varchar(100) DEFAULT NULL,
  `last_name` varchar(100) DEFAULT NULL,
  `categories` varchar(45) DEFAULT NULL,
  `login` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES (1,'Финк','Игорь','Валерьевич','1','Igor','123');
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_load`
--

DROP TABLE IF EXISTS `type_load`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_load` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_load`
--

LOCK TABLES `type_load` WRITE;
/*!40000 ALTER TABLE `type_load` DISABLE KEYS */;
INSERT INTO `type_load` VALUES (1,'бюджет'),(2,'внебюджет');
/*!40000 ALTER TABLE `type_load` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-26 16:17:53
