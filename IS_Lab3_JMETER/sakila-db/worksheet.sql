use sakila;

select * from actor;

DROP USER 'sakila1'@'%';
CREATE USER 'sakila1'@'%' IDENTIFIED BY 'pass';
DROP USER 'sakila2'@'%';
CREATE USER 'sakila2'@'%' IDENTIFIED BY 'pass';
GRANT ALL PRIVILEGES ON sakila.* TO 'sakila1'@'%';
GRANT ALL PRIVILEGES ON sakila.* TO 'sakila2'@'%';

SELECT User, Host FROM mysql.user;

SELECT * from actor WHERE first_name = 'ADAM';
SELECT * from actor WHERE first_name = 'CHRIS';