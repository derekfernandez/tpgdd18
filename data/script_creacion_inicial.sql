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
		[descripcion] [nvarchar] (100),
		[puntos_requeridos] [smallint] NOT NULL,
		[cantidad_stock] [smallint] NOT NULL,
		[admin_responsable_id] [int]
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
		[cantidad] [int] DEFAULT 1,
		[comision] [numeric] (6,2) NOT NULL,
		[compra_id] [int],
		[descripcion] [nvarchar] (255) DEFAULT 'Comision por compra'
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
		[descripcion] [nvarchar](100) NOT NULL,
		[habilitado] [bit] DEFAULT 1
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
		[cantidad_entradas] [int] NOT NULL DEFAULT 1,
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
		[cuil] [nvarchar] (255),
		[tipo_documento] [nvarchar] (3),
		[numero_documento] [numeric] (8,0) CHECK (LEN([numero_documento]) <= 8),
		[fecha_nacimiento] [datetime] NOT NULL,
		--Puede ser NULL, los Clientes de la tabla maestra no tienen este campo
		[fecha_creacion] [datetime] DEFAULT '1980-01-01 00:00:00',
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
		--El banco y el nombre en la tarjeta pueden no estar especificados
		[nombre_banco] [nvarchar](50),
		[nombre_titular] [nvarchar](50) NOT NULL,
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
		[fila] [nvarchar] (3),
		[asiento] [nvarchar] (3),
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
		[publ_descripcion] [nvarchar] (255) NOT NULL,
		[fecha_creacion] [datetime],
		--La fecha de vencimiento puede ser null, si todavia no se publico el espectaculo
		[fecha_vencimiento] [datetime],
		[fecha_funcion] [datetime] NOT NULL,
		--En la tabla maestra ninguno tiene direccion
		[direccion] [nvarchar] (100),
		[empresa_id] [int],
		[grado_id] [int],
		--Comision aca, desnormalizada, por si cambia la comision de uno de los grados (que son fijos)
		[publ_comision] [numeric] (6,2),
		[rubro_id] [int],
		[estado_id] [int]
		--Este check quedaria medio al dope, ya las inserciones verifican esta restriccion desde la aplicacion
		--CHECK (([fecha_funcion] > [fecha_creacion])
		--	AND ([fecha_vencimiento] > [fecha_creacion])
		--	AND ([fecha_vencimiento] <= [fecha_funcion]))
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
		--Esta comision es la actual de cada grado; la desnormalizo en Publicacion al crearla, por si esta variase
		[comision] [numeric] (6,2) NOT NULL,
		[habilitado] bit CONSTRAINT validarNulos DEFAULT 1
	)

