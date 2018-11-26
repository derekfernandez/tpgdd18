USE [GD2C2018]
GO

--- CREACION DE ESQUEMA ---


IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'SQLITO')
BEGIN
	
	EXEC('CREATE SCHEMA [SQLITO] AUTHORIZATION [gdEspectaculos2018]')
	PRINT 'Esquema Creado'
END
GO

--- BORRADO DE CONSTRAINTS ---

DECLARE @delete_var NVARCHAR(255) = ''
SELECT @delete_var = @delete_var + 'ALTER TABLE ' + QUOTENAME('SQLITO') + '.' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + 
	QUOTENAME(fk.name) + '; ' + CHAR(13)
FROM sys.tables t
JOIN sys.foreign_keys fk ON t.object_id = fk.parent_object_id
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE s.name = 'SQLITO'
ORDER BY t.name
EXEC (@delete_var)
PRINT('Borrado de FKs finalizado')
 
--- BORRADO DE TABLAS ---

IF OBJECT_ID('SQLITO.Funcionalidades_Roles') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Funcionalidades_Roles]
	PRINT('Tabla SQLITO.FuncionalidadesRoles eliminada')
END

IF OBJECT_ID('SQLITO.Roles_Usuarios') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Roles_Usuarios]
	PRINT('Tabla SQLITO.RolesUsuarios eliminada')
END

IF OBJECT_ID('SQLITO.Puntos') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Puntos]
	PRINT('Tabla SQLITO.Puntos eliminada')
END

IF OBJECT_ID('SQLITO.Premios') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Premios]
	PRINT('Tabla SQLITO.Premios eliminada')
END

IF OBJECT_ID('SQLITO.ItemsFactura') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[ItemsFactura]
	PRINT('Tabla SQLITO.ItemsFactura eliminada')
END

IF OBJECT_ID('SQLITO.Funcionalidades') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Funcionalidades]
	PRINT('Tabla SQLITO.Funcionalidades eliminada')
END

IF OBJECT_ID('SQLITO.Roles') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Roles]
	PRINT('Tabla SQLITO.Roles eliminada')
END

IF OBJECT_ID('SQLITO.Compras') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Compras]
	PRINT('Tabla SQLITO.Compras eliminada')
END

IF OBJECT_ID('SQLITO.Clientes') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Clientes]
	PRINT('Tabla SQLITO.Clientes eliminada')
END

IF OBJECT_ID('SQLITO.Tarjetas') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Tarjetas]
	PRINT('Tabla SQLITO.Tarjetas eliminada')
END

IF OBJECT_ID('SQLITO.Facturas') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Facturas]
	PRINT('Tabla SQLITO.Facturas eliminada')
END

IF OBJECT_ID('SQLITO.Ubicaciones') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Ubicaciones]
	PRINT('Tabla SQLITO.Ubicaciones eliminada')
END

IF OBJECT_ID('SQLITO.TiposUbicacion') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[TiposUbicacion]
	PRINT('Tabla SQLITO.TiposUbicacion eliminada')
END

IF OBJECT_ID('SQLITO.Publicaciones') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Publicaciones]
	PRINT('Tabla SQLITO.Publicaciones eliminada')
END

IF OBJECT_ID('SQLITO.Grados') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Grados]
	PRINT('Tabla SQLITO.Grados eliminada')
END

IF OBJECT_ID('SQLITO.Rubros') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Rubros]
	PRINT('Tabla SQLITO.Rubros eliminada')
END

IF OBJECT_ID('SQLITO.EstadosPublicacion') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[EstadosPublicacion]
	PRINT('Tabla SQLITO.EstadosPublicacion eliminada')
END

IF OBJECT_ID('SQLITO.Empresas') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Empresas]
	PRINT('Tabla SQLITO.Empresas eliminada')
END

IF OBJECT_ID('SQLITO.Usuarios') IS NOT NULL
BEGIN
	DROP TABLE [SQLITO].[Usuarios]
	PRINT('Tabla SQLITO.Usuarios eliminada')
END



--- CREACION DE TABLAS ---

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Funcionalidades_Roles'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Funcionalidades_Roles] (
		
		[funcionalidad_id] [int] NOT NULL,
		[rol_id] [int] NOT NULL,
		PRIMARY KEY ([funcionalidad_id],[rol_id])
	)

