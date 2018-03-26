create database LOGFiles
USE LOGFiles
create Table Logtable 
(
  ID int NOT NULL AUTO_INCREMENT,
 RequestTime DATETIME  NOT NULL,
 IpOrHost VARCHAR(256) NOT NULL,
 Routing VARCHAR (256) NOT NULL,
 AdditionalParam VARCHAR (256) NULL,
 Result INT NOT NULL,
 [Location] NVARCHAR(50) NOT NULL,
 Size INT NOT NULL)



 CREATE PROCEDURE InsertLog(
 @RequestTime DATETIME,
 @IpOrHost VARCHAR(256),
 @Routing VARCHAR (256),
 @AdditionalParam VARCHAR (256),
 @ Result INT,
 @Location NVARCHAR(50),
 @Size INT)
 AS 
 BEGIN 
 INSERT INTO Logtable (
 RequestTime,
 IpOrHost,
 Routing,
 AdditionalParam,
 Result,
 [Location],
 Size
 )
 VALUES(
 @RequestTime,
 @IpOrHost ),
 @Routing,
 @AdditionalParam ,
 @ Result ,
 @Location,
 @Size INT)
 end

 



 
