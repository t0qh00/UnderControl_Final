-- SCRIPT DE BASE DE DATOS DE UnderControl

-- CREACION DE LA BASE DE DATOS
use [Master]
go

if exists(select name from dbo.sysdatabases where name = 'UnderControl')
drop database [UnderControl]
go

create database [UnderControl]
go

--Creacion del usuario con permisos y uso de la base de datos
create login userUnderControl with password='ucr2020'

use [UnderControl]

create user userUnderControl for login userUnderControl with default_schema = [UnderControl]

alter role db_owner add member userUnderControl 
go

-------------------------------------------------------------------------------------------
-- TABLAS
-------------------------------------------------------------------------------------------

--****************************************************Materiales*****************************************************--

if exists(select name from dbo.sysobjects where name= 'TblMateriales')
drop table [TblMateriales]
go

-- Tabla de materiales
create table [TblMateriales](
idMaterial int identity not null primary key,
nombre varchar(50) not null,
tipo  varchar(50) not null,
cantidad int not  null,
precio  decimal not null,
proveedor varchar(50) not null)
go

insert  into [TblMateriales](nombre,tipo,cantidad,precio,proveedor)
values('cedro','madera',10,10500,'aserradero.S.A')
go
insert  into [TblMateriales](nombre,tipo,cantidad,precio,proveedor)
values('aluminio','galvalizado',10,11500,'aluminio.S.A')
go

select * from [TblMateriales]

--procedimiento almacenado para busqueda de materiales
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_MaterialXId')
drop procedure [Sp_Cns_MaterialXId]
go

create procedure [Sp_Cns_MaterialXId](
@idMaterial varchar(50))
as
select m.idMaterial, m.nombre, m.tipo, m.cantidad, m.precio,m.proveedor
from TblMateriales m with(nolock)
where m.idMaterial = @idMaterial
go

--testing de procedimiento almacenado 
exec [Sp_Cns_MaterialXId] '1'
go

--procedimiento para insercion de materiales
if exists (select name from dbo.sysobjects where name = 'Sp_Ins_Materiales')
drop procedure [Sp_Ins_Materiales]
go

create procedure [Sp_Ins_Materiales](
@nombre varchar(50),
@tipo varchar(50),
@cantidad int,
@precio decimal,
@proveedor varchar(50))
as
insert into TblMateriales(nombre,tipo,cantidad,precio,proveedor)
values(@nombre,@tipo,@cantidad,@precio,@proveedor)
go

select * from [TblMateriales];

--Procedimiento almacenado para modificar los materiales
if exists (select name from dbo.sysobjects where name = 'Sp_Upd_Materiales')
drop procedure [Sp_Upd_Materiales]
go

create procedure [dbo].[Sp_Upd_Materiales](
@idMaterial int,
@nombre varchar(50),
@tipo varchar(50),
@cantidad int,
@precio decimal,
@proveedor varchar(50))
as
update  TblMateriales set
nombre = @nombre,
tipo = @tipo,
cantidad= @cantidad,
precio = @precio,
proveedor = @proveedor
where idMaterial = @idMaterial
go

--procedimiento para realizar una eliminación  
if exists (select name from dbo.sysobjects where name = 'Sp_Del_Materiales')
drop procedure [Sp_Del_Materiales]
go

create procedure [Sp_Del_Materiales](
@idMaterial int)
as
---delete from tblMateriales where idMaterial = @idMaterial
delete TblMateriales
where idMaterial = @idMaterial
go

if exists(select name from dbo.sysobjects where name= 'TblProveedores')
drop table [TblProveedores]
go

-- Tabla de proveedores
create table [TblProveedores](
idProveedor int identity not null primary key,
nombre varchar(50) not null,)
go

