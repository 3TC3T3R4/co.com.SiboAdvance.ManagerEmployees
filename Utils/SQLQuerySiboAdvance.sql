CREATE DATABASE SIBOADVANCE
USE SIBOADVANCE

CREATE TABLE Employee(

employees_id INT IDENTITY PRIMARY KEY  NOT NULL,
subArea_id INT NOT NULL,
typeDocument VARCHAR(3) NOT NULL,
number_ID INT NOT NULL,
name VARCHAR(25) NOT NULL,
lastName VARCHAR(25)NOT NULL,
CONSTRAINT FK_Employees_SubArea FOREIGN KEY (subArea_id) 
REFERENCES SubArea (subArea_id)
)


CREATE TABLE Area(
area_id INT IDENTITY PRIMARY KEY  NOT NULL,
name varchar(30) NOT NULL,
description varchar(50) NOT NULL,
)


CREATE TABLE SubArea(
subArea_id INT IDENTITY PRIMARY KEY NOT NULL,
area_id INT,
name varchar(30) NOT NULL,
description varchar(50) NOT NULL,
 CONSTRAINT FK_Area_subArea FOREIGN KEY (area_id) 
	REFERENCES Area (area_id) ON DELETE CASCADE
)

INSERT INTO Area (name,description) VALUES
('CONTABILIDAD','Donde se gestiona la nomina'),
('DESARROLLO','Donde se realiza la programacion')

INSERT INTO SubArea (area_id,name,description) VALUES
(1,'Cobro y Cartera','Donde se gestiona dinero de los empleados y client'),
(2,'Desarrollo Backend','Donde se programa en C# y Java'),
(2,'Desarrollo Frontend','Donde se programa en Javascript y Angular')

SELECT * FROM Employee
SELECT * FROM area
SELECT * FROM SubArea


SELECT * FROM Employee em
INNER JOIN SubArea sub ON em.subArea_id = sub.subArea_id
INNER JOIN Area ar ON ar.area_id = sub.area_id
WHERE ar.name = 'DESARROLLO'

SELECT sub.name, sub.description FROM SubArea sub
INNER JOIN Area ar ON ar.area_id = sub.area_id
WHERE ar.area_id = '2'

--Cuenta la cantidad de registros si existen con ese numero 
SELECT COUNT(*) FROM SubArea WHERE subArea_id = 1