PRINT('Tabla SQLITO.Grados creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Rubros'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[Rubros] (

		[id_rubro] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[r_descripcion] [nvarchar] (255)
	)

PRINT('Tabla SQLITO.Rubros creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EstadosPublicacion'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN
	
	CREATE TABLE [SQLITO].[EstadosPublicacion] (
		
		[id_estado] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[descripcion] [nvarchar] (255) CHECK ([descripcion] IN ('Borrador','Publicada','Finalizada','Pausada','Eliminada'))
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
		[habilitado] [bit] DEFAULT 1,
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
		[password] [varbinary](255),
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
			   WHERE CONSTRAINT_NAME = 'FK_Premios_Usuarios')
	
	BEGIN

		ALTER TABLE [SQLITO].[Premios]
		ADD CONSTRAINT FK_Premios_Usuarios
		FOREIGN KEY (admin_responsable_id) REFERENCES [SQLITO].[Usuarios](id_usuario)
		PRINT('Foreign Key entre Premios y Usuarios agregada')

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

	--Primero inserto los tipos ya existentes (8)
	INSERT INTO [SQLITO].[TiposUbicacion] (id_tipo,descripcion)
		
		SELECT DISTINCT Ubicacion_Tipo_Codigo, Ubicacion_Tipo_Descripcion
		FROM gd_esquema.Maestra
		ORDER BY Ubicacion_Tipo_Codigo

	--Y luego inserto manualmente el ultimo, Sin Numerar
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
	           ('Pausada'),
			   ('Eliminada')

PRINT('Datos insertados en la tabla SQLITO.EstadosPublicacion')
END
GO

-- RUBROS --

IF (SELECT COUNT(*) FROM [SQLITO].[Rubros]) = 0
BEGIN

	INSERT INTO [SQLITO].[Rubros] (r_descripcion)
		VALUES ('Teatro'),
		       ('Cine'),
		       ('Conciertos'),
		       ('Musicales'),
		       ('Deportes'),
		       ('Infantiles'),
			   ('Otros')

PRINT('Datos insertados en la tabla SQLITO.Rubros')
END
GO

-- ROLES --

IF (SELECT COUNT(*) FROM [SQLITO].[Roles]) = 0
BEGIN
	INSERT INTO SQLITO.Roles (descripcion) 
	VALUES ('Empresa'),
	       ('Administrativo'),
	       ('Cliente'),
	       --Este rol es unico y puede realizar todas las funcionalidades; ID = 4
	       ('Administrador General')
END
GO

PRINT ('Datos insertados en la tabla SQLITO.Roles')

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

PRINT('Datos insertados en la tabla SQLITO.Funcionalidades')

-- FUNCIONALIDADES POR ROL --

IF (SELECT COUNT(*) FROM [SQLITO].[Funcionalidades_Roles]) = 0
BEGIN

	INSERT INTO SQLITO.Funcionalidades_Roles (funcionalidad_id, rol_id)
	/* (FUNCIONALIDAD,ROL)
	*   ROLES:           1 EMPRESA || 2 ADMIN || 3 CLIENTE || 4 ADMINISTRADOR GENERAL
	*   FUNCIONALIDADES: 1 ABM ROLES  || 2 REGISTRO || 3 ABM CLIENTES || 4 ABM EMPRESAS || 5 ABM GRADOS || 6 GENERAR PUBLICACION || 
	*					 7 EDITAR PUBLICACION || 8 COMPRAS || 9 HISTORIAL DE COMPRAS || 10 ADMINISTRACION DE PUNTOS || 11 COMISIONES ||
	*					 12 ESTADISTICAS
	*/
		VALUES (2,1), (6,1), (7,1), 
			   (1,2), (3,2), (4,2), (5,2), (11,2), (12,2),
			   (2,3), (8,3), (9,3), (10,3),
			   --El Administrador General puede realizar todas las funcionalidades
			   (1,4), (2,4), (3,4), (4,4), (5,4), (6,4), (7,4), (8,4), (9,4), (10,4), (11,4), (12,4)
			   
END
GO

PRINT('Funcionalidades asignadas a los roles. Datos insertados en SQLITO.Funcionalidades_Roles')

-- PREMIOS --

IF (SELECT COUNT(*) FROM [SQLITO].[Premios]) = 0
BEGIN

	INSERT INTO SQLITO.Premios (descripcion, puntos_requeridos, cantidad_stock)
	VALUES('Mochila Hello Kitty', 1200, 60),
		  ('Reloj Swatch Perfect Ride', 5400, 20),
		  ('Camiseta Retro Argentina 86 Le Coq Sportif', 4000, 10),
		  ('Viaje a Tahiti 5 Noches',21000, 5),
		  ('Entradas Cinemark',500, 200),
		  ('Red Dead Redemption 2', 2425, 40),
		  ('Cena P/2 en Parrilla Los Hermanos', 1850, 10),
		  ('Dia de Spa', 2000, 10),
		  ('Entradas Temaiken',850, 150)

END
GO

PRINT('Datos insertados en la tabla SQLITO.Premios')

-- GRADOS --
/* En la tabla maestra hay 13443 valores de comision distintos, todos cercanos a 10. Podriamos definir un grado 'Otros' con id = 4 
* y valor de comision 10, ya que si se hace SELECT DISTINCT ROUND(Ubicacion_Precio/Item_Factura_Monto,0) obtenemos como unico resultado 10;
* o simplemento dejarlo en null para las compras realizadas con anterioridad, que es el camino que voy a tomar de momento.
* Basandome en uno de los mails recibidos al grupo durante la ultima semana, entiendo que al no estar explicitamente definidos en el enunciado,
* hay que completar la tabla grados a criterio -arbitrariamente-. Es necesario contar con los grados migrados para usarlos en la app
*/

IF (SELECT COUNT(*) FROM [SQLITO].[Grados]) = 0
BEGIN

	INSERT INTO SQLITO.Grados (descripcion,comision)
	VALUES ('Baja', 8), ('Media', 10), ('Alta', 12)

END	
GO

PRINT ('Datos insertados en la tabla SQLITO.Grados')

--Herramienta para limpiar la tabla y resetear el contador de un IDENTITY en n

/*
*DELETE FROM [SQLITO].[NombreTabla]
*DBCC CHECKIDENT ('[SQLITO].[NombreTabla]', RESEED, n)
*/

--- FUNCIONES PARA LA MIGRACION ---

-- Obtener la cadena que formara el campo direccion de un Cliente o Empresa --
IF OBJECT_ID('[SQLITO].[obtenerDireccion]') IS NOT NULL
BEGIN
	DROP FUNCTION [SQLITO].[obtenerDireccion]
END
GO

CREATE FUNCTION [SQLITO].[obtenerDireccion]
(@calle NVARCHAR(255), @altura NUMERIC(18,0), @piso NUMERIC(18,0), @depto NVARCHAR(255), @localidad NVARCHAR(255), @cp NVARCHAR(255))
RETURNS NVARCHAR(255)
BEGIN
	DECLARE @direccion NVARCHAR(255)
	SET @direccion = @calle + ',' + CONVERT(NVARCHAR(18), @altura) +
					 ',' + CONVERT(NVARCHAR(18), @piso) + 'º' + @depto +
					 ', ' + @localidad + ', CP: ' + @cp
	RETURN @direccion
END
GO

/* CODIGOS DE PRUEBA
SELECT [SQLITO].[obtenerDireccion](Espec_Empresa_Dom_Calle, Espec_Empresa_Nro_Calle, Espec_Empresa_Piso, Espec_Empresa_Depto, '', Espec_Empresa_Cod_Postal)
FROM gd_esquema.Maestra
SELECT [SQLITO].[obtenerDireccion](Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, '', Cli_Cod_Postal)
FROM gd_esquema.Maestra
*/

-- Actualizar las Publicaciones que tienen las localidades agotadas, y marcarlas como Finalizadas --
IF OBJECT_ID('[SQLITO].[SP_CorregirEstadoPublicaciones]') IS NOT NULL
BEGIN
	DROP PROCEDURE [SQLITO].[SP_CorregirEstadoPublicaciones]
END
GO

CREATE PROCEDURE [SQLITO].[SP_CorregirEstadoPublicaciones]
AS
BEGIN

	--Variable de tabla (no puedo llamar una temporal desde aca) con las ubicaciones
	--totales y vendidas de cada publicacion, y flag de si estan agotadas o no
	DECLARE @UbicacionesPorPublicacion AS TABLE (
		[id_publicacion] INT,
		[entradas_totales] INT,
		[entradas_compradas] INT,
		[esta_agotada] BIT
	)

	--Inserto los datos necesarios en dicha variable de tabla; de entrada, supongo que ninguna esta agotada
	INSERT INTO @UbicacionesPorPublicacion
	(id_publicacion, entradas_totales, entradas_compradas,esta_agotada)
		SELECT cod_publicacion,
			   COUNT(*),
		       (SELECT COUNT(*)
			    FROM SQLITO.Ubicaciones AS U
					LEFT JOIN SQLITO.Compras AS C ON (C.ubicacion_id = U.id_ubicacion)
		        WHERE (U.id_ubicacion IN (SELECT C1.ubicacion_id
								          FROM SQLITO.Compras AS C1))
					AND (U.publicacion_id = P.cod_publicacion)),
				0
	            FROM SQLITO.Publicaciones AS P
					JOIN SQLITO.Ubicaciones AS U ON (U.publicacion_id = P.cod_publicacion)
	            GROUP BY cod_publicacion
	            ORDER BY cod_publicacion
	
	--Marco cuales estan agotadas, haciendo una simple comparacion compradas-totales
	UPDATE @UbicacionesPorPublicacion
		SET esta_agotada = 1
		WHERE entradas_compradas = entradas_totales

	--Actualizo la tabla de Publicaciones en aquellas que, segun la variable, estan agotadas
	--Las marco como Finalizadas (estado = 3)
	UPDATE SQLITO.Publicaciones
	SET estado_id = 3
		WHERE (SELECT esta_agotada
			   FROM @UbicacionesPorPublicacion
			   WHERE id_publicacion = cod_publicacion) = 1

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

	INSERT INTO [SQLITO].[Publicaciones] (cod_publicacion, publ_descripcion, fecha_vencimiento, fecha_funcion, empresa_id, rubro_id, estado_id, grado_id, publ_comision)
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
		       			2,
		       			--Ponemos todas en 'Media' por default, tienen una comision del 10% aprox
		       			2,
						(SELECT comision FROM SQLITO.Grados WHERE id_grado = 2)
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
		   	   CONVERT(NVARCHAR(3), Ubicacion_Asiento),
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

-- CORRECCION DE PUBLICACIONES MIGRADAS --

EXEC [SQLITO].[SP_CorregirEstadoPublicaciones]

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

	DECLARE @username NVARCHAR(255), @password VARBINARY (255), @clienteID INT

	DECLARE adduser_cursor CURSOR FOR 
	SELECT id_cliente,LOWER(REPLACE(nombre,' ','')) + LOWER(REPLACE(apellido,' ','')),
	HASHBYTES('SHA2_256',CRYPT_GEN_RANDOM(8)) FROM SQLITO.Clientes

	OPEN adduser_cursor
	FETCH NEXT FROM adduser_cursor INTO @clienteID, @username, @password

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (SELECT COUNT(username)
		    FROM SQLITO.Usuarios
		    WHERE username = @username) = 0
		BEGIN
			INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
			VALUES (@username, @password, 1)
		END

		ELSE 
		BEGIN
			INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
			VALUES (@username + '2', @password, 1)
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

	DECLARE @username NVARCHAR(255), @password VARBINARY(255), @empresaID INT

	DECLARE addus3r_cursor CURSOR FOR SELECT id_empresa,
	LOWER(SUBSTRING(razonsocial,1,5)) + LOWER(SUBSTRING(razonsocial,7,6)) + SUBSTRING(razonsocial,17,2), 
	HASHBYTES('SHA2_256',CRYPT_GEN_RANDOM(8)) FROM SQLITO.Empresas
	
	OPEN addus3r_cursor
	FETCH NEXT FROM addus3r_cursor INTO @empresaID, @username, @password
	
	WHILE @@FETCH_STATUS = 0
	BEGIN

		INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada)
		VALUES (@username, @password, 1)

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
	VALUES ('admin', HASHBYTES('SHA2_256','w23e'), 1)

	DECLARE @adminUser INT
	SET @adminUser = (SELECT id_usuario
					  FROM SQLITO.Usuarios
					  WHERE username = 'admin')

	INSERT INTO SQLITO.Roles_Usuarios
	VALUES(4, @adminUser)
	
	INSERT INTO SQLITO.Clientes (nombre,apellido,tipo_documento,numero_documento,fecha_nacimiento,fecha_creacion,usuario_id,estado)
		 VALUES ('Admin','General','DNI','37541207','1993-03-13T23:50:00', '2018-11-30T00:00:00',@adminUser, 1)
	
	INSERT INTO SQLITO.Roles_Usuarios
	VALUES(3, @adminUser)

	INSERT INTO SQLITO.Empresas (razonsocial,fecha_creacion,usuario_id) 
		 VALUES ('Admin General', '2018-11-30T00:00:00',@adminUser)
	
	INSERT INTO SQLITO.Roles_Usuarios
	VALUES(1, @adminUser)
	
	--Lo designo como responsable de todos los premios; VER ESTO
	UPDATE SQLITO.Premios
	SET admin_responsable_id = @adminUser
	
END
GO

PRINT ('Agregado Administrador General del Sistema')

PRINT ('Script de Migracion Finalizado')

--- FUNCIONES PARA LLAMAR DESDE C# EN LOS ABMs ---

-- PARA ABM DE ESTADISTICAS --

--Obtener el nombre de un mes a partir de su numero, para el listado de empresas con
--mas localidades no vendidas por mes
IF OBJECT_ID('[SQLITO].[nombreMes]') IS NOT NULL
BEGIN

	DROP FUNCTION [SQLITO].[nombreMes]

END
GO

CREATE FUNCTION [SQLITO].[nombreMes]
(@numeroMes INT)
RETURNS NVARCHAR(30)
BEGIN

	DECLARE @nombre NVARCHAR(30)

	--Segun el numero de mes (parametro) escribo el nombre del mismo en la variable a retornar
	SET @nombre =
		CASE @numeroMes
			WHEN 1 THEN 'Enero'
			WHEN 2 THEN 'Febrero'
			WHEN 3 THEN 'Marzo'
			WHEN 4 THEN 'Abril'
			WHEN 5 THEN 'Mayo'
			WHEN 6 THEN 'Junio'
			WHEN 7 THEN 'Julio'
			WHEN 8 THEN 'Agosto'
			WHEN 9 THEN 'Septiembre'
			WHEN 10 THEN 'Octubre'
			WHEN 11 THEN 'Noviembre'
			WHEN 12 THEN 'Diciembre'
		END

	RETURN @nombre

END
GO

--Devolver tabla con empresas con mas localidades no vendidas
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'estadistica_empresasMenosVendedoras')
BEGIN

	DROP PROCEDURE estadistica_empresasMenosVendedoras