insert  into [TblProveedores](nombre)
values('Aserradero.S.A')
go
insert  into [TblProveedores](nombre)
values('Alumer.S.A')
go
insert  into [TblProveedores](nombre)
values('Vidriera.S.A')
go
insert  into [TblProveedores](nombre)
values('Ferreteria.S.A')
go
insert  into [TblProveedores](nombre)
values('Mundo Telas')
go

select * from [TblProveedores]

--procedimiento almacenado para busqueda de proveedores
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_ProveedoresXNombre')
drop procedure [Sp_Cns_ProveedoresXNombre]
go

create procedure [Sp_Cns_ProveedoresXNombre](
@nombre varchar(100))
as
select p.idProveedor, p.nombre
from TblProveedores p with(nolock)
where p.nombre like '%' + @nombre + '%'
order by p.nombre
go

--testing de procedimiento almacenado 
exec [Sp_Cns_ProveedoresXNombre] 'a'
go

--****************************************************Clientes*****************************************************--

if exists(select name from dbo.sysobjects where name= 'TblClientes')
drop table [TblClientes]
go

-- Tabla de clientes
create table [TblClientes](
cedula varchar(12) not null primary key,
nombre varchar(50) not null,
email  varchar(50) not null,
telefono varchar(8) not null)
go

insert  into [TblClientes](cedula,nombre,email,telefono)
values('601230456','Lun','selenia787@gmail.com','85858585')
go
insert  into [TblClientes](cedula,nombre,email,telefono)
values('6','Lun','selenia787@gmail.com','85858585')
go
select * from [TblClientes]

--procedimiento almacenado para busqueda de clientes
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_ClientesXCedula')
drop procedure [Sp_Cns_ClientesXCedula]
go

create procedure [Sp_Cns_ClientesXCedula](
@cedula varchar(12))
as
select c.cedula, c.nombre, c.email, c.telefono
from TblClientes c with(nolock)
where c.cedula = @cedula
go

--testing de procedimiento almacenado 
exec [Sp_Cns_ClientesXCedula] '601230456'
go

--procedimiento para insercion de clientes
if exists (select name from dbo.sysobjects where name = 'Sp_Ins_Clientes')
drop procedure [Sp_Ins_Clientes]
go

create procedure [Sp_Ins_Clientes](
@cedula varchar(12),
@nombre varchar(50),
@email varchar(50),
@telefono varchar(8))
as
insert into TblClientes(cedula,nombre,email,telefono)
values(@cedula,@nombre,@email,@telefono)
go

select * from [TblClientes];

--Procedimiento almacenado para modificar los clientes
if exists (select name from dbo.sysobjects where name = 'Sp_Upd_Clientes')
drop procedure [Sp_Upd_Clientes]
go

create procedure [dbo].[Sp_Upd_Clientes](
@cedula varchar(12),
@nombre varchar(50),
@email varchar(50),
@telefono varchar(8))
as
update  TblClientes set
nombre = @nombre,
email = @email,
telefono = @telefono
where cedula = @cedula
go

---procedimiento para realizar una eliminación  
if exists (select name from dbo.sysobjects where name = 'Sp_Del_Clientes')
drop procedure [Sp_Del_Clientes]
go

create procedure [Sp_Del_Clientes](
@cedula varchar(12))
as
delete from  TblClientes
where cedula = @cedula
go

--****************************************************ManodeObra*****************************************************--

if exists(select name from dbo.sysobjects where name= 'TblManodeObra')
drop table [TblManodeObra]
go

-- Tabla 
create table [TblManodeObra](
id int identity not null,
cedula varchar(12) not null,
nombre varchar(50) not null,
email  varchar(50) not null,
jornada varchar(8) not null,
estado varchar(12) not null)
go

alter table [TblManodeObra] add constraint PK_LlavesManoObra primary key (id, cedula)

insert  into [TblManodeObra](cedula,nombre,email,jornada,estado)
values('601230456','Lun','selenia787@gmail.com','diurna','A')
go
insert  into [TblManodeObra](cedula,nombre,email,jornada,estado)
values('1','Mar','selenia787@gmail.com','diurna','A')
go

