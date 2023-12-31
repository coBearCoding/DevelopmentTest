

IF NOT EXISTS (SELECT * FROM TESTING_ETL.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PERSONA')
BEGIN
    CREATE TABLE PERSONA(
     ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
     NOMBRES VARCHAR(100),
     APELLIDOS VARCHAR(100),
     CEDULA VARCHAR(20) NOT NULL UNIQUE
 )
END


IF NOT EXISTS (SELECT * FROM TESTING_ETL.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'INFORMACION')
BEGIN
    CREATE TABLE INFORMACION(
     ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
     ID_PERSONA INT NOT NULL UNIQUE,
     CEDULA VARCHAR(20),
     TELEFONO VARCHAR(20),
     CORREO VARCHAR(150),
     DIRECCION VARCHAR(150),

     FOREIGN KEY(ID_PERSONA) REFERENCES PERSONA(ID)
 )
END


IF NOT EXISTS (SELECT * FROM TESTING_ETL.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PERSONA_INFORMACION')
BEGIN
   CREATE TABLE "PERSONA_INFORMACION_DM" (
    "ID_PERSONA_DM" int,
    "NOMBRES" nvarchar(100),
    "APELLIDOS" nvarchar(100),
    "CEDULA" nvarchar(20),
    "TELEFONO" nvarchar(20),
    "CORREO" nvarchar(150),
    "PERSONA_ID" int,
    "INFORMACION_ID" int,
    "DIRECCION" nvarchar(150)
)
END