END
GO

CREATE PROCEDURE estadistica_empresasMenosVendedoras
				 (@anio INT, @trimestre INT)
AS
BEGIN
	
	DECLARE @tablaResultante AS TABLE (
		[razonSocial] NVARCHAR(255),
		[mes] INT,
		[año] INT,
		[gradoID] INT,
		[gradoDesc] NVARCHAR(255),
		[cantidadNoVendidas] INT
	)

	--En esta tabla, que debe ser local al SP ya que depende de los parametros pasados, pongo
	--el top 5 de empresas con mas localidades no vendidas, siendo las 5 que mas entradas no vendieron
	INSERT INTO @tablaResultante
		SELECT TOP 5 E.razonsocial,
		             MONTH(P.fecha_funcion),
		             YEAR(P.fecha_funcion),
					 G.id_grado,
					 G.descripcion,
	                 COUNT(*)
		FROM [SQLITO].[Empresas] AS E
			JOIN [SQLITO].[Publicaciones] AS P ON (P.empresa_id = E.id_empresa)
			JOIN [SQLITO].[Grados] AS G ON (P.grado_id = G.id_grado)
			JOIN [SQLITO].[Ubicaciones] AS U ON (U.publicacion_id = P.cod_publicacion)
			LEFT JOIN [SQLITO].[Compras] AS C ON (C.ubicacion_id = U.id_ubicacion)
		WHERE id_ubicacion NOT IN (SELECT ubicacion_id
						   	       FROM [SQLITO].[Compras])
			AND (DATEPART(QUARTER, P.fecha_funcion) = @trimestre)
			AND (YEAR(P.fecha_funcion) = @anio)
		GROUP BY id_empresa, razonsocial,
		         MONTH(P.fecha_funcion),
				 YEAR(P.fecha_funcion),
				 G.id_grado,
				 G.descripcion
		ORDER BY COUNT(*) DESC

	--Pero tengo que ordenar ese top 5 por fecha y por visibilidad
	SELECT razonSocial,
		   [SQLITO].[nombreMes](mes),
		   año,
		   gradoDesc,
		   cantidadNoVendidas
	FROM @tablaResultante
	ORDER BY año ASC, mes ASC, gradoDesc ASC

