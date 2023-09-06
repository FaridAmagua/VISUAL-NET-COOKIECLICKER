# VISUAL-NET-COOKIECLICKER
1.0 V cookie clicker
Data Base : 
CREATE DATABASE IF NOT EXISTS CookieClicker;
USE CookieClicker;
-- DROPS
DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS tiendas;
DROP TABLE IF EXISTS cromos;
DROP TABLE IF EXISTS cromos_tiendas;

CREATE TABLE USUARIOS(
            id_usuario INT primary key auto_increment,
            nick VARCHAR(30) NOT NULL UNIQUE,
            pass varchar(60) NOT NULL,
			t_usuario ENUM('1','2','3'),
            n_galletas INT NOT NULL default 0
            );
            
CREATE TABLE EDIFICIOS(
            id_edificio INT primary key auto_increment,
            nombre VARCHAR(30) NOT NULL,
            precio_inical INT NOT NULL
            );
            
CREATE TABLE USUARIO_EDIFICOS(
				id_usuario_edificio int primary key auto_increment,
                id_usuario int not null,
                id_edificio int not null,
                cantidad int default 1,
                foreign key (id_usuario) references USUARIOS(id_usuario),
                foreign key(id_edificio) references EDIFICIOS(id_edificio)
            );
            


insert into usuario(nick,pass,t_usuario) values('admin','123','3')


DELIMITER $$
CREATE PROCEDURE RegistrarUsuariov1
										(IN  _nick varchar(30),
                                        IN  _pass varchar(60),
                                        IN  _t_usuario varchar(50),
                                      --  IN n_galletas int,
                                        out res int)
                                        --  caso de que las galletas estan a NULL
pa:
BEGIN


insert into USUARIOS(nick,pass,t_usuario) values(_nick,_pass,_t_usuario);
set res = 0;

    
END$$de
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE loginV1(IN _nick varchar(30),IN _pass varchar(60),_t_usuario varchar(10),out res1 varchar(10),out res2 varchar(10),out res3 varchar(10),out res4 int)				
pa:
BEGIN
declare usuarios varchar(30);declare contrasena varchar(30); declare tipo_usuario varchar(10);declare aux int;
set usuarios = null; set contrasena = null; set tipo_usuario=null; set aux = null;

select  COUNT(*) from USUARIOS where USUARIOS._nick = _nick and usuario.pass = _pass and t_usuario=_t_usuario into aux;
if aux = 1 then
set res4 = 1;
else 
set res4 = -1;
end if; 


END$$
DELIMITER ;

select count(*)  from USUARIOS where nick = 'admin'limit 1;



