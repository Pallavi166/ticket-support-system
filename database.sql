CREATE DATABASE ticketsystem;
use ticketsystem;

CREATE TABLE `tickets` (
  `TicketId` int NOT NULL AUTO_INCREMENT,
  `TicketNumber` varchar(50) DEFAULT NULL,
  `Subject` varchar(200) DEFAULT NULL,
  `Description` text,
  `Priority` varchar(20) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` int DEFAULT NULL,
  `AssignedTo` int DEFAULT NULL,
  PRIMARY KEY (`TicketId`)
) 


CREATE TABLE `ticketcomments` (
  `CommentId` int NOT NULL AUTO_INCREMENT,
  `TicketId` int DEFAULT NULL,
  `CommentText` text,
  `CommentedBy` int DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`CommentId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



CREATE TABLE `users` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) DEFAULT NULL,
  `Password` varchar(50) DEFAULT NULL,
  `role` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

Insert into users(Username,Password,role)
values('admin','admin123','admin')

Insert into users(Username,Password,role)
values('user1','user123','user');



CREATE TABLE `ticketstatushistory` (
  `HistoryId` int NOT NULL AUTO_INCREMENT,
  `TicketId` int DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `updatedBy` int DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`HistoryId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