END
GO


--Devolver tabla con clientes con mayor cantidad de puntos vencidos 
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'estadistica_clientesConMasPuntosVencidos')
BEGIN

	DROP PROCEDURE estadistica_clientesConMasPuntosVencidos

END
GO

CREATE PROCEDURE estadistica_clientesConMasPuntosVencidos
				 (@anio INT, @trimestre INT)
AS
BEGIN

	--Creo una variable para almacenar el primer dia del trimestre y del año ingresados
	--por parametro. Al año 0 (1/1/1900) le agrego los años que pasaron entre el 
	--parametro y ese, y le sumo tantos trimestres como se haya especificado en el parametro
	DECLARE @fechaParametro SMALLDATETIME
	SET @fechaParametro = DATEADD(year, (@anio - 1900), 0)
	SET @fechaParametro = DATEADD(qq, @trimestre, @fechaParametro)

	SELECT TOP 5 C.nombre,
	   	   C.apellido,
	       SUM(P.cantidad)
	FROM [SQLITO].[Clientes] AS C
		JOIN [SQLITO].[Puntos] AS P ON (C.id_cliente = P.cliente_id)
	--Solo me quedo con los lotes de puntos cuyo vencimiento es anterior al parametro (estan vencidos)
	WHERE P.fecha_vencimiento <= @fechaParametro
	GROUP BY P.cliente_id, C.nombre, C.apellido
	ORDER BY SUM(P.cantidad) DESC

