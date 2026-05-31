CREATE DATABASE TrainReservationDB;
USE TrainReservationDB;
CREATE TABLE AdminLogin(AdminId INT PRIMARY KEY IDENTITY,Username VARCHAR(50) UNIQUE,Password VARCHAR(50));
INSERT INTO AdminLogin VALUES ('admin','admin123');
CREATE TABLE UserLogin(UserId INT PRIMARY KEY IDENTITY,Username VARCHAR(50) UNIQUE,Password VARCHAR(50));
INSERT INTO UserLogin VALUES ('user','user123');
CREATE TABLE TrainDetails(TrainNo INT PRIMARY KEY,TrainName VARCHAR(100),SourceStation VARCHAR(50),DestinationStation VARCHAR(50),IsDeleted BIT DEFAULT 0);
CREATE TABLE TrainClasses(ClassId INT PRIMARY KEY IDENTITY,TrainNo INT,ClassType VARCHAR(20),Availability INT,Charges DECIMAL(10,2),FOREIGN KEY (TrainNo) REFERENCES TrainDetails(TrainNo));
INSERT INTO TrainDetails VALUES
(12601,'Chennai Express','Chennai','Bangalore',0),
(12602,'Brindavan Express','Chennai','Hyderabad',0),
(12603,'Coromandel Express','Chennai','Visakhapatnam',0),
(12604,'Charminar Express','Hyderabad','Chennai',0),
(12605,'Bangalore Mail','Bangalore','Chennai',0),
(12606,'Vizag Express','Visakhapatnam','Chennai',0);
INSERT INTO TrainClasses VALUES
(12601,'Sleeper',50,500),
(12601,'3AC',40,1200),
(12601,'2AC',30,2000),

(12602,'Sleeper',45,550),
(12602,'3AC',35,1100),
(12602,'2AC',20,1800),


(12603,'Sleeper',50,500),
(12603,'3AC',40,1200),
(12603,'2AC',30,2000),

(12604,'Sleeper',45,550),
(12604,'3AC',35,1100),
(12604,'2AC',20,1800),


(12605,'Sleeper',50,500),
(12605,'3AC',40,1200),
(12605,'2AC',30,2000),

(12606,'Sleeper',45,550),
(12606,'3AC',35,1100),
(12606,'2AC',20,1800);

CREATE TABLE BookingDetails(BookingId INT PRIMARY KEY IDENTITY,Username VARCHAR(50),BookDate DATETIME,TravelDate DATE,TrainNo INT,ClassType VARCHAR(20),Passengers VARCHAR(200),NoOfTickets INT,Amount DECIMAL(10,2),JourneyType VARCHAR(20),
FOREIGN KEY (TrainNo) REFERENCES TrainDetails(TrainNo));
 
CREATE TABLE CancellationDetails(CId INT PRIMARY KEY IDENTITY,BookingId INT,CancelDate DATETIME,NoTickets INT,RefundAmount DECIMAL(10,2),FOREIGN KEY (BookingId) REFERENCES BookingDetails(BookingId));
SELECT * FROM TrainDetails;
ALTER TABLE BookingDetails
ADD Status VARCHAR(20) DEFAULT 'Booked'
SELECT * FROM BookingDetails