select * from [TblManodeObra]

--procedimiento almacenado para busqueda 
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_ManodeObraXId')
drop procedure [Sp_Cns_ManodeObraXId]
go

create procedure [Sp_Cns_ManodeObraXId](
@id varchar(5))
as
select m.id, m.cedula, m.nombre, m.email, m.jornada,m.estado
from TblManodeObra m with(nolock)
where m.id  = @id 
go

--testing de procedimiento almacenado 
exec [Sp_Cns_ManodeObraXId] '1'
go

--procedimiento para insercion
if exists (select name from dbo.sysobjects where name = 'Sp_Ins_ManodeObra')
drop procedure [Sp_Ins_ManodeObra]
go

create procedure [Sp_Ins_ManodeObra](
@cedula varchar (12),
@nombre varchar(50),
@email varchar (50),
@jornada varchar(8),
@estado varchar(12))
as
insert into TblManodeObra(cedula,nombre,email,jornada,estado)
values(@cedula,@nombre,@email,@jornada,@estado)
go

select * from [TblManodeObra];

--Procedimiento almacenado para modificar 
if exists (select name from dbo.sysobjects where name = 'Sp_Upd_ManodeObra')
drop procedure [Sp_Upd_ManodeObra]
go

create procedure [dbo].[Sp_Upd_ManodeObra](
@id int,
@cedula varchar (12),
@nombre varchar(50),
@email varchar (50),
@jornada varchar(8),
@estado varchar(12))
as
update  TblManodeObra set
cedula = @cedula,
nombre = @nombre,
email = @email,
jornada = @jornada,
estado = @estado
where id = @id
go

---procedimiento para realizar una eliminación  
if exists (select name from dbo.sysobjects where name = 'Sp_Del_ManodeObra')
drop procedure [Sp_Del_ManodeObra]
go

create procedure [Sp_Del_ManodeObra](
@id int)
as
delete from  TblManodeObra
where id = @id
go

--procedimiento almacenado para busqueda de empleados
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_IdEmpleadoXId')
drop procedure [Sp_Cns_IdEmpleadoXId]
go

create procedure [Sp_Cns_IdEmpleadoXId](
@id varchar(100))
as
select m.id, m.cedula, m.nombre, m.email, m.jornada, m.estado
from TblManodeObra m with(nolock)
where m.id like '%' + @id + '%'
order by m.id
go

--testing de procedimiento almacenado 
exec [Sp_Cns_IdEmpleadoXId] '1'
go

--****************************************************Ordenes*****************************************************--

if exists(select name from dbo.sysobjects where name= 'TblOrdenes')
drop table [TblOrdenes]
go

-- Tabla de ordenes
create table [TblOrdenes](
idOrden int identity not null primary key,
cedula varchar(12) not null,  
fechaRegistro  date not null,
fechaEntrega date not  null,
obsProducto  varchar(max) not null)
go

insert  into [TblOrdenes](cedula,fechaRegistro,fechaEntrega,obsProducto)
values('601230456','11-16-2020','11-18-2020','regular')
go

select * from [TblOrdenes]

--procedimiento almacenado para busqueda 
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_OrdenesXId')
drop procedure [Sp_Cns_OrdenesXId]
go

create procedure [Sp_Cns_OrdenesXId](
@idOrden varchar(5))
as
select o.idOrden, o.cedula, o.fechaRegistro, o.fechaEntrega, o.obsProducto
from TblOrdenes o with(nolock)
where o.idOrden = @idOrden
go

--testing de procedimiento almacenado 
exec [Sp_Cns_OrdenesXId] '1'
go

--procedimiento para insercion de orden
if exists (select name from dbo.sysobjects where name = 'Sp_Ins_Orden')
drop procedure [Sp_Ins_Orden]
go