END
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'estadistica_clientesConMasCompras')
BEGIN

	DROP PROCEDURE estadistica_clientesConMasCompras

END
GO

CREATE PROCEDURE estadistica_clientesConMasCompras
	(@anio INT, @trimestre INT)

AS
BEGIN
	
	SELECT TOP 5 CL.nombre,
				 CL.apellido,
				 E.razonsocial,
				 COUNT(*)
	FROM SQLITO.Clientes AS CL
		JOIN SQLITO.Compras AS CO ON (CO.cliente_id = CL.id_cliente)
		JOIN SQLITO.Ubicaciones AS U ON (CO.ubicacion_id = U.id_ubicacion)
		JOIN SQLITO.Publicaciones AS P ON (U.publicacion_id = P.cod_publicacion)
		JOIN SQLITO.Empresas AS E ON (P.empresa_id = E.id_empresa)
	WHERE (YEAR(CO.fecha_realizacion) = @anio)
		AND (DATEPART(QUARTER, CO.fecha_realizacion) = @trimestre)
	GROUP BY CL.nombre, CL.apellido, E.id_empresa, E.razonsocial
	ORDER BY COUNT(*) DESC

END
GO

--Trigger para controlar que cuando se acaban las ubicaciones de una publciacion, se lo ponga en estado "Finalizado" (3)
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'FinalizarPublicacionAutomaticamente')
BEGIN

	DROP TRIGGER FinalizarPublicacionAutomaticamente

END
GO