PRINT('Tabla SQLITO.Funcionalidades_Roles creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Roles_Usuarios'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Roles_Usuarios] (

		[rol_id] [int] NOT NULL,
		[usuario_id] [int] NOT NULL,
		PRIMARY KEY([rol_id],[usuario_id])
	)

PRINT('Tabla SQLITO.Roles_Usuarios creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Puntos'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Puntos] (

		[id_puntos] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[cantidad] [bigint]	NOT NULL,
		[cliente_id] [int] NOT NULL,
		--Si es NULL, no tienen vencimiento (?)
		[fecha_vencimiento] [smalldatetime]
	)

PRINT('Tabla SQLITO.Puntos creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Premios'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Premios] (

		[id_premio] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [varchar] (100),
		[puntos_requeridos] [smallint] NOT NULL,
		[cantidad_stock] [smallint] NOT NULL
	)

PRINT('Tabla SQLITO.Premios creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ItemsFactura'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[ItemsFactura] (

		[id_item] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[factura_id] [int],
		[cantidad] [int],
		[comision] [numeric] (6,2) NOT NULL,
		[compra_id] [int],
		[descripcion] [nvarchar] (255)
		--Habria que ver que hacer con Item_Factura_Descripcion, creo que serian todos iguales
		--Agregamos un campo mas o lo dejamos implicito? Despues de todo, las facturas son por comisiones
	)

PRINT('Tabla SQLITO.ItemsFactura creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Funcionalidades'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Funcionalidades] (
		
		[id_funcionalidad] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar](100) NOT NULL
	)

PRINT('Tabla SQLITO.Funcionalidades creada')

END
GO


IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Roles'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Roles] (

		[id_rol] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar](100) NOT NULL
	)

PRINT('Tabla SQLITO.Roles creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Compras'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Compras] (
		
		[id_compra] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[cliente_id] [int],
		[ubicacion_id] [int],
		[fecha_realizacion] [datetime] NOT NULL,
		[valor_entrada] [numeric] (18,2) NOT NULL,
		[tarjeta_id] [int],
		[cantidad_entradas] [int] NOT NULL,
		--Puntos que otorgo la compra al cliente; NULL = 0
		[cantidad_puntos] [bigint]
	)

PRINT('Tabla SQLITO.Compras creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clientes'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Clientes] (

		[id_cliente] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[nombre] [nvarchar](255) NOT NULL,
		[apellido] [nvarchar](255) NOT NULL,
		[cuil] [nvarchar] (255) CHECK ([cuil] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]%'),
		[tipo_documento] [nvarchar] (3) CHECK ([tipo_documento] IN ('DNI','LC','LE','CI')),
		[numero_documento] [numeric] (8,0) CHECK (LEN([numero_documento]) <= 8),
		[fecha_nacimiento] [datetime] NOT NULL,
		--Puede ser NULL, los Clientes de la tabla maestra no tienen este campo
		[fecha_creacion] [datetime],
		--Puede ser NULL si un Cliente no tiene tarjetas registradas a su nombre
		[mail] [nvarchar] (50),
		[direccion] [nvarchar] (255),
		[telefono] [nvarchar] (30),
		[tarjeta_id] [int],
		--Id del usuario al cual esta asociada la cuenta del Cliente
		[usuario_id] [int],
		[estado] [bit] DEFAULT 1
	)

PRINT('Tabla SQLITO.Clientes creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tarjetas'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Tarjetas] (
		
		[id_tarjeta] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		--El banco puede no estar especificado
		[nombre_banco] [nvarchar](50),
		[numero_tarjeta] [numeric](18,0) NOT NULL,
		--No deberia poder ser NULL, seria fundamental tenerla para verificar los pagos
		[cvv] [int] CHECK(LEN([cvv]) = 3) NOT NULL
	)

PRINT('Tabla SQLITO.Tarjetas creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Facturas'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Facturas] (

		[numero_factura] [int] PRIMARY KEY NOT NULL,
		[fecha_emision] [datetime] NOT NULL,
		[total] [numeric] (18,2) NOT NULL,
		[empresa_id] [int],
		[medio_pago] [nvarchar] (30)
	)

