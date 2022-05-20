SET NAMES 'utf8';

DROP DATABASE IF EXISTS votingtime;

CREATE DATABASE votingtime CHARACTER SET utf8 COLLATE utf8_general_ci;

GRANT ALL ON votingtime.* TO 'voter'@'%' IDENTIFIED BY 'Password1';

USE votingtime;

CREATE TABLE voteoptions (optionname VARCHAR(25) PRIMARY KEY);

INSERT INTO voteoptions VALUES ('Cats'), ('Dogs');

CREATE TABLE votecasts (id INT PRIMARY KEY AUTO_INCREMENT, voteoption VARCHAR(25));