CREATE TRIGGER SQLITO.FinalizarPublicacionAutomaticamente
ON SQLITO.Compras AFTER INSERT
AS
BEGIN
	
	--ID de la Ubicacion recien comprada, seria el ID mas reciente de Compras
	--Esto puede hacerse asi porque las inserciones a Compras son atomicas (desde el ABM Compras)
	--TODO: Implementar con cursor, para la migracion (Hacerlo o no?)
	DECLARE @UbicacionComprada INT
	--ID de la Publicacion a la cual pertenece la Ubicacion comprada
	DECLARE @PublicacionID INT
	--Cantidad de Ubicaciones de la Publicacion (para verificar si todas fueron compradas)
	DECLARE @CantidadUbicaciones INT
	--Cantidad de Ubicaciones de la Publicacion que fueron compradas
	DECLARE @CantidadCompradas INT
	SET @UbicacionComprada = (SELECT TOP 1 ubicacion_id FROM INSERTED)
	SET @PublicacionID = (SELECT publicacion_id
						  FROM SQLITO.Ubicaciones
						  WHERE id_ubicacion = @UbicacionComprada)
	SET @CantidadUbicaciones = (SELECT COUNT(*)
								FROM SQLITO.Publicaciones
									JOIN SQLITO.Ubicaciones ON (publicacion_id = cod_publicacion)
								WHERE cod_publicacion = @PublicacionID
								GROUP BY cod_publicacion)
	SET @CantidadCompradas = (SELECT COUNT(*)
							  FROM SQLITO.Publicaciones AS P
								JOIN SQLITO.Ubicaciones AS U ON (U.publicacion_id = P.cod_publicacion)
							    LEFT JOIN SQLITO.Compras AS C ON (C.ubicacion_id = U.id_ubicacion)
							  WHERE (cod_publicacion = @PublicacionID)
								AND (U.id_ubicacion IN (SELECT C1.ubicacion_id
														FROM SQLITO.Compras AS C1)))

	--Si todas las ubicaciones fueron compradas (las cantidades coinciden) marco la publicacion como finalizada
	IF @CantidadCompradas = @CantidadUbicaciones
	BEGIN
		UPDATE SQLITO.Publicaciones
		SET estado_id = 3
		WHERE cod_publicacion = @PublicacionID
	END
							
END
GO

--PROC PARA ELIMINAR EMPRESA -> DESHABILITA SU USUARIO -> HAY QUE AGREGAR EL NUEVO FLAG DE EMPRESA HABILITADA
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Eliminar_empresa')
BEGIN
	DROP PROCEDURE pr_Eliminar_empresa
END
GO
create proc pr_Eliminar_empresa (@idEmpresa int)
as
begin
begin try
DECLARE @ID_USER INT
SET @ID_USER = (SELECT usuario_id FROM SQLITO.Empresas WHERE id_empresa = @idEmpresa)
begin transaction
UPDATE SQLITO.Usuarios SET habilitado = 0 WHERE id_usuario = @ID_USER
commit transaction
end try
begin catch
ROLLBACK TRAN
SELECT ERROR_MESSAGE()
end catch
end
GO

--PROC PARA CREAR UN GRADO
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Carga_Grado')
BEGIN
	DROP PROCEDURE pr_Carga_Grado
END
GO
create proc pr_Carga_Grado (@descripcion nvarchar(255),@comision numeric(6,2))
as
begin
begin try
DECLARE @identity numeric(18,0)
SET @identity = (select count(*) from SQLITO.Grados)

--Descripcion ya existente
IF EXISTS(select 1 from SQLITO.Grados WHERE descripcion = @descripcion)
THROW 50000, 'DESCRIPCION YA EXISTENTE', 1

begin transaction
INSERT INTO SQLITO.Grados(descripcion,comision) values(@descripcion,@comision)
commit transaction
end try
begin catch
DECLARE @Cambios numeric(18,0)
SET @Cambios = (select count(*) from SQLITO.Grados)
IF(@identity != @Cambios)
BEGIN
ROLLBACK TRAN
DBCC CHECKIDENT ('SQLITO.Grados', RESEED, @identity) WITH NO_INFOMSGS;
END;
THROW
end catch
end
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Mod_Grado')
BEGIN
	DROP PROCEDURE pr_Mod_Grado
END
GO

CREATE proc pr_Mod_Grado(@descripcion nvarchar(255), 
    @comision numeric(6,2),
    @habilitado bit,
	@idGrado int)
as
begin

--Descripcion repetida y no existente
IF EXISTS (select 1 from SQLITO.Grados where descripcion = @descripcion and id_grado != @idGrado)
THROW 50000, 'DESCRIPCION YA REGISTRADA', 1

begin try
begin transaction
update [GD2C2018].[SQLITO].Grados set descripcion = @descripcion,comision =@comision,habilitado=@habilitado where id_grado = @idGrado
commit transaction
end try

begin catch
IF @@ROWCOUNT != 0  
ROLLBACK TRANSACTION
THROW
end catch

