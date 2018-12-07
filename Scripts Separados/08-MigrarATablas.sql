--- INSERTS ---

--MIGRACION DE EMPRESAS--

IF (SELECT COUNT(*) FROM [SQLITO].[Empresas]) = 0
BEGIN

	INSERT INTO [SQLITO].[Empresas] (razonsocial, fecha_creacion, cuit, mail, direccion)
		SELECT DISTINCT Espec_Empresa_Razon_Social,
       	   				Espec_Empresa_Fecha_Creacion,
	       				Espec_Empresa_Cuit,
		  				Espec_Empresa_Mail,
		   				SQLITO.obtenerDireccion(Espec_Empresa_Dom_Calle, Espec_Empresa_Nro_Calle, Espec_Empresa_Piso,
		   										Espec_Empresa_Depto, '', Espec_Empresa_Cod_Postal)
		FROM gd_esquema.Maestra

END
GO

DECLARE @var NVARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.Empresas)
PRINT('Datos existentes migrados a la tabla SQLITO.Empresas. Nuevas Filas: ' + @var)


--MIGRACION DE CLIENTES--

IF (SELECT COUNT(*) FROM [SQLITO].[Clientes]) = 0
BEGIN

	INSERT INTO [SQLITO].[Clientes] (nombre, apellido, tipo_documento, numero_documento, fecha_nacimiento, mail, direccion)
		SELECT Cli_Nombre,
		   	   Cli_Apeliido,
		   	   --Todos los de la tabla maestra tienen DNI (el campo se llama asi); ya lo seteamos
		       'DNI' AS TipoDocumento,
		       Cli_Dni,
		       Cli_Fecha_Nac,
			   Cli_Mail,
			   SQLITO.obtenerDireccion(Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, '', Cli_Cod_Postal)
		FROM gd_esquema.Maestra
		WHERE Cli_Dni IS NOT NULL
		GROUP BY Cli_Nombre, Cli_Apeliido, Cli_Dni, Cli_Fecha_Nac, Cli_Mail, Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal

END
GO

DECLARE @var NVARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.Clientes)
PRINT('Datos existentes migrados a la tabla SQLITO.Clientes. Nuevas Filas: ' + @var)


--MIGRACION DE PUBLICACIONES--

--Con esto puedo insertar valores que yo quiera en una PK que es IDENTITY
SET IDENTITY_INSERT [SQLITO].[Publicaciones] ON

IF (SELECT COUNT(*) FROM [SQLITO].[Publicaciones]) = 0
BEGIN

	INSERT INTO [SQLITO].[Publicaciones] (cod_publicacion, descripcion, fecha_vencimiento, fecha_funcion, empresa_id, rubro_id, estado_id)
		SELECT DISTINCT Espectaculo_Cod,
		   	   			Espectaculo_Descripcion,
		       			Espectaculo_Fecha_Venc,
		       			Espectaculo_Fecha,
		       			(SELECT id_empresa
		       			 FROM [SQLITO].[Empresas]
		       			 WHERE (razonsocial = Espec_Empresa_Razon_Social)),
		       			--Ninguna tiene Rubro, con lo cual le asignamos el rubro 'Otros', de id = 7
		       			7,
		       			--Todas estan en estado 'Publicada', con lo cual le asignamos el id = 2
		       			2
		FROM gd_esquema.Maestra

END
GO

--Deshabilito esto asi de ahora en mas todo lo que se agregue tiene IDENTITY autogenerada; sigue en el ultimo
SET IDENTITY_INSERT [SQLITO].[Publicaciones] OFF

DECLARE @var NVARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.Publicaciones)
PRINT('Datos existentes migrados a la tabla SQLITO.Publicaciones. Nuevas Filas: ' + @var)


--MIGRACION DE UBICACIONES--

--Reseteo el contador de IDENTITY, por algun motivo se dispara
DBCC CHECKIDENT ('[SQLITO].[Ubicaciones]', RESEED, 1)

IF (SELECT COUNT(*) FROM [SQLITO].[Ubicaciones]) = 0
BEGIN

	INSERT INTO [SQLITO].[Ubicaciones] (fila, asiento, precio, tipo_id, publicacion_id)
		SELECT Ubicacion_Fila,
		   	   Ubicacion_Asiento,
		   	   Ubicacion_Precio,
		   	   Ubicacion_Tipo_Codigo,
		   	   Espectaculo_Cod
		FROM gd_esquema.Maestra
		GROUP BY Ubicacion_Fila, Ubicacion_Asiento, Ubicacion_Precio, Ubicacion_Tipo_Codigo, Espectaculo_Cod
		
