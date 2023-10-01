
--Nombre
--Apellido
--Cedula
--Tel�fono
--Correo
--Foto de perfil
--Cursos


CREATE TABLE CURSO(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOMBRE VARCHAR(140) NOT NULL,
	ID_CLIENTE INT NOT NULL,

	FOREIGN KEY (ID_CLIENTE) REFERENCES CLIENTE(ID)
);


CREATE TABLE CLIENTE(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOMBRE VARCHAR(140) NOT NULL,
	APELLIDO VARCHAR(140) NOT NULL,
	CEDULA VARCHAR(11) NOT NULL,
	TELEFONO VARCHAR(11),
	CORREO VARCHAR(140),
	URL_FOTO_PERFIL VARCHAR(140) NOT NULL,
);


DROP TABLE CLIENTE;


DROP TABLE CURSO;