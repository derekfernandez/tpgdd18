USE [GD2C2018]
GO

-- CREACION DE ESQUEMA --

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'SQLITO')
BEGIN
	
	EXEC('CREATE SCHEMA [SQLITO] AUTHORIZATION [gdEspectaculos2018]')
	PRINT 'Esquema Creado'
END
GO

-- BORRADO DE TABLAS --


IF OBJECT_ID('SQLITO.Roles') IS NOT NULL
	DROP TABLE [SQLITO].[Roles]

IF OBJECT_ID('SQLITO.Funcionalidades') IS NOT NULL
	DROP TABLE [SQLITO].[Funcionalidades]

IF OBJECT_ID('SQLITO.Funcionalidades_Roles') IS NOT NULL
	DROP TABLE [SQLITO].[Funcionalidades_Roles]

IF OBJECT_ID('SQLITO.Usuarios') IS NOT NULL
	DROP TABLE [SQLITO].[Usuarios]

IF OBJECT_ID('SQLITO.Clientes') IS NOT NULL
	DROP TABLE [SQLITO].[Clientes]

IF OBJECT_ID('SQLITO.Empresas') IS NOT NULL
	DROP TABLE [SQLITO].[Empresas]

IF OBJECT_ID('SQLITO.Roles_Usuarios') IS NOT NULL
	DROP TABLE [SQLITO].[Roles_Usuarios]

IF OBJECT_ID('SQLITO.Tarjetas') IS NOT NULL
	DROP TABLE [SQLITO].[Tarjetas]

IF OBJECT_ID('SQLITO.Premios') IS NOT NULL
	DROP TABLE [SQLITO].[Premios]

IF OBJECT_ID('SQLITO.Puntos') IS NOT NULL
	DROP TABLE [SQLITO].[Puntos]

IF OBJECT_ID('SQLITO.Compras') IS NOT NULL
	DROP TABLE [SQLITO].[Compras]

IF OBJECT_ID('SQLITO.Publicaciones') IS NOT NULL
	DROP TABLE [SQLITO].[Publicaciones]

IF OBJECT_ID('SQLITO.Grados') IS NOT NULL
	DROP TABLE [SQLITO].[Grados]

IF OBJECT_ID('SQLITO.Rubros') IS NOT NULL
	DROP TABLE [SQLITO].[Rubros]

IF OBJECT_ID('SQLITO.EstadosPublicacion') IS NOT NULL
	DROP TABLE [SQLITO].[EstadosPublicacion]

IF OBJECT_ID('SQLITO.Ubicaciones') IS NOT NULL
	DROP TABLE [SQLITO].[Ubicaciones]

IF OBJECT_ID('SQLITO.Items') IS NOT NULL
	DROP TABLE [SQLITO].[Items]

IF OBJECT_ID('SQLITO.Facturas') IS NOT NULL
	DROP TABLE [SQLITO].[Facturas]

IF OBJECT_ID('SQLITO.TiposUbicacion') IS NOT NULL
	DROP TABLE [SQLITO].[TiposUbicacion]

-- CREACION DE TABLAS --

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Funcionalidades'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Funcionalidades] (
		
		[id_funcionalidad] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar](100)
	)

PRINT('Tabla SQLITO.Funcionalidades Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Funcionalidades_Roles'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Funcionalidades_Roles] (
		
		[id_funcionalidad] [tinyint] NOT NULL,
		[id_rol] [tinyint] NOT NULL,
		PRIMARY KEY ([id_funcionalidad],[id_rol])
	)

PRINT('Tabla SQLITO.Funcionalidades_Roles Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Roles'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Roles] (

		[id_rol] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar](100)
	)

PRINT('Tabla SQLITO.Roles Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Roles_Usuarios'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Roles_Usuarios] (

		[id_rol] [tinyint] NOT NULL,
		[id_user] [tinyint] NOT NULL,
		PRIMARY KEY([id_rol],[id_user])
	)

PRINT('Tabla SQLITO.Roles_Usuarios Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Usuarios] (
		
		[id_user] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[username] [nvarchar](30),
		[password] [nvarchar](30),
		[mail] [nvarchar](50),
		[direccion] [nvarchar](255),
		[zona] [nvarchar](30),
		[telefono] [nvarchar](20),
		[intentos_fallidos] [tinyint] DEFAULT 0,
		[estado] [bit] DEFAULT 1,
		[alta] [bit] DEFAULT 0
	)

PRINT('Tabla SQLITO.Usuarios Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Premios'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Premios] (

		[id_premio] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[puntos_requeridos] [smallint],
		[cantidad_stock] [smallint],
		[id_admin] [tinyint]
	)