create procedure [Sp_Ins_Orden](
@cedula varchar(12),
@fechaRegistro date,
@fechaEntrega date,
@obsProducto  varchar(max))
as
insert into TblOrdenes(cedula,fechaRegistro,fechaEntrega,obsProducto)
values(@cedula,@fechaRegistro,@fechaEntrega,@obsProducto)
go
select * from [TblOrdenes];

--Procedimiento almacenado para modificar 
if exists (select name from dbo.sysobjects where name = 'Sp_Upd_Orden')
drop procedure [Sp_Upd_Orden]
go

create procedure [dbo].[Sp_Upd_Orden](
@idOrden int,
@fechaEntrega date,
@obsProducto varchar(max))
as
update  TblOrdenes set
fechaEntrega= @fechaEntrega,
obsProducto = @obsProducto
where idOrden = @idOrden
go

---procedimiento para realizar una eliminación  
if exists (select name from dbo.sysobjects where name = 'Sp_Del_Orden')
drop procedure [Sp_Del_Orden]
go

create procedure [Sp_Del_Orden](
@idOrden int)
as
---delete 
delete from  TblOrdenes
where idOrden = @idOrden
go

--procedimiento almacenado para busqueda de clientes de ordenes
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_ClientesOrdenXId')
drop procedure [Sp_Cns_ClientesOrdenXId]
go

create procedure [Sp_Cns_ClientesOrdenXId](
@cedula varchar(100))
as
select c.cedula, c.nombre, c.email, c.telefono
from TblClientes c with(nolock)
where c.cedula like '%' + @cedula + '%'
order by c.cedula
go

--testing de procedimiento almacenado 
exec [Sp_Cns_ClientesOrdenXId] '1'
go

--****************************************************MaterialesOrden*****************************************************--

if exists(select name from dbo.sysobjects where name= 'TblMaterialesOrden')
drop table [TblMaterialesOrden]
go
-- Tabla de MaterialesOrden
create table [TblMaterialesOrden](
idOrden int not null,     
idMaterial int not null,  
cantidad int not null)
go

alter table [TblMaterialesOrden] add constraint PK_Llaves primary key (idOrden, idMaterial)--*** llaves primarias***--

insert  into [TblMaterialesOrden](idOrden,idMaterial,cantidad)
values(1,3,5)
go
insert  into [TblMaterialesOrden](idOrden,idMaterial,cantidad)
values(1,2,7)
go

select * from [TblMaterialesOrden]

--procedimiento para insercion de orden
if exists (select name from dbo.sysobjects where name = 'Sp_Ins_MaterialesOrden')
drop procedure [Sp_Ins_MaterialesOrden]
go

create procedure [Sp_Ins_MaterialesOrden](
@idOrden int,
@idMaterial int,
@cantidad int)
as
insert into TblMaterialesOrden(idOrden,idMaterial,cantidad)
values(@idOrden, @idMaterial,@cantidad)
go

select * from [TblMaterialesOrden];


--procedimiento almacenado para busqueda de materiales
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_MaterialesXId')
drop procedure [Sp_Cns_MaterialesXId]
go

create procedure [Sp_Cns_MaterialesXId](
@idMateriales varchar(100))
as
select m.idMaterial, m.nombre
from TblMateriales m with(nolock)
where m.idMaterial like '%' + @idMateriales + '%'
order by m.idMaterial
go

--testing de procedimiento almacenado 
exec [Sp_Cns_MaterialesXId] '1'
go

--procedimiento almacenado para busqueda de ordenes
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_IdOrdenXId')
drop procedure [Sp_Cns_IdOrdenXId]
go

create procedure [Sp_Cns_IdOrdenXId](
@idOrden varchar(100))
as
select o.idOrden, o.cedula, o.fechaRegistro, o.fechaEntrega, o.obsProducto 
from TblOrdenes o with(nolock)
where o.idOrden like '%' + @idOrden + '%'
order by o.idOrden
go

