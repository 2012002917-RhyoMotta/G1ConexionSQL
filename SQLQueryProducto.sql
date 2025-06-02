CREATE DATABASE Producto;
USE Producto;

CREATE TABLE Postres(
	id INT NOT NULL IDENTITY,
	nombre VARCHAR(50) NOT NULL,
	precio DECIMAL(6,2),
	stock FLOAT,
	CONSTRAINT pk_postres PRIMARY KEY(id)
);

Select * from Postres;