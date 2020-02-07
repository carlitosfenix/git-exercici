CREATE TABLE autors (
    id INT NOT NULL AUTO_INCREMENT,
    direccio VARCHAR(60),
    email VARCHAR(40),
    url VARCHAR(255),
    numeroPublicaciones INT NOT NULL,
    PRIMARY KEY (id)
);
CREATE TABLE llibres (
    id INT NOT NULL AUTO_INCREMENT,
    editorial VARCHAR(30),
    idAutor INT NOT NULL,
    titulo VARCHAR(30),
    PRIMARY KEY (id),
    FOREIGN KEY (idAutor)
        REFERENCES autors (id)
);
CREATE TABLE usuaris (
    id INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(40),
    email VARCHAR(40),
    password VARCHAR(50),
    PRIMARY KEY (id)
);
CREATE TABLE facturas (
	id int not null auto_increment,
    idUsuari int,
    dateHour datetime,
    primary key (id),
    foreign key (idUsuari)
		references usuaris (id)
);
create table detalls (
	id int not null auto_increment,
    idLlibre int,
    idFactura int,
    primary key (id),
    foreign key (idLlibre)
		references llibres (id),
    foreign key (idFactura)
		references facturas (id)
);