--testing de procedimiento almacenado 
exec [Sp_Cns_IdOrdenXId] '1'
go

--procedimiento almacenado para busqueda de materiales de ordenes
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_MaterialOrdenXId')
drop procedure [Sp_Cns_MaterialOrdenXId]
go

create procedure [Sp_Cns_MaterialOrdenXId](
@idOrden varchar(100))
as
select ma.nombre,  m.cantidad 
from TblMaterialesOrden as m 
join TblMateriales as ma
on  m.idMaterial = ma.idMaterial
where idOrden = @idOrden
go

--testing de procedimiento almacenado 
exec [Sp_Cns_MaterialOrdenXId] '1'
go

--****************************************************ManoObraOrden*****************************************************--

if exists(select name from dbo.sysobjects where name= 'TblManoObraOrden')
drop table [TblManoObraOrden]
go

-- Tabla de ManoObraOrden
create table [TblManoObraOrden](
idOrden int not null,       
idManoObra int not null,    
horas int not null)
go
alter table [TblManoObraOrden] add constraint PK_LlavesManoObraOrden primary key (idOrden, idManoObra)


insert  into [TblManoObraOrden](idOrden,idManoObra,horas)
values(1,1,5)
go
insert  into [TblManoObraOrden](idOrden,idManoObra,horas)
values(1,2,6)
go

select * from [TblManoObraOrden]

--procedimiento para insercion
if exists (select name from dbo.sysobjects where name = 'Sp_Ins_ManoObraOrden')
drop procedure [Sp_Ins_ManoObraOrden]
go

create procedure [Sp_Ins_ManoObraOrden](
@idOrden int,
@idManoObra int,
@horas int)
as
insert into TblManoObraOrden(idOrden,idManoObra, horas)
values(@idOrden, @idManoObra, @horas)
go

select * from [TblManoObraOrden];

--procedimiento almacenado para busqueda de mano de obra de ordenes
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_ManoDeObraOrdenXId')
drop procedure [Sp_Cns_ManoDeObraOrdenXId]
go

create procedure [Sp_Cns_ManoDeObraOrdenXId](
@idOrden varchar(100))
as
select ma.nombre, m.horas
from TblManoObraOrden as m 
join TblManodeObra as ma
on m.idManoObra = ma.id
where m.idOrden  = @idOrden 
go

--testing de procedimiento almacenado 
exec [Sp_Cns_ManoDeObraOrdenXId] '1'
go

--****************************************************GastosIndirectosOrden*****************************************************--

if exists(select name from dbo.sysobjects where name= 'TblGastosIndirectosOrden')
drop table [TblGastosIndirectosOrden]
go
                                              
-- Tabla GastoIndirecto
create table [TblGastosIndirectosOrden](
idOrden int  not null,
idGastoIndirecto int identity not null, 
motivo  varchar(max) not null,
cantidad int not  null,
fecha  date not null,
total decimal not null)
go
alter table [TblGastosIndirectosOrden] add constraint PK_LlavesGastosIndirectos primary key (idOrden, idGastoIndirecto)

insert  into [TblGastosIndirectosOrden](idOrden,motivo,cantidad,fecha, total)
values(1,'###',5,'01-01-2020',500000)
go
insert  into [TblGastosIndirectosOrden](idOrden,motivo,cantidad,fecha, total)
values(1,'#',10,'05-01-2020',700000)
go

select * from [TblGastosIndirectosOrden]

--procedimiento almacenado para busqueda 
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_GastosIndirectosXId')
drop procedure [Sp_Cns_GastosIndirectosXId]
go

create procedure [Sp_Cns_GastosIndirectosXId](
@idGastoIndirecto varchar(5))
as
select g.idGastoIndirecto, g.idOrden, g.motivo, g.cantidad ,g.fecha, g.total
from TblGastosIndirectosOrden g with(nolock)
where g.idGastoIndirecto = @idGastoIndirecto
go

--testing de procedimiento almacenado 
exec [Sp_Cns_GastosIndirectosXId] '1'
go

--procedimiento para insercion 
if exists (select name from dbo.sysobjects where name = 'Sp_Ins_GastoIndirecto')
drop procedure [Sp_Ins_GastoIndirecto]
go

create procedure [Sp_Ins_GastoIndirecto](
@idOrden int,
@motivo varchar(max),
@cantidad int,
@fecha date,
@total decimal)
as
insert into TblGastosIndirectosOrden(idOrden,motivo,cantidad,fecha, total)
values(@idOrden,@motivo,@cantidad,@fecha,@total)
go

select * from [TblGastosIndirectosOrden];

--Procedimiento almacenado para modificar 
if exists (select name from dbo.sysobjects where name = 'Sp_Upd_GastoIndireto')
drop procedure [Sp_Upd_GastoIndireto]
go

create procedure [dbo].[Sp_Upd_GastoIndireto](
@idOrden int,
@idGastoIndirecto int,
@motivo varchar (max),
@cantidad int,
@fecha date,
@total decimal)
as
update  TblGastosIndirectosOrden set
idOrden = @idOrden,
motivo = @motivo,
cantidad = @cantidad,
fecha = @fecha, 
total = @total
where idGastoIndirecto = @idGastoIndirecto
go

---procedimiento para realizar una eliminación  
if exists (select name from dbo.sysobjects where name = 'Sp_Del_GastoIndirecto')
drop procedure [Sp_Del_GastoIndirecto]
go

create procedure [Sp_Del_GastoIndirecto](
@idGastoIndirecto int)
as
delete from  TblGastosIndirectosOrden
where idGastoIndirecto = @idGastoIndirecto
go

--procedimiento almacenado para busqueda de costos de ordenes
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_CostoOrdenXId')
drop procedure [Sp_Cns_CostoOrdenXId]
go

create procedure [Sp_Cns_CostoOrdenXId](
@idOrden varchar(100))
as
select g.motivo, g.cantidad
from TblGastosIndirectosOrden g with(nolock)
where g.idOrden  = @idOrden 
go
--testing de procedimiento almacenado 
exec [Sp_Cns_CostoOrdenXId] '1'
go

--procedimiento almacenado para busqueda de costosIndirectos
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_CostosXId')
drop procedure [Sp_Cns_CostosXId]
go

create procedure [Sp_Cns_CostosXId](
@idGastoIndirecto varchar(100))
as
select g.idOrden, g.idGastoIndirecto, g.cantidad, g.fecha, g.total
from TblGastosIndirectosOrden g with(nolock)
where g.idGastoIndirecto like '%' + @idGastoIndirecto + '%'
order by g.idGastoIndirecto
go

--testing de procedimiento almacenado 
exec [Sp_Cns_CostosXId] '2'
go

--****************************************************HojaDeCostos*****************************************************--
if exists (select name from dbo.sysobjects where name = 'Sp_Cns_MaterialesDeOrden')
drop procedure [Sp_Cns_MaterialesDeOrden]
go
create procedure [Sp_Cns_MaterialesDeOrden](
@idOrden varchar(100))
as
select g.precio, h.cantidad
from TblMateriales g, TblMaterialesOrden h with(nolock)
where h.idOrden  = @idOrden and g.idMaterial = h.idMaterial
go

create procedure [Sp_Cns_ManoDeObra](
@idOrden varchar(100))
as
select g.jornada, h.horas
from TblManodeObra g, TblManoObraOrden h with(nolock)
where h.idOrden  = @idOrden and g.id = h.idManoObra
go

create procedure [Sp_Cns_CostosIndirectos](
@idOrden varchar(100))
as
select g.cantidad, g.total
from TblGastosIndirectosOrden g with(nolock)
where g.idOrden  = @idOrden
go


select * from TblGastosIndirectosOrden

select * from TblMaterialesOrden