PRINT('Tabla SQLITO.Facturas creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Ubicaciones'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Ubicaciones] (
		
		[id_ubicacion] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[fila] [nvarchar](3),
		[asiento] [numeric] (6,0),
		[tipo_id] [int],
		[precio] [numeric] (18,2) NOT NULL,
		[publicacion_id] [int]
	)

PRINT('Tabla SQLITO.Ubicaciones creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposUbicacion'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[TiposUbicacion] (

		[id_tipo] [int] PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255) CHECK([descripcion] IN ('Platea Alta', 'Platea Baja', 'Vip', 'Campo',
			'Campo Vip', 'PullMan', 'Super PullMan', 'Cabecera', 'S/N')),
		CHECK ([id_tipo] BETWEEN 4446 AND 4454)
	)

PRINT('Tabla SQLITO.TiposUbicacion creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Publicaciones'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Publicaciones] (
		
		/* El enunciado dice que tiene que ser autonumerico y consecutivo pero la tabla maestra
		* tiene codigos cargados. Si pongo identity no va a hacer los inserts. Habria que ver como hacer
		*/
		[cod_publicacion] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255) NOT NULL,
		[fecha_creacion] [datetime],
		[fecha_vencimiento] [datetime] NOT NULL,
		[fecha_funcion] [datetime] NOT NULL,
		--En la tabla maestra ninguno tiene direccion
		[direccion] [nvarchar](100),
		[empresa_id] [int],
		[grado_id] [int],
		[rubro_id] [int],
		[estado_id] [int],
		CHECK (([fecha_vencimiento] > [fecha_creacion]) 
			AND ([fecha_funcion] > [fecha_creacion])
			AND ([fecha_vencimiento] <= [fecha_funcion]))
	)

PRINT('Tabla SQLITO.Publicaciones creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Grados'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Grados] (

		[id_grado] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255),
		[comision] [numeric] (6,2) NOT NULL,
		CHECK ([descripcion] IN ('Alta', 'Media', 'Baja'))
	)

PRINT('Tabla SQLITO.Grados creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Rubros'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Rubros] (

		[id_rubro] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255)
	)

PRINT('Tabla SQLITO.Rubros creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EstadosPublicacion'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[EstadosPublicacion] (
		
		[id_estado] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255) CHECK ([descripcion] IN ('Borrador','Publicada','Finalizada','Pausada'))
	)

PRINT('Tabla SQLITO.EstadosPublicacion creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empresas'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Empresas] (
		
		[id_empresa] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[razonsocial] [nvarchar](255),
		[fecha_creacion] [datetime],
		[cuit] [nvarchar] (255) CHECK ([cuit] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]%'),
		[mail] [nvarchar] (50),
		[direccion] [nvarchar] (255),
		[telefono] [nvarchar] (30),
		--Id del usuario al cual esta asociada la cuenta de la Empresa
		[usuario_id] [int]
	)

PRINT('Tabla SQLITO.Empresas creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Usuarios] (
		
		[id_usuario] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[username] [nvarchar](255),
		[password] [nvarchar](255),
		[intentos_fallidos] [int] DEFAULT 0,
		--1 es habilitado, 0 es inhabilitado
		[habilitado] [bit] DEFAULT 1,
		--Para mi, no deberiamos darle un valor default, que cada tipo de alta lo setee
		[contraseniaActivada] [bit]
	)

PRINT('Tabla SQLITO.Usuarios creada')

END
GO



--- CREACION DE FOREIGN KEYS ---



IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_FuncionalidadesRoles_Funcionalidades')

	BEGIN

		ALTER TABLE [SQLITO].[Funcionalidades_Roles]
		ADD CONSTRAINT FK_FuncionalidadesRoles_Funcionalidades
		FOREIGN KEY (funcionalidad_id) REFERENCES [SQLITO].[Funcionalidades](id_funcionalidad)
		PRINT('Foreign Key entre Funcionalidades_Roles y Funcionalidades agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_FuncionalidadesRoles_Roles')

	BEGIN

		ALTER TABLE [SQLITO].[Funcionalidades_Roles]
		ADD CONSTRAINT FK_FuncionalidadesRoles_Roles
		FOREIGN KEY (rol_id) REFERENCES [SQLITO].[Roles](id_rol)
		PRINT('Foreign Key entre Funcionalidades_Roles y Roles agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_RolesUsuarios_Roles')

	BEGIN

		ALTER TABLE [SQLITO].[Roles_Usuarios]
		ADD CONSTRAINT FK_RolesUsuarios_Roles
		FOREIGN KEY (rol_id) REFERENCES [SQLITO].[Roles](id_rol)
		PRINT('Foreign Key entre Roles_Usuarios y Roles agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_RolesUsuarios_Usuarios')

	BEGIN

		ALTER TABLE [SQLITO].[Roles_Usuarios]
		ADD CONSTRAINT FK_RolesUsuarios_Usuarios
		FOREIGN KEY (usuario_id) REFERENCES [SQLITO].[Usuarios](id_usuario)
		PRINT('Foreign Key entre Roles_Usuarios y Usuarios agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Clientes_Usuarios')

	BEGIN

		ALTER TABLE [SQLITO].[Clientes]
		ADD CONSTRAINT FK_Clientes_Usuarios
		FOREIGN KEY (usuario_id) REFERENCES [SQLITO].[Usuarios](id_usuario)
		PRINT('Foreign Key entre Clientes y Usuarios agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Empresas_Usuarios')

	BEGIN

		ALTER TABLE [SQLITO].[Empresas]
		ADD CONSTRAINT FK_Empresas_Usuarios
		FOREIGN KEY (usuario_id) REFERENCES [SQLITO].[Usuarios](id_usuario)
		PRINT('Foreign Key entre Empresas y Usuarios agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Puntos_Clientes')

	BEGIN

		ALTER TABLE [SQLITO].[Puntos]
		ADD CONSTRAINT FK_Puntos_Clientes
		FOREIGN KEY (cliente_id) REFERENCES [SQLITO].[Clientes](id_cliente)
		PRINT('Foreign Key entre Puntos y Clientes agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Clientes_Tarjetas')

	BEGIN

		ALTER TABLE [SQLITO].[Clientes]
		ADD CONSTRAINT FK_Clientes_Tarjetas
		FOREIGN KEY (tarjeta_id) REFERENCES [SQLITO].[Tarjetas](id_tarjeta)
		PRINT('Foreign Key entre Clientes y Tarjetas agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Compras_Clientes')

	BEGIN

		ALTER TABLE [SQLITO].[Compras]
		ADD CONSTRAINT FK_Compras_Clientes
		FOREIGN KEY (cliente_id) REFERENCES [SQLITO].[Clientes](id_cliente)
		PRINT('Foreign Key entre Compras y Clientes agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Compras_Tarjetas')

	BEGIN

		ALTER TABLE [SQLITO].[Compras]
		ADD CONSTRAINT FK_Compras_Tarjetas
		FOREIGN KEY (tarjeta_id) REFERENCES [SQLITO].[Tarjetas](id_tarjeta)
		PRINT('Foreign Key entre Compras y Tarjetas agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_ItemsFactura_Compras')

	BEGIN

		ALTER TABLE [SQLITO].[ItemsFactura]
		ADD CONSTRAINT FK_ItemsFactura_Compras
		FOREIGN KEY (compra_id) REFERENCES [SQLITO].[Compras](id_compra)
		PRINT('Foreign Key entre ItemsFactura y Compras agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_ItemsFactura_Facturas')

	BEGIN

		ALTER TABLE [SQLITO].[ItemsFactura]
		ADD CONSTRAINT FK_ItemsFactura_Facturas
		FOREIGN KEY (factura_id) REFERENCES [SQLITO].[Facturas](numero_factura)
		PRINT('Foreign Key entre ItemsFactura y Facturas agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Facturas_Empresas')

	BEGIN

		ALTER TABLE [SQLITO].[Facturas]
		ADD CONSTRAINT FK_Facturas_Empresas
		FOREIGN KEY (empresa_id) REFERENCES [SQLITO].[Empresas](id_empresa)
		PRINT('Foreign Key entre Facturas y Empresas agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Publicaciones_Empresas')

	BEGIN

		ALTER TABLE [SQLITO].[Publicaciones]
		ADD CONSTRAINT FK_Publicaciones_Empresas
		FOREIGN KEY (empresa_id) REFERENCES [SQLITO].[Empresas](id_empresa)
		PRINT('Foreign Key entre Publicaciones y Empresas agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Publicaciones_Grados')

	BEGIN

		ALTER TABLE [SQLITO].[Publicaciones]
		ADD CONSTRAINT FK_Publicaciones_Grados
		FOREIGN KEY (grado_id) REFERENCES [SQLITO].[Grados](id_grado)
		PRINT('Foreign Key entre Publicaciones y Grados agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Publicaciones_Rubros')

	BEGIN

		ALTER TABLE [SQLITO].[Publicaciones]
		ADD CONSTRAINT FK_Publicaciones_Rubros
		FOREIGN KEY (rubro_id) REFERENCES [SQLITO].[Rubros](id_rubro)
		PRINT('Foreign Key entre Publicaciones y Rubros agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Publicaciones_EstadosPublicacion')

	BEGIN

		ALTER TABLE [SQLITO].[Publicaciones]
		ADD CONSTRAINT FK_Publicaciones_EstadosPublicacion
		FOREIGN KEY (estado_id) REFERENCES [SQLITO].[EstadosPublicacion](id_estado)
		PRINT('Foreign Key entre Publicaciones y EstadosPublicacion agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Ubicaciones_Publicaciones')

	BEGIN

		ALTER TABLE [SQLITO].[Ubicaciones]
		ADD CONSTRAINT FK_Ubicaciones_Publicaciones
		FOREIGN KEY (publicacion_id) REFERENCES [SQLITO].[Publicaciones](cod_publicacion)
		PRINT('Foreign Key entre Ubicaciones y Publicaciones agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Ubicaciones_TiposUbicacion')

	BEGIN

		ALTER TABLE [SQLITO].[Ubicaciones]
		ADD CONSTRAINT FK_Ubicaciones_TiposUbicacion
		FOREIGN KEY (tipo_id) REFERENCES [SQLITO].[TiposUbicacion](id_tipo)
		PRINT('Foreign Key entre Ubicaciones y TiposUbicacion agregada')

	END