END
GO
/*Si llegase a romper el identity usar:
GO
DBCC CHECKIDENT ('SQLITO.nomTabla', RESEED, ultimoValorTabla);
GO
*/ 

IF OBJECT_ID('[SQLITO].[sumarPuntos]') IS NOT NULL
BEGIN
	DROP FUNCTION [SQLITO].[sumarPuntos]
END
GO

CREATE FUNCTION [SQLITO].[sumarPuntos]
(@cliente INT)
RETURNS INT
BEGIN 
	DECLARE @puntos INT
	SET @puntos = (SELECT TOP (1) ISNULL(SUM(ISNULL(cantidad,0)),0) 
					FROM SQLITO.Puntos  
					WHERE (cliente_id = @cliente AND fecha_vencimiento IS NULL) OR (cliente_id = @cliente AND fecha_vencimiento > (SELECT CAST (GETDATE() AS SMALLDATETIME))))
					
	IF(@puntos<0)
	BEGIN 
	SET @puntos = 0
	END
  RETURN @puntos
END
GO


--AGREGADO PROCS APP

USE [GD2C2018]
GO
--PROC ALTA USUARIOS PARA EMPRESAS YA IMPORTADAS DEL MASTER
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_altaUsuario_empresa')
BEGIN
	DROP PROCEDURE [pr_altaUsuario_empresa]
END
GO
CREATE PROCEDURE [dbo].[pr_altaUsuario_empresa] (@empresaID INT, @empresaRazonSocial nvarchar(255),@cuit nvarchar(255))
AS
BEGIN
BEGIN TRY
	DECLARE @username NVARCHAR(255), @password VARBINARY(255)
	DECLARE @identity numeric(18,0)
	SET @identity = (select count(*) from SQLITO.Usuarios)
	--Asigno US and PW
BEGIN TRANSACTION
	SELECT @username = @empresaRazonSocial,@password = HASHBYTES('SHA2_256',@cuit) 
	
	INSERT INTO SQLITO.Usuarios (username, password, contraseniaActivada) VALUES (@username, @password, 0)
	INSERT INTO SQLITO.Roles_Usuarios (rol_id, usuario_id)VALUES (1,SCOPE_IDENTITY()) 

COMMIT TRANSACTION
	--Retorno el Id del usuario
	RETURN (select COUNT(*) FROM SQLITO.Usuarios)
END TRY
BEGIN CATCH
rollback transaction
DBCC CHECKIDENT ('SQLITO.Usuarios', RESEED,@identity);
THROW 50000, 'FALLO CREACION USUARIO', 1
END CATCH
END
GO

--PROC PARA ALTA EMPRESAS 
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Alta_Empresa')
BEGIN
	DROP PROCEDURE pr_Alta_Empresa
END
GO
CREATE proc [dbo].[pr_Alta_Empresa](@razonsocial nvarchar(255), 
    @cuit nvarchar(255),
    @mail nvarchar(50),
    @direccion nvarchar(255),
    @telefono nvarchar(30))
as
begin
DECLARE @fecha_creacion datetime
DECLARE @usuario_id int
DECLARE @id_Empresa int
DECLARE @identity numeric(18,0)
SET @identity = (select count(*) from SQLITO.Empresas)

--Razon Social Repetida
IF EXISTS (select 1 from SQLITO.Empresas where razonsocial = @razonsocial)
THROW 50000, 'RAZON SOCIAL YA EXISTENTE', 1

--Cuit Repetido
IF Exists(select 1 from SQLITO.Empresas where cuit = @cuit)
THROW 50000, 'CUIT YA EXISTENTE', 1

--Cuit Repetido
IF Exists(select 1 from SQLITO.Empresas where mail = @mail)
THROW 50000, 'MAIL YA EXISTENTE', 1
 
SET @fecha_creacion = GETDATE()
SET @id_Empresa =  (select COUNT(*) + 1 FROM SQLITO.Empresas)

begin try
begin transaction
EXEC @usuario_id = pr_altaUsuario_empresa @id_Empresa, @razonsocial, @cuit
insert into [GD2C2018].[SQLITO].[Empresas](razonsocial,fecha_creacion,cuit,mail,direccion,telefono,usuario_id) values (@razonsocial,@fecha_creacion,@cuit,@mail,@direccion,@telefono,@usuario_id)
commit transaction

end try

begin catch
DECLARE @Cambios numeric(18,0)
SET @Cambios = (select count(*) from SQLITO.Grados)
--Se detectan cambios
IF(@identity != @Cambios)
BEGIN
ROLLBACK TRANSACTION
SET @id_Empresa = @id_Empresa - 1
DBCC CHECKIDENT ('SQLITO.Usuarios', RESEED,@id_Empresa) WITH NO_INFOMSGS;
DBCC CHECKIDENT ('SQLITO.Empresas', RESEED,@identity) WITH NO_INFOMSGS;
END;
THROW
end catch

