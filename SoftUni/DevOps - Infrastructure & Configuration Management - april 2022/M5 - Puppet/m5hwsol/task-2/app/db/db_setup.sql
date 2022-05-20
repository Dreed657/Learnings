DROP DATABASE IF EXISTS bulgaria;

CREATE DATABASE bulgaria CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

grant all on bulgaria.* to 'web_user'@'%' identified by 'Password1';

use bulgaria;

create table cities (id int primary key auto_increment, city_name varchar(50), population int);

INSERT INTO cities (city_name, population) VALUES ('София', 1236047);
INSERT INTO cities (city_name, population) VALUES ('Пловдив', 343424);
INSERT INTO cities (city_name, population) VALUES ('Варна', 335177);
INSERT INTO cities (city_name, population) VALUES ('Бургас', 202766);
INSERT INTO cities (city_name, population) VALUES ('Русе', 144936);
INSERT INTO cities (city_name, population) VALUES ('Стара Загора', 136781);
INSERT INTO cities (city_name, population) VALUES ('Плевен', 98467);
INSERT INTO cities (city_name, population) VALUES ('Сливен', 87322);
INSERT INTO cities (city_name, population) VALUES ('Добрич', 85402);
INSERT INTO cities (city_name, population) VALUES ('Шумен', 76967);