PRINT('Tabla SQLITO.Premios Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clientes'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Clientes] (

		[id_cliente] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[nombre] [nvarchar](255),
		[apellido] [nvarchar](255),
		[cuil] [nvarchar] (13) CHECK ([cuil] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]' OR 
			[cuil] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]'),
		[tipo_documento] [nvarchar] (3) CHECK ([tipo_documento] IN ('DNI','LC','LE','CI')),
		[numero_documento] [numeric] (8,0) CHECK (LEN([numero_documento]) = 7 OR LEN([numero_documento]) = 8),
		[fecha_nacimiento] [datetime],
		[fecha_creacion] [datetime],
		[id_tarjeta] [tinyint],
		[estado] [bit] DEFAULT 1
	)

PRINT('Tabla SQLITO.Clientes Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tarjetas'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Tarjetas] (
		
		[id_tarjeta] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[nombre_banco] [nvarchar](50),
		[numero_tarjeta] [numeric](18,0) NOT NULL,
		[cvv] [tinyint] CHECK(LEN([cvv]) = 3)
	)

PRINT('Tabla SQLITO.Tarjetas Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Puntos'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Puntos] (

		[id_puntos] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[cantidad] [bigint]	NOT NULL,
		[id_cliente] [tinyint],
		[fecha_vencimiento] [datetime]
	)

PRINT('Tabla SQLITO.Puntos Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empresas'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Empresas] (
		
		[id_empresa] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[ciudad] [nvarchar](50),
		[razonsocial] [nvarchar](255),
		[fecha_creacion] [datetime],
		[mail] [nvarchar](50),
		[cuit] [nvarchar] (13) CHECK ([cuit] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]' OR 
			[cuit] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]'),
		/* Agrego un campo para migrar forma_pago_desc, si no es correcto se cambia */
		[medio_pago_comision] [nvarchar] (30)
	)

PRINT('Tabla SQLITO.Empresas Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Compras'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Compras] (
		
		[id_compra] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[id_cliente] [tinyint],
		[id_publicacion] [tinyint],
		[id_ubicacion] [tinyint],
		[valor_entrada] [numeric] (18,2),
		[medio_pago] [nvarchar] (30),
		[cantidad_entradas] [tinyint],
		[cantidad_puntos] [bigint]
	)

PRINT('Tabla SQLITO.Compras Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Publicaciones'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Publicaciones] (
		
		/* El enunciado dice que tiene que ser autonumerico y consecutivo pero la tabla maestra
		* tiene codigos cargados. Si pongo identity no va a hacer los inserts. Habria que ver como hacer
		*/
		[cod_publicacion] [numeric] (18,0) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255),
		[fecha_publicacion] [datetime],
		[fecha_vencimiento] [datetime],
		[fecha_espectaculo] [datetime],
		[direccion] [nvarchar](100),
		[id_empresa] [tinyint],
		[id_grado] [tinyint],
		[id_rubro] [tinyint],
		[id_estado] [tinyint],
		CHECK ([fecha_vencimiento] > [fecha_publicacion] AND [fecha_espectaculo] > [fecha_publicacion])
	)

PRINT('Tabla SQLITO.Publicaciones Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Grados'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Grados] (

		[id_grado] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255),
		[comision] [numeric] (6,2)
	)

PRINT('Tabla SQLITO.Grados Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EstadosPublicacion'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[EstadosPublicacion] (
		
		[id_estado] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255) CHECK ([descripcion] IN ('Borrador','Publicada','Finalizada','Pausada'))
	)

PRINT('Tabla SQLITO.EstadosPublicacion Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Rubros'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Rubros] (

		[id_rubro] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255)
	)

PRINT('Tabla SQLITO.Rubros Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Items'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Items] (

		[id_item] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[numero_item] [smallint] NOT NULL,
		[numero_factura] [tinyint],
		[comision] [numeric] (6,2),
		[id_compra] [tinyint],
		[descripcion] [nvarchar] (255)
	)

PRINT('Tabla SQLITO.Items Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Facturas'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Facturas] (

		[numero_factura] [int] PRIMARY KEY NOT NULL,
		[fecha_emision] [datetime],
		[total] [numeric] (18,2),
		[id_empresa] [tinyint]
	)

PRINT('Tabla SQLITO.Facturas Creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Ubicaciones'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Ubicaciones] (
		
		[id_ubicacion] [tinyint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[fila] [nvarchar](3),
		[asiento] [numeric] (6,0),
		[id_tipo] [int],
		[precio] [numeric] (18,2),
		[disponible] [bit] DEFAULT 1,
		[id_publicacion] [tinyint]
	)

PRINT('Tabla SQLITO.Ubicaciones Creada')

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

PRINT('Tabla SQLITO.TiposUbicacion Creada')

END
GO