END

GO

--PROC PARA MODIFICAR EMPRESAS 
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Modificar_Empresa')
BEGIN
	DROP PROCEDURE pr_Modificar_Empresa
END
GO
CREATE proc [dbo].[pr_Modificar_Empresa](@razonsocial nvarchar(255), 
    @cuit nvarchar(255),
    @mail nvarchar(50),
    @direccion nvarchar(255),
    @telefono nvarchar(30),
	@idEmpresa int)
as
begin
--Razon Social Repetida que no es la misma que la que se inserta
IF EXISTS (select 1 from SQLITO.Empresas where razonsocial = @razonsocial AND id_empresa != @idEmpresa)
THROW 50000, 'RAZON SOCIAL YA EXISTENTE', 1

--Cuit Repetido que no es el mismo que se inserta
IF Exists(select 1 from SQLITO.Empresas where cuit = @cuit AND id_empresa != @idEmpresa)
THROW 50000, 'CUIT YA EXISTENTE', 1

--Cuit Repetido
IF Exists(select 1 from SQLITO.Empresas where mail = @mail AND id_empresa != @idEmpresa)
THROW 50000, 'MAIL YA EXISTENTE', 1
 
begin try
begin transaction
update [GD2C2018].[SQLITO].[Empresas] set razonsocial = @razonsocial,cuit =@cuit,mail=@mail,direccion=@direccion,telefono=@telefono where id_empresa =@idEmpresa
commit transaction
end try

begin catch
IF @@ROWCOUNT != 0  
ROLLBACK TRANSACTION
THROW
end catch

END

--PROC PARA ELIMINAR EMPRESA -> DESHABILITA SU USUARIO -> HAY QUE AGREGAR EL NUEVO FLAG DE EMPRESA HABILITADA
GO
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Eliminar_empresa')
BEGIN
	DROP PROCEDURE pr_Eliminar_empresa
END
GO
create proc pr_Eliminar_empresa (@idEmpresa int)
as
begin
begin try
DECLARE @ID_USER INT
SET @ID_USER = (SELECT usuario_id FROM SQLITO.Empresas WHERE id_empresa = @idEmpresa)
begin transaction
UPDATE SQLITO.Usuarios SET habilitado = 0 WHERE id_usuario = @ID_USER
commit transaction
end try
begin catch
ROLLBACK TRAN
SELECT ERROR_MESSAGE()
end catch
end
GO

--PROC PARA CREAR UN GRADO
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Carga_Grado')
BEGIN
	DROP PROCEDURE pr_Carga_Grado
END
GO
create proc pr_Carga_Grado (@descripcion nvarchar(255),@comision numeric(6,2))
as
begin
begin try
DECLARE @identity numeric(18,0)
SET @identity = (select count(*) from SQLITO.Grados)

--Descripcion ya existente
IF EXISTS(select 1 from SQLITO.Grados WHERE descripcion = @descripcion)
THROW 50000, 'DESCRIPCION YA EXISTENTE', 1

begin transaction
INSERT INTO SQLITO.Grados(descripcion,comision) values(@descripcion,@comision)
commit transaction
end try
begin catch
DECLARE @Cambios numeric(18,0)
SET @Cambios = (select count(*) from SQLITO.Grados)
IF(@identity != @Cambios)
BEGIN
ROLLBACK TRAN
DBCC CHECKIDENT ('SQLITO.Grados', RESEED, @identity) WITH NO_INFOMSGS;
END;
THROW
end catch
end
GO
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'pr_Mod_Grado')
BEGIN
	DROP PROCEDURE pr_Mod_Grado
END
GO
CREATE proc pr_Mod_Grado(@descripcion nvarchar(255), 
    @comision numeric(6,2),
    @habilitado bit,
	@idGrado int)
as
begin

--Descripcion repetida y no existente
IF EXISTS (select 1 from SQLITO.Grados where descripcion = @descripcion and id_grado != @idGrado)
THROW 50000, 'DESCRIPCION YA REGISTRADA', 1

begin try
begin transaction
update [GD2C2018].[SQLITO].Grados set descripcion = @descripcion,comision =@comision,habilitado=@habilitado where id_grado = @idGrado
commit transaction
end try

begin catch
IF @@ROWCOUNT != 0  
ROLLBACK TRANSACTION
THROW
end catch

END
GO

/*Si llegase a romper el identity usar:
DBCC CHECKIDENT ('SQLITO.nomTabla', RESEED, ultimoValorTabla);
GO
*/ 