GO

IF NOT EXISTS (SELECT * 
    		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
               WHERE CONSTRAINT_NAME ='FK_Compras_Ubicaciones')

	BEGIN

		ALTER TABLE [SQLITO].[Compras]
		ADD CONSTRAINT FK_Compras_Ubicaciones
		FOREIGN KEY (ubicacion_id) REFERENCES [SQLITO].[Ubicaciones](id_ubicacion)
		PRINT('Foreign Key entre Compras y Ubicaciones agregada')

	END

GO

--- COMPLETADO DE TABLAS ACOTADAS ---

--TIPOS DE UBICACION --

IF (SELECT COUNT(*) FROM [SQLITO].[TiposUbicacion]) = 0
BEGIN

	INSERT INTO [SQLITO].[TiposUbicacion] (id_tipo,descripcion)
		
		SELECT DISTINCT Ubicacion_Tipo_Codigo, Ubicacion_Tipo_Descripcion
		FROM gd_esquema.Maestra
		ORDER BY Ubicacion_Tipo_Codigo

	INSERT INTO [SQLITO].[TiposUbicacion] (id_tipo,descripcion)
		VALUES (4454, 'S/N')

PRINT('Datos insertados en la tabla SQLITO.TiposUbicacion')
END
GO

-- ESTADOS DE PUBLICACION --

IF (SELECT COUNT(*) FROM [SQLITO].[EstadosPublicacion]) = 0
BEGIN

	INSERT INTO [SQLITO].[EstadosPublicacion] (descripcion)
		VALUES ('Borrador'),
		  	   ('Publicada'),
		       ('Finalizada'),
	           ('Pausada')

PRINT('Datos insertados en la tabla EstadosPublicacion')
END
GO

-- RUBROS --

