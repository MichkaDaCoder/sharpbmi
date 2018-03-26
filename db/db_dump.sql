/*
db_dump.sql : SQL dump file for project's MySQL Database. Run this file in CLI before installing the application in your system.
*/

/*Creating the project database "db_sharpbmi" */
CREATE DATABASE IF NOT EXISTS db_sharpbmi;

/*Creating "BMI" TABLE*/

CREATE TABLE IF NOT EXISTS BMI(
ID INT(11) NOT NULL AUTO_INCREMENT,
DATE_BMI DATETIME NOT NULL,
WEIGHT DECIMAL(10,0) NOT NULL,
HEIGHT DOUBLE NOT NULL,
VALUE DOUBLE NOT NULL,
EVALUATION VARCHAR(50) NOT NULL,
CONSTRAINT PK_BMI_ID PRIMARY KEY(ID)); 
