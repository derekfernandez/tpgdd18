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
	           ('Pausada')

PRINT('Datos insertados en la tabla SQLITO.EstadosPublicacion')
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
		  ('Camiseta Retro Argentina 86 Le Coq Sportif', 4000,10),
		  ('Viaje a Tahiti 5 Noches',21000,5),
		  ('Entradas Cinemark',500,200),
		  ('Red Dead Redemption 2', 2425, 40),
		  ('Cena P/2 en Parrilla Los Hermanos', 1850, 10),
		  ('Dia de Spa', 2000, 10),
		  ('Entradas Temaiken',850,150)

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
	VALUES ('Baja', 4), ('Media', 6), ('Alta', 9)

END	
GO

PRINT ('Datos insertados en la tabla SQLITO.Grados')

--Herramienta para limpiar la tabla y resetear el contador de un IDENTITY en n

/*
*DELETE FROM [SQLITO].[NombreTabla]
*DBCC CHECKIDENT ('[SQLITO].[NombreTabla]', RESEED, n)
*/