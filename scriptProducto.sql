USE master
go

CREATE DATABASE Productos
go

USE Productos
go

create table PRODUCTO(
    IdProducto int primary key identity,
    CodigoBarra varchar(10),
    Descripcion varchar(50),
    Precio Decimal(10,2),
    Cantidad int
)

insert into PRODUCTO(CodigoBarra,Descripcion,Precio,Cantidad) values
('PRD00001','Globos 12 pokas',3.5, 5),
('PRD00002','Sticker Mickey',2.7, 30),
('PRD00003','Movil de Ben 10',14.2, 44),
('PRD00004','Plato de Spiderman',20.40, 88);


CREATE PROCEDURE SP_GET_DATA_PRODUCT
AS 
BEGIN
	SELECT 
		prd.IdProducto,
		prd.CodigoBarra,
		prd.Descripcion,
		prd.Precio,
		prd.Cantidad
	FROM
		PRODUCTO prd
END

CREATE PROCEDURE SP_SEARCH_DATA_PRODUCT(
	@inpNumPro INT,
	@inpNombre VARCHAR(50)
)
AS 
BEGIN
	SELECT 
		prd.IdProducto,
		prd.CodigoBarra,
		prd.Descripcion,
		prd.Precio,
		prd.Cantidad
	FROM
		PRODUCTO prd
	WHERE
		prd.IdProducto = @inpNumPro
	AND
		prd.Descripcion LIKE '%' + @inpNombre + '%';
END

CREATE PROCEDURE SP_UPDATE_DATA_PRODUCT(
	@IdProducto int,
	@Descripcion VARCHAR(50),
	@Precio Decimal(10,2),
	@Cantidad int
)
AS 
BEGIN
	UPDATE 
		PRODUCTO
	SET
		Descripcion = @Descripcion,
		Precio = @Precio,
		Cantidad = @Cantidad
	WHERE
		IdProducto = @IdProducto;
END

CREATE PROCEDURE SP_DELETE_PRODUCT(
	@IdProducto int
)
AS 
BEGIN
	DELETE FROM
		PRODUCTO
	WHERE
		IdProducto = @IdProducto;
END


CREATE PROCEDURE SP_ADD_DATA_PRODUCT(
	@Codigo varchar(10),
	@Descripcion VARCHAR(50),
	@Precio Decimal(10,2),
	@Cantidad int
)
AS 
BEGIN
	INSERT INTO PRODUCTO 
		(CodigoBarra, Descripcion, Precio, Cantidad) 
	VALUES 
		(@Codigo, @Descripcion, @Precio, @Cantidad);
END