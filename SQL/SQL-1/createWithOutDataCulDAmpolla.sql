/*create database culDAmpolla;*/
use culDAmpolla;

create table empleats (
	id int not null auto_increment,
    nom varchar (30),
    primary key (id)
);
create table clients (
	id int not null auto_increment,
    nom varchar(30),
    direccio varchar (50),
    tel varchar (14),
    email varchar (40),
    dataReg datetime,
    idClienteRecomendador int,
    primary key (id),
    foreign key (idClienteRecomendador) references clients (id)
);
create table proveidors(
	id int not null auto_increment,
    nom varchar(30),
    nif varchar(9),
    carrer varchar(40),
    numero varchar(5),
    pis varchar (5),
    porta varchar (5),
    ciutat varchar (30),
    cp varchar (5),
    pais varchar (30),
    tel varchar (14),
    email varchar (40),
    primary key (id)
);
create table ulleres (
	id int not null auto_increment,
	marca enum ( "Ray-Ban","Tom" ,"Ford", "Prada","Fashion","Oakley","Giorgio Armani", "Moo"),
    model varchar (20),
    graduL enum ("0","0.5","1","1,5","2","2.5","3","3,5","4","4.5","5"),
    graduR enum ("0","0.5","1","1,5","2","2.5","3","3,5","4","4.5","5"),
    tipusMontura enum ("flotant", "pasta", "metàl·lica"),
    colorMontura enum ("Red","Orange","Yellow","Green","Blue","Purple","Brown","Magenta"),
    colorVidre enum("Red","Orange","Yellow","Green","Blue","Purple","Brown","Magenta"),
    preu float,
    primary key (id)
);
create table factures(
	id int not null auto_increment,
    idCliente int,
    idEmpleat int,
    dataFactura datetime,
    primary key (id),
    foreign key (idCliente) references clients(id),
    foreign key (idEmpleat) references empleats (id)
);

create table ullereProveidor (
	id int not null auto_increment,
    idUlleres int,
    idProveidor int,
    primary key (id),
    foreign key (idUlleres) references ulleres (id),
    foreign key (idProveidor) references proveidors (id)
);
create table detallFactura (
	id int not null auto_increment,
    idFacture int,
    idUllereProveidor int,
    primary key (id),
    foreign key (idFacture) references factures (id),
    foreign key (idUllereProveidor) references ullereProveidor (id)
);