END
GO

DECLARE @var NVARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.Ubicaciones)
PRINT('Datos existentes migrados a la tabla SQLITO.Ubicaciones. Nuevas filas: ' + @var)


-- MIGRACION DE COMPRAS --

IF (SELECT COUNT(*) FROM [SQLITO].[Compras]) = 0
BEGIN

	INSERT INTO SQLITO.Compras (cliente_id, ubicacion_id, fecha_realizacion, valor_entrada)
		SELECT c.id_cliente,
			   sq2.id_ubicacion,
			   Compra_Fecha,
			   Ubicacion_Precio
		FROM gd_esquema.Maestra sq
			JOIN SQLITO.Clientes c ON (c.numero_documento = sq.Cli_Dni)
			JOIN (SELECT DISTINCT id_ubicacion,
						 asiento,
						 fila,
						 publicacion_id
				  FROM SQLITO.Ubicaciones) sq2 ON (sq2.asiento = sq.Ubicacion_Asiento)
												AND (sq2.fila = sq.Ubicacion_Fila)
												AND (sq2.publicacion_id = sq.Espectaculo_Cod)
		WHERE Compra_Fecha IS NOT NULL
			AND Factura_Nro IS NULL 

END
GO

DECLARE @var NVARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.Compras)
PRINT('Datos existentes migrados a la tabla SQLITO.Compras. Nuevas Filas: ' + @var)


-- MIGRACION DE FACTURAS -- 

IF (SELECT COUNT(*) FROM [SQLITO].[Facturas]) = 0
BEGIN

	INSERT INTO SQLITO.Facturas (numero_factura, fecha_emision, total, empresa_id, medio_pago)
		SELECT DISTINCT Factura_Nro,
			   Factura_Fecha,
			   Factura_Total,
			   e.id_empresa,
			   Forma_Pago_Desc
		FROM gd_esquema.Maestra gdm
			JOIN SQLITO.Empresas e ON (gdm.Espec_Empresa_Cuit = e.cuit)
		WHERE Factura_Nro IS NOT NULL

END
GO

DECLARE @var NVARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.Facturas)
PRINT('Datos existentes migrados a la tabla SQLITO.Facturas. Nuevas Filas: ' + @var)


-- MIGRACION DE ITEMS --

IF (SELECT COUNT(*) FROM [SQLITO].[ItemsFactura]) = 0
BEGIN

	INSERT INTO SQLITO.ItemsFactura (factura_id, comision, compra_id, descripcion)
		SELECT DISTINCT Factura_Nro,
						Item_Factura_Monto,
						c.id_compra,
						Item_Factura_Descripcion
		FROM gd_esquema.Maestra gdm
			JOIN SQLITO.Ubicaciones u ON (u.asiento = gdm.Ubicacion_Asiento)
				AND (u.fila = gdm.Ubicacion_Fila)
			JOIN SQLITO.Compras c ON (c.ubicacion_id = u.id_ubicacion)
		WHERE (gdm.Espectaculo_Cod = u.publicacion_id)
			AND Factura_Nro IS NOT NULL

END
GO

DECLARE @var VARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.ItemsFactura)
PRINT('Datos existentes migrados a la tabla SQLITO.ItemsFactura. Nuevas Filas: ' + @var)


-- USUARIOS --

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'crearUsuario_cliente')
BEGIN

	DROP PROCEDURE crearUsuario_cliente

END
GO

--Usuarios para Clientes migrados
CREATE PROCEDURE crearUsuario_cliente
AS
BEGIN

	DECLARE @username NVARCHAR(255), @password NVARCHAR(255), @clienteID INT

	DECLARE adduser_cursor CURSOR FOR SELECT id_cliente,
											 LOWER(nombre) + LOWER(apellido),
											 HASHBYTES('SHA2_256',CRYPT_GEN_RANDOM(8))
									  FROM SQLITO.Clientes

	OPEN adduser_cursor
	FETCH NEXT FROM adduser_cursor INTO @clienteID, @username, @password

	WHILE @@FETCH_STATUS = 0
	BEGIN

		IF (SELECT COUNT(username)
		    FROM SQLITO.Usuarios
		    WHERE username = @username) = 0
		BEGIN
			INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
			VALUES (@username, @password, 0)
		END

		ELSE 
		BEGIN
			INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
			VALUES (@username + '2', @password, 0)
		END

		--Al Cliente cuyo usuario recien cree, le guardo el ID de dicho usuario
		UPDATE SQLITO.Clientes
			SET usuario_id = SCOPE_IDENTITY()
			WHERE id_cliente = @clienteID

		--Le asigno al usuario creado el rol de Cliente
		INSERT INTO SQLITO.Roles_Usuarios (rol_id, usuario_id)
		VALUES(3, SCOPE_IDENTITY())

		FETCH NEXT FROM adduser_cursor INTO @clienteID, @username, @password

	END

	CLOSE adduser_cursor
	DEALLOCATE adduser_cursor

END
GO

--Usuarios para Empresas migradas

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'crearUsuario_empresa')
BEGIN

	DROP PROCEDURE crearUsuario_empresa

END
GO

CREATE PROCEDURE crearUsuario_empresa
AS
BEGIN

	DECLARE @username NVARCHAR(255), @password NVARCHAR(255), @empresaID INT

	DECLARE addus3r_cursor CURSOR FOR SELECT id_empresa,
											 LOWER(SUBSTRING(razonsocial,1,5)) + LOWER(SUBSTRING(razonsocial,7,6)) + SUBSTRING(razonsocial,17,2), 
											 HASHBYTES('SHA2_256',CRYPT_GEN_RANDOM(8))
									  FROM SQLITO.Empresas
	
	OPEN addus3r_cursor
	FETCH NEXT FROM addus3r_cursor INTO @empresaID, @username, @password
	
	WHILE @@FETCH_STATUS = 0
	BEGIN

		INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
		VALUES (@username, @password, 0)

		--A la Empresa cuyo usuario recien cree, le guardo el ID de dicho usuario
		UPDATE SQLITO.Empresas
			SET usuario_id = SCOPE_IDENTITY()
			WHERE id_empresa = @empresaID

		--Le asigno al usuario creado el rol de Empresa
		INSERT INTO SQLITO.Roles_Usuarios (rol_id, usuario_id)
		VALUES (1,SCOPE_IDENTITY())

		FETCH NEXT FROM addus3r_cursor INTO @empresaID, @username, @password

	END

	CLOSE addus3r_cursor
	DEALLOCATE addus3r_cursor

END
GO

EXEC crearUsuario_cliente
PRINT ('Usuarios creados para clientes existentes')
EXEC crearUsuario_empresa
PRINT ('Usuarios creados para empresas existentes')

-- ADMINISTRADOR GENERAL DEL SISTEMA --

IF (SELECT COUNT(*) FROM SQLITO.Usuarios WHERE username = 'admin') = 0
BEGIN
	
	INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada) 
	VALUES ('admin', HASHBYTES('SHA2_256','w23e'), 0)

	DECLARE @adminUser INT
	SET @adminUser = (SELECT id_usuario
					  FROM SQLITO.Usuarios
					  WHERE username = 'admin')

	INSERT INTO SQLITO.Roles_Usuarios
	VALUES(4, @adminUser)

	--Lo designo como responsable de todos los premios; VER ESTO
	UPDATE SQLITO.Premios
	SET admin_responsable_id = @adminUser

END
GO

PRINT ('Agregado Administrador General del Sistema')

PRINT ('Script de Migracion Finalizado')

--------------ALTERNATIVA PARA COMPRAS--------------------

CREATE TABLE [SQLITO].[#Temp_UbicacionesMaestra] (
	
	[ubicacion_id] INT PRIMARY KEY ,
	[ubicacion_fila] NVARCHAR(3),
	[ubicacion_asiento] NUMERIC(6,0),
	[publicacion_id] INT

)

INSERT INTO [SQLITO].[#Temp_UbicacionesMaestra] (ubicacion_id, ubicacion_fila, ubicacion_asiento, publicacion_id)
	SELECT DISTINCT id_ubicacion,
					fila,
					asiento,
					publicacion_id
	FROM SQLITO.Ubicaciones

SELECT *
FROM #Temp_UbicacionesMaestra

SELECT c.id_cliente,
			   t.ubicacion_id,
			   Compra_Fecha,
			   Ubicacion_Precio
		FROM gd_esquema.Maestra sq
			JOIN SQLITO.Clientes c ON (c.numero_documento = sq.Cli_Dni)
			JOIN #Temp_UbicacionesMaestra t ON (t.ubicacion_asiento = sq.Ubicacion_Asiento)
												AND (t.ubicacion_fila = sq.Ubicacion_Fila)
												AND (t.publicacion_id = sq.Espectaculo_Cod)
		WHERE Compra_Fecha IS NOT NULL
			AND Factura_Nro IS NULL 

DROP TABLE #Temp_UbicacionesMaestra