IF (SELECT COUNT(*) FROM [SQLITO].[Rubros]) = 0
BEGIN

	INSERT INTO [SQLITO].[Rubros] (descripcion)
		VALUES ('Teatro'),
		       ('Cine'),
		       ('Conciertos'),
		       ('Musicales'),
		       ('Deportes'),
		       ('Infantiles'),
			   ('Otros')

PRINT('Datos insertados en la tabla Rubros')
END
GO

-- ROLES --

IF (SELECT COUNT(*) FROM [SQLITO].[Roles]) = 0
BEGIN
	INSERT INTO SQLITO.Roles (descripcion) 
	VALUES ('Empresa'),
	       ('Administrativo'),
	       ('Cliente')
END
GO

PRINT ('Datos insertados en la tabla Roles')

-- FUNCIONALIDADES --

IF (SELECT COUNT(*) FROM [SQLITO].[Funcionalidades]) = 0
BEGIN

	INSERT INTO SQLITO.Funcionalidades (descripcion)
		VALUES ('ABM Roles'),
			   ('Registro'),
			   ('ABM Clientes'),
			   ('ABM Empresas'),
			   ('ABM Grados'),
			   ('Generar Publicacion'),
			   ('Editar Publicacion'),
			   ('Compras'),
			   ('Historial de Compras'),
			   ('Administacion de Puntos'),
			   ('Rendicion de Comisiones'),
			   ('Estadisticas')
END
GO

PRINT('Datos insertados en la tabla Funcionalidades')

INSERT INTO SQLITO.Funcionalidades_Roles
/* (FUNCIONALIDAD,ROL)
*   ROLES:           1 EMPRESA || 2 ADMIN || 3 CLIENTE
*   FUNCIONALIDADES: 1 ABM ROLES  || 2 REGISTRO || 3 ABM CLIENTES || 4 ABM EMPRESAS || 5 ABM GRADOS || 6 GENERAR PUBLICACION || 
*					 7 EDITAR PUBLICACION || 8 COMPRAS || 9 HISTORIAL DE COMPRAS || 10 ADMINISTRACION DE PUNTOS || 11 COMISIONES ||
*					 12 ESTADISTICAS
*/
VALUES (2,1), (6,1), (7,1), 
	   (1,2), (3,2), (4,2), (11,2), (12,2),
	   (2,3), (5,3), (8,3), (9,3), (10,3)

PRINT('Funcionalidades asignadas a los roles')


--Para limpiar la tabla y resetear el contador de IDENTITY en 1

/*
*DELETE FROM [SQLITO].[EstadosPublicacion]
*DBCC CHECKIDENT ('[SQLITO].[EstadosPublicacion]', RESEED, 1)
*GO
*/

--- FUNCIONES PARA LA MIGRACION ---

IF OBJECT_ID('[SQLITO].[obtenerDireccion]') IS NOT NULL
BEGIN
	DROP FUNCTION [SQLITO].[obtenerDireccion]
END
GO

CREATE FUNCTION [SQLITO].[obtenerDireccion]
(@calle NVARCHAR(255), @altura NUMERIC(18,0), @piso NUMERIC(18,0), @depto NVARCHAR(255), @cp NVARCHAR(255))
RETURNS NVARCHAR(255)
BEGIN
	DECLARE @direccion NVARCHAR(255) = ''
	SET @direccion = @direccion + @calle + ' ' + CAST(@altura AS NVARCHAR) +
					 ' ' + CAST(@piso AS NVARCHAR) + 'º' + @depto +
					 ', CP: ' + @cp
	RETURN @direccion
END
GO

--- INSERTS ---

--MIGRACION DE EMPRESAS--

IF (SELECT COUNT(*) FROM [SQLITO].[Empresas]) = 0
BEGIN
INSERT INTO [SQLITO].[Empresas] (razonsocial, fecha_creacion, cuit, mail, direccion)
	SELECT DISTINCT Espec_Empresa_Razon_Social,
       	   Espec_Empresa_Fecha_Creacion,
	       Espec_Empresa_Cuit,
		   Espec_Empresa_Mail,
		   SQLITO.obtenerDireccion(Espec_Empresa_Dom_Calle, Espec_Empresa_Nro_Calle, Espec_Empresa_Piso, Espec_Empresa_Depto, Espec_Empresa_Cod_Postal)
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
			SQLITO.obtenerDireccion(Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal)
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

INSERT INTO [SQLITO].[Publicaciones] (cod_publicacion, descripcion, fecha_vencimiento, fecha_funcion, rubro_id, estado_id)
	SELECT DISTINCT Espectaculo_Cod,
	   	   			Espectaculo_Descripcion,
	       			Espectaculo_Fecha_Venc,
	       			Espectaculo_Fecha,
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

-- MIGRACION DE TARJETAS --

-- MIGRACION DE COMPRAS --
IF (SELECT COUNT(*) FROM [SQLITO].[Compras]) = 0
BEGIN

INSERT INTO SQLITO.Compras (cliente_id, ubicacion_id, fecha_realizacion, valor_entrada, cantidad_entradas)
SELECT c.id_cliente, sq2.id_ubicacion,Compra_Fecha, Ubicacion_Precio*Compra_Cantidad AS 'Valor Compra', Compra_cantidad
FROM (SELECT * FROM gd_esquema.Maestra WHERE Compra_Fecha IS NOT NULL AND Factura_Nro IS NULL) sq
JOIN SQLITO.Clientes c ON c.numero_documento = sq.Cli_Dni
JOIN (SELECT DISTINCT id_ubicacion, asiento, fila, publicacion_id FROM SQLITO.Ubicaciones) sq2 ON sq2.asiento = sq.Ubicacion_Asiento
AND sq2.fila = sq.Ubicacion_Fila AND sq2.publicacion_id = sq.Espectaculo_Cod 
END
GO

select * from SQLITO.Compras

DECLARE @var NVARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.Compras)
PRINT('Datos insertados en la tabla Compras. Nuevas Filas: ' + @var)

-- MIGRACION DE FACTURAS -- 

IF (SELECT COUNT(*) FROM [SQLITO].[Facturas]) = 0
BEGIN

INSERT INTO SQLITO.Facturas (numero_factura,fecha_emision,total,empresa_id,medio_pago)
SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total, e.id_empresa, Forma_Pago_Desc
FROM gd_esquema.Maestra gdm
JOIN SQLITO.Empresas e ON gdm.Espec_Empresa_Cuit = e.cuit
WHERE Factura_Nro IS NOT NULL
END
GO

DECLARE @var NVARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.Facturas)
PRINT('Datos insertados en la tabla Facturas. Nuevas Filas: ' + @var)

-- MIGRACION DE ITEMS --

IF (SELECT COUNT(*) FROM [SQLITO].[ItemsFactura]) = 0
BEGIN

INSERT INTO SQLITO.ItemsFactura (factura_id, cantidad, comision, compra_id, descripcion)
SELECT DISTINCT Factura_Nro, Item_Factura_Cantidad, Item_Factura_Monto, c.id_compra, Item_Factura_Descripcion FROM gd_esquema.Maestra gdm
JOIN SQLITO.Ubicaciones u ON u.asiento = gdm.Ubicacion_Asiento AND u.fila = gdm.Ubicacion_Fila
JOIN SQLITO.Compras c ON c.ubicacion_id = u.id_ubicacion
WHERE gdm.Espectaculo_Cod = u.publicacion_id
AND Factura_Nro IS NOT NULL
END
GO

DECLARE @var VARCHAR(10)
SELECT @var = (SELECT COUNT(*) FROM SQLITO.ItemsFactura)
PRINT('Datos insertados en la tabla ItemsFactura. Nuevas Filas: ' + @var)

-- PREMIOS --

INSERT INTO SQLITO.Premios (descripcion, puntos_requeridos, cantidad_stock)
VALUES('Mochila Hello Kitty', 1200, 60),
	  ('Reloj Swatch Perfect Ride', 5400, 20),
	  ('Camiseta Retro Argentina 86 Le Coq Sportif', 4000,10),
	  ('Viaje a Tahiti 5 Noches',21000,5),
	  ('Entradas Cinemark',500,200),
	  ('Red Dead Redemption 2', 2425, 40),
	  ('Cena P/2 en Parrilla Los Hermanos', 1850, 10),
	  ('Dia de Spa', 2000, 10),
	  ('Entradas Temaiken',850,150)
GO

PRINT('Datos insertados en la tabla Premios')

-- GRADOS --
/* En la tabla maestra hay 13443 valores de comision distintos, todos cercanos a 10. Podriamos definir un grado 'Otros' con id = 4 
* y valor de comision 10, ya que si se hace SELECT DISTINCT ROUND(Ubicacion_Precio/Item_Factura_Monto,0) obtenemos como unico resultado 10;
* o simplemento dejarlo en null para las compras realizadas con anterioridad, que es el camino que voy a tomar de momento.
* Basandome en uno de los mails recibidos al grupo durante la ultima semana, entiendo que al no estar explicitamente definidos en el enunciado,
* hay que completar la tabla grados a criterio -arbitrariamente-. Es necesario contar con los grados migrados para usarlos en la app
*/

INSERT INTO SQLITO.Grados (descripcion,comision)
VALUES ('Baja', 4), ('Media', 6), ('Alta', 9)
GO

PRINT ('Datos insertados en la tabla Grados')
GO

-- USUARIOS --

CREATE PROCEDURE crearUsuario_cliente
AS
BEGIN

DECLARE @username NVARCHAR(255), @password NVARCHAR(255), @pw_act BIT

DECLARE adduser_cursor CURSOR FOR
SELECT DISTINCT LOWER(nombre) + LOWER(apellido), HASHBYTES('SHA2_256',CRYPT_GEN_RANDOM(8)), 1 FROM SQLITO.Clientes

OPEN adduser_cursor
FETCH NEXT FROM adduser_cursor INTO
@username, @password, @pw_act

WHILE @@FETCH_STATUS = 0

BEGIN

IF (SELECT COUNT(username) FROM SQLITO.Usuarios WHERE username = @username) = 0

BEGIN
INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
VALUES (@username, @password, @pw_act)
END

ELSE 
BEGIN
INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
VALUES (@username + '2', @password, @pw_act)
END

INSERT INTO SQLITO.Roles_Usuarios
VALUES(3,SCOPE_IDENTITY())

FETCH NEXT FROM adduser_cursor INTO
@username, @password, @pw_act

END

CLOSE adduser_cursor
DEALLOCATE adduser_cursor
END
GO

CREATE PROCEDURE crearUsuario_empresa
AS
BEGIN

DECLARE @username NVARCHAR(255), @password NVARCHAR(255), @pw_act BIT

DECLARE addus3r_cursor CURSOR FOR
SELECT DISTINCT LOWER(SUBSTRING(razonsocial,1,5)) +	LOWER(SUBSTRING(razonsocial,7,6)) + SUBSTRING(razonsocial,17,2), 
	HASHBYTES('SHA2_256',CRYPT_GEN_RANDOM(8)), 1 FROM SQLITO.Empresas

OPEN addus3r_cursor
FETCH NEXT FROM addus3r_cursor INTO
@username, @password, @pw_act

WHILE @@FETCH_STATUS = 0

BEGIN

INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
VALUES (@username, @password, @pw_act)

INSERT INTO SQLITO.Roles_Usuarios
VALUES (1,SCOPE_IDENTITY())

FETCH NEXT FROM addus3r_cursor INTO
@username, @password, @pw_act

END

CLOSE addus3r_cursor
DEALLOCATE addus3r_cursor
END
GO

EXEC crearUsuario_cliente
PRINT ('Usuarios creados para clientes existentes')
EXEC crearUsuario_empresa
PRINT ('Usuarios creados para empresas existentes')

-- ADMIN GENERAL DEL SISTEMA --

INSERT INTO SQLITO.Roles
VALUES ('Administrador General')
GO

INSERT INTO SQLITO.Funcionalidades_Roles
VALUES (1,4), (2,4), (3,4), (4,4), (5,4), (6,4), (7,4), (8,4), (9,4), (10,4), (11,4), (12,4)
GO

INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada) 
VALUES ('admin', HASHBYTES('SHA2_256','w23e'),1)
GO

INSERT INTO SQLITO.Roles_Usuarios
VALUES(4,(SELECT id_usuario FROM SQLITO.Usuarios WHERE username = 'admin'))
GO

PRINT ('Agregado Administrador General del Sistema')

PRINT ('Script de Migracion Finalizado')