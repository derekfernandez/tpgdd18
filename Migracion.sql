USE [GD2C2018]
GO

--- CREACION DE ESQUEMA ---


IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'SQLITO')
BEGIN
	
	EXEC('CREATE SCHEMA [SQLITO] AUTHORIZATION [gdEspectaculos2018]')
	PRINT 'Esquema Creado'
END
GO


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
		[cliente_id] [int],
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
		[cuil] [nvarchar] (13) CHECK ([cuil] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]' OR 
			[cuil] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]'),
		[tipo_documento] [nvarchar] (3) CHECK ([tipo_documento] IN ('DNI','LC','LE','CI')),
		[numero_documento] [numeric] (8,0) CHECK (LEN([numero_documento]) <= 8),
		[fecha_nacimiento] [datetime] NOT NULL,
		--Puede ser NULL, los Clientes de la tabla maestra no tienen este campo
		[fecha_creacion] [datetime],
		--Puede ser NULL si un Cliente no tiene tarjetas registradas a su nombre
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
		[empresa_id] [int]
		--La descripcion del medio de pago no iria aca? O es fija de cada empresa?
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
		[disponible] [bit] DEFAULT 1,
		[publicacion_id] [numeric] (18,0)
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
		[cod_publicacion] [numeric] (18,0) PRIMARY KEY NOT NULL,
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
		[cuit] [nvarchar] (13) CHECK ([cuit] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]' OR 
			[cuit] LIKE '[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]'),
		--Id del usuario al cual esta asociada la cuenta de la Empresa
		[usuario_id] [int],
		/* Agrego un campo para migrar forma_pago_desc, si no es correcto se cambia */
		[medio_pago_comision] [nvarchar] (30)
	)

PRINT('Tabla SQLITO.Empresas creada')

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios'
	AND TABLE_SCHEMA = 'SQLITO')

BEGIN

	CREATE TABLE [SQLITO].[Usuarios] (
		
		[id_usuario] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[username] [nvarchar](30),
		[password] [nvarchar](30),
		--Mail, direccion, zona y telefono pueden ser NULL en el administrador
		[mail] [nvarchar](50),
		[direccion] [nvarchar](255),
		[zona] [nvarchar](80),
		[telefono] [nvarchar](20),
		[intentos_fallidos] [int] DEFAULT 0,
		--1 es habilitado, 0 es inhabilitado
		[estado] [bit] DEFAULT 1,
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
               WHERE CONSTRAINT_NAME ='FK_Premios_Usuarios')

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



IF ((SELECT COUNT(*)
     FROM [SQLITO].[TiposUbicacion]) = 0)
BEGIN

	INSERT INTO [SQLITO].[TiposUbicacion]
		(id_tipo,descripcion)
	VALUES (4446, 'Platea Alta'),
		   (4447, 'Platea Baja'),
		   (4448, 'Vip'),
	       (4449, 'Campo'),
	       (4450, 'Campo Vip'),
	       (4451, 'PullMan'),
	       (4452, 'Super PullMan'),
	       (4453, 'Cabecera'),
	       (4454, 'S/N')

PRINT('Datos insertados en la tabla TiposUbicacion')
END
GO

IF ((SELECT COUNT(*)
     FROM [SQLITO].[EstadosPublicacion]) = 0)
BEGIN

	INSERT INTO [SQLITO].[EstadosPublicacion]
		(descripcion)
	VALUES ('Borrador'),
		   ('Publicada'),
		   ('Finalizada'),
	       ('Pausada')

PRINT('Datos insertados en la tabla EstadosPublicacion')
END
GO


--Para limpiar la tabla y resetear el contador de IDENTITY en 0

DELETE FROM [SQLITO].[EstadosPublicacion]
DBCC CHECKIDENT ('[SQLITO].[EstadosPublicacion]', RESEED, 0)
GO

-- INSERTS --

INSERT INTO SQLITO.Compras (cliente_id, ubicacion_id, valor_entrada, tarjeta_id, cantidad_entradas, cantidad_puntos)
SELECT c.id_cliente, u.id_ubicacion, Ubicacion_Precio*Compra_Cantidad, Compra_cantidad, c.tarjeta_id, null
FROM gd_esquema.Maestra gdm
JOIN SQLITO.Clientes c ON c.numero_documento = gdm.Cli_Dni
JOIN SQLITO.Publicaciones p ON p.cod_publicacion = gdm.Espectaculo_Cod
JOIN SQLITO.Ubicaciones u ON u.fila = gdm.Ubicacion_Fila AND u.asiento = gdm.Ubicacion_Asiento
WHERE Compra_Fecha IS NOT NULL

PRINT('Datos insertados en la tabla Compras')
GO

INSERT INTO SQLITO.Facturas (numero_factura,fecha_emision,total,empresa_id)
SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total, e.id_empresa
FROM gd_esquema.Maestra gdm
JOIN SQLITO.Empresas e ON gdm.Espec_Empresa_Cuit = e.cuit
WHERE Factura_Nro IS NOT NULL
PRINT('Datos insertados en la tabla Facturas')
GO

INSERT INTO SQLITO.Publicaciones (cod_publicacion,descripcion,fecha_creacion,fecha_vencimiento,
	fecha_funcion,direccion,empresa_id,grado_id,rubro_id,estado_id)
SELECT DISTINCT Espectaculo_Cod, Espectaculo_Descripcion, Espec_Empresa_Fecha_Creacion, Espectaculo_Fecha_Venc,
	Espectaculo_Fecha, null, r.id_rubro, Espectaculo_Estado 
FROM gd_esquema.Maestra gdm
JOIN SQLITO.Rubros r ON r.descripcion = gdm.Espectaculo_Rubro_Descripcion
PRINT('Datos insertados en la tabla Publicaciones')
GO

INSERT INTO SQLITO.Ubicaciones (fila,asiento,tipo_id,precio,disponible,publicacion_id)
SELECT Ubicacion_Fila, Ubicacion_Asiento, t.id_tipo, Ubicacion_Precio, null,p.cod_publicacion 
FROM gd_esquema.Maestra gmd
JOIN SQLITO.TiposUbicacion t ON t.id_tipo = gmd.Ubicacion_Tipo_Codigo
JOIN SQLITO.Publicaciones p ON p.cod_publicacion = Espectaculo_Cod
PRINT('Datos insertados en la tabla Ubicaciones')
GO

INSERT INTO SQLITO.Grados (descripcion,comision)
VALUES ('Alta',9), ('Media',5),('Baja',3)
PRINT('Datos insertados en la tabla Grados')
GO

INSERT INTO SQLITO.Rubros (descripcion)
SELECT DISTINCT Espectaculo_Rubro_Descripcion
FROM gd_esquema.Maestra
PRINT('Datos insertados en la tabla Rubros')
GO

INSERT INTO SQLITO.Empresas(razonsocial,fecha_creacion,cuit,usuario_id,medio_pago_comision)
SELECT DISTINCT Espec_Empresa_Razon_Social,Espec_Empresa_Fecha_Creacion,Espec_Empresa_Cuit, u.id_usuario, Forma_Pago_Desc
FROM gd_esquema.Maestra gdm
JOIN SQLITO.Usuarios u ON u.mail = gdm.Espec_Empresa_Mail
PRINT('Datos insertados en la tabla Empresas')
GO

-- DEJO ESTO POR SI TE SIRVE PARA USUARIOS --

--TODOS LOS MAILS--

SELECT DISTINCT Espec_Empresa_Mail FROM gd_esquema.Maestra UNION SELECT DISTINCT Cli_Mail FROM gd_esquema.Maestra)

--TODOS LOS DOMICILIOS FORMATEADOS--

SELECT DISTINCT(Espec_Empresa_Dom_Calle + ' ' + CAST(Espec_Empresa_Nro_Calle AS VARCHAR) + ' ' + CAST(Espec_Empresa_Piso AS VARCHAR)
	 + ' ' + Espec_Empresa_Depto + ' ' + CAST(Espec_Empresa_Cod_Postal AS VARCHAR)) FROM gd_esquema.Maestra 
	UNION
	SELECT DISTINCT(Cli_Dom_Calle + ' ' + CAST(Cli_Nro_Calle AS VARCHAR) + ' ' + CAST(Cli_Piso AS VARCHAR)
	 + ' ' + Cli_Depto + ' ' + CAST(Cli_Cod_Postal AS VARCHAR)) FROM gd_esquema.Maestra

/* FALTAN ITEMSFACTURA, CLIENTES, PUNTOS, PREMIOS, USUARIOS, TARJETAS, ROL-USUARIO, ROL,
* ROL-FUNCIONALIDAD, FUNCIONALIDAD
* CUANDO ESTEN TODOS LOS INSERTS RECIEN SE PUEDE PROBAR POR EL TEMA DE LOS JOIN Y HAY QUE EJECUTARLOS EN UN
* ORDEN DETERMINADO
*/