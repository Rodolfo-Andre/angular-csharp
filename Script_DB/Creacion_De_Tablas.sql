CREATE DATABASE db_empleados;
USE db_empleados;

/* -------- CREACIÓN DE TABLAS -------- */

CREATE TABLE tb_area_trabajo (
	id INT IDENTITY(1,1) PRIMARY KEY,
	area_trabajo VARCHAR(50)
);

CREATE TABLE tb_pais (
	id INT IDENTITY(1,1) PRIMARY KEY,
	pais VARCHAR(50)
);


CREATE TABLE tb_tipo_documento (
	id INT IDENTITY(1,1) PRIMARY KEY,
	tipo_documento VARCHAR(50)
);

CREATE TABLE tb_empleado (
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombres VARCHAR(50) NOT NULL,
	apellidos VARCHAR(50) NOT NULL,
	codigo_telefono VARCHAR(10) NOT NULL,
	telefono VARCHAR(16) NOT NULL,
	correo VARCHAR(50) NOT NULL,
	fecha_nacimiento DATE NOT NULL,
	sueldo DECIMAL(10,2) NOT NULL,
	estado_civil VARCHAR(10) NOT NULL,
	id_area_trabajo INT NOT NULL,
	id_pais_nacimiento INT NOT NULL,
	id_tipo_documento INT NOT NULL,
	nro_documento VARCHAR(16) NOT NULL,
	sexo CHAR(1) CHECK (sexo IN ('M', 'F')),
	estado INT DEFAULT 1 NOT NULL,
	fecha_registro DATETIME DEFAULT GETDATE() NOT NULL,
	fecha_actualizacion DATETIME
	CONSTRAINT fk_empleado_area_trabajo FOREIGN KEY (id_area_trabajo) REFERENCES tb_area_trabajo(id),
	CONSTRAINT fk_empleado_pais_nacimiento FOREIGN KEY (id_pais_nacimiento) REFERENCES tb_pais(id),
	CONSTRAINT fk_empleado_tipo_documento FOREIGN KEY (id_tipo_documento) REFERENCES tb_tipo_documento(id),
);

/* -------- INSERCIÓN DE DATOS FICTICIOS -------- */

/* -------- AREA DE TRABAJO -------- */
INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Diseño y Experiencia de Usuario (UX/UI)')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Desarrollo de Software')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Seguridad Informática')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Redes y Administración de Sistemas')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Inteligencia Artificial y Aprendizaje Automático')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Big Data y Análisis de Datos')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Desarrollo de Videojuegos')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Realidad Virtual (VR) y Realidad Aumentada (AR)')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Internet de las Cosas (IoT)')

INSERT INTO tb_area_trabajo (area_trabajo) VALUES('Desarrollo de Aplicaciones Móviles')

/* -------- TIPO DOCUMENTO -------- */
INSERT INTO tb_tipo_documento (tipo_documento) VALUES('Pasaporte')

INSERT INTO tb_tipo_documento (tipo_documento) VALUES('DNI')

INSERT INTO tb_tipo_documento (tipo_documento) VALUES('Cédula')

/* -------- PAIS -------- */
INSERT tb_pais (pais) VALUES ('Afghanistan')

INSERT tb_pais (pais) VALUES ('Albania')

INSERT tb_pais (pais) VALUES ('American Samoa')

INSERT tb_pais (pais) VALUES ('Angola')

INSERT tb_pais (pais) VALUES ('Argentina')

INSERT tb_pais (pais) VALUES ('Armenia')

INSERT tb_pais (pais) VALUES ('Bahrain')

INSERT tb_pais (pais) VALUES ('Belarus')

INSERT tb_pais (pais) VALUES ('Belgium')

INSERT tb_pais (pais) VALUES ('Benin')

INSERT tb_pais (pais) VALUES ('Bolivia')

INSERT tb_pais (pais) VALUES ('Bosnia and Herzegovina')

INSERT tb_pais (pais) VALUES ('Brazil')

INSERT tb_pais (pais) VALUES ('Bulgaria')

INSERT tb_pais (pais) VALUES ('Cameroon')

INSERT tb_pais (pais) VALUES ('Canada')

INSERT tb_pais (pais) VALUES ('Chile')

INSERT tb_pais (pais) VALUES ('China')

INSERT tb_pais (pais) VALUES ('Colombia')

INSERT tb_pais (pais) VALUES ('Costa Rica')

INSERT tb_pais (pais) VALUES ('Croatia')

INSERT tb_pais (pais) VALUES ('Cuba')

INSERT tb_pais (pais) VALUES ('Czech Republic')

INSERT tb_pais (pais) VALUES ('Democratic Republic of the Congo')

INSERT tb_pais (pais) VALUES ('Denmark')

INSERT tb_pais (pais) VALUES ('Dominican Republic')

INSERT tb_pais (pais) VALUES ('Ecuador')

INSERT tb_pais (pais) VALUES ('Egypt')

INSERT tb_pais (pais) VALUES ('El Salvador')

INSERT tb_pais (pais) VALUES ('Ethiopia')

INSERT tb_pais (pais) VALUES ('Finland')

INSERT tb_pais (pais) VALUES ('France')

INSERT tb_pais (pais) VALUES ('Germany')

INSERT tb_pais (pais) VALUES ('Greece')

INSERT tb_pais (pais) VALUES ('Guam')

INSERT tb_pais (pais) VALUES ('Guatemala')

INSERT tb_pais (pais) VALUES ('Guinea')

INSERT tb_pais (pais) VALUES ('Haiti')

INSERT tb_pais (pais) VALUES ('Honduras')

INSERT tb_pais (pais) VALUES ('Iceland')

INSERT tb_pais (pais) VALUES ('Indonesia')

INSERT tb_pais (pais) VALUES ('Iran')

INSERT tb_pais (pais) VALUES ('Ireland')

INSERT tb_pais (pais) VALUES ('Italy')

INSERT tb_pais (pais) VALUES ('Japan')

INSERT tb_pais (pais) VALUES ('Jordan')

INSERT tb_pais (pais) VALUES ('Kazakhstan')

INSERT tb_pais (pais) VALUES ('Kosovo')

INSERT tb_pais (pais) VALUES ('Latvia')

INSERT tb_pais (pais) VALUES ('Lesotho')

INSERT tb_pais (pais) VALUES ('Libya')

INSERT tb_pais (pais) VALUES ('Lithuania')

INSERT tb_pais (pais) VALUES ('Luxembourg')

INSERT tb_pais (pais) VALUES ('Malawi')

INSERT tb_pais (pais) VALUES ('Malaysia')

INSERT tb_pais (pais) VALUES ('Mali')

INSERT tb_pais (pais) VALUES ('Malta')

INSERT tb_pais (pais) VALUES ('Mexico')

INSERT tb_pais (pais) VALUES ('Mongolia')

INSERT tb_pais (pais) VALUES ('Netherlands')

INSERT tb_pais (pais) VALUES ('New Caledonia')

INSERT tb_pais (pais) VALUES ('New Zealand')

INSERT tb_pais (pais) VALUES ('Nigeria')

INSERT tb_pais (pais) VALUES ('North Korea')

INSERT tb_pais (pais) VALUES ('Norway')

INSERT tb_pais (pais) VALUES ('Oman')

INSERT tb_pais (pais) VALUES ('Pakistan')

INSERT tb_pais (pais) VALUES ('Palestinian Territory')

INSERT tb_pais (pais) VALUES ('Panama')

INSERT tb_pais (pais) VALUES ('Peru')

INSERT tb_pais (pais) VALUES ('Philippines')

INSERT tb_pais (pais) VALUES ('Poland')

INSERT tb_pais (pais) VALUES ('Portugal')

INSERT tb_pais (pais) VALUES ('Russia')

INSERT tb_pais (pais) VALUES ('Saint Vincent and the Grenadines')

INSERT tb_pais (pais) VALUES ('Saudi Arabia')

INSERT tb_pais (pais) VALUES ('Serbia')

INSERT tb_pais (pais) VALUES ('Sierra Leone')

INSERT tb_pais (pais) VALUES ('Slovenia')

INSERT tb_pais (pais) VALUES ('South Africa')

INSERT tb_pais (pais) VALUES ('South Korea')

INSERT tb_pais (pais) VALUES ('Spain')

INSERT tb_pais (pais) VALUES ('Sri Lanka')

INSERT tb_pais (pais) VALUES ('Swaziland')

INSERT tb_pais (pais) VALUES ('Sweden')

INSERT tb_pais (pais) VALUES ('Switzerland')

INSERT tb_pais (pais) VALUES ('Syria')

INSERT tb_pais (pais) VALUES ('Tajikistan')

INSERT tb_pais (pais) VALUES ('Tanzania')

INSERT tb_pais (pais) VALUES ('Thailand')

INSERT tb_pais (pais) VALUES ('Tunisia')

INSERT tb_pais (pais) VALUES ('Uganda')

INSERT tb_pais (pais) VALUES ('Ukraine')

INSERT tb_pais (pais) VALUES ('United Kingdom')

INSERT tb_pais (pais) VALUES ('United States')

INSERT tb_pais (pais) VALUES ('Uruguay')

INSERT tb_pais (pais) VALUES ('Venezuela')

INSERT tb_pais (pais) VALUES ('Vietnam')

INSERT tb_pais (pais) VALUES ('Yemen')

INSERT tb_pais (pais) VALUES ('Zimbabwe')
