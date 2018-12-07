--- FUNCIONES PARA LA MIGRACION ---

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
	SET @direccion = @calle + ' ' + CONVERT(NVARCHAR(18), @altura) +
					 ' ' + CONVERT(NVARCHAR(18), @piso) + 'º' + @depto +
					 ', ' + @localidad + ', CP: ' + @cp
	RETURN @direccion
END
GO

--No utilizada por ahora
IF OBJECT_ID('[SQLITO].[obtenerIDdeUbicacion]') IS NOT NULL
BEGIN
	DROP FUNCTION [SQLITO].[obtenerIDdeUbicacion]
END
GO

CREATE FUNCTION [SQLITO].[obtenerIDdeUbicacion]
(@publicacion INT, @fila NVARCHAR(3), @asiento NUMERIC(6,0))
RETURNS INT
BEGIN
	DECLARE @id INT
	SET @direccion = SELECT id_ubicacion
					 FROM SQLITO.Ubicaciones
					 WHERE publicacion_id = @publicacion
					 AND asiento = @asiento
					 AND fila = @fila
	RETURN @id
END
GO


/* CODIGOS DE PRUEBA
SELECT [SQLITO].[obtenerDireccion](Espec_Empresa_Dom_Calle, Espec_Empresa_Nro_Calle, Espec_Empresa_Piso, Espec_Empresa_Depto, '', Espec_Empresa_Cod_Postal)
FROM gd_esquema.Maestra
SELECT [SQLITO].[obtenerDireccion](Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, '', Cli_Cod_Postal)
FROM gd_esquema.Maestra
*/