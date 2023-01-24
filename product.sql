CREATE DATABASE db_product;
USE db_product;
CREATE TABLE IF NOT EXISTS tbl_product (
	id_product smallint AUTO_INCREMENT PRIMARY KEY,
	name_product Varchar(150) NOT NULL,
    active_product tinyint default 1 NOT NULL,
	description_product Varchar(250) NOT NULL,
	price_product DECIMAL(10,2) NOT NULL
);

show tables;
