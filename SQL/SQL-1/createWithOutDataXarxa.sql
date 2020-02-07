create table fotos (
	id int not null auto_increment,
    location varchar (70),
    urlFoto varchar (255),
    primary key (id)
    );
create table usuari (
	id int not null auto_increment,
    nom varchar(30),
    email varchar (40),
    password varchar (20),
    idFoto int,
    primary key (id),
    foreign key (idFoto)
		references fotos (id)
);
create table amics (
	id int not null auto_increment,
    idAmigo1 int,
    idAmigo2 int,
    como varchar (255),
    primary key (id),
    foreign key (idAmigo1) references usuari (id),
	foreign key (idAmigo2) references usuari (id)
);
