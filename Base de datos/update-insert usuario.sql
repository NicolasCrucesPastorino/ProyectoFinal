UPDATE USUARIO 
SET 
nombre='nombre',
apellido='ape',
correo='correo',
nombreUsuario= 'cliente2', 
clave='12345',
urlFoto='',
nombreFoto= '',
telefono='1111112222',
idRol=1,
esActivo=1,
fechaRegistro=getdate() 
where idUsuario=15


insert into usuario (nombre,apellido,correo,nombreUsuario,clave,urlFoto,nombreFoto,telefono,idRol,esActivo,fechaRegistro) 
VALUES 
('nom',
'apell',
'coo',
'', 
'1234',
'',
'',
'112222211',
1,
1,
getdate()
) 
