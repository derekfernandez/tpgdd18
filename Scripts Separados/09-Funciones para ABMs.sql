--- FUNCIONES PARA LLAMAR DESDE C# EN LOS ABMs ---

/*NO TERMINADA

CREATE PROCEDURE [SQLITO].[obtenerTops_empresasMenosVendedoras]
				 (@anio INT, @trimestre INT, @grado INT)
AS
BEGIN
	
	IF OBJECT_ID('SQLITO.#Temp_EmpresasMalas') IS NULL
	BEGIN

		CREATE TABLE [SQLITO].[#Temp_EmpresasMalas] (
			[id_malaEmpresa] INT PRIMARY KEY,
			[empresa_razonsocial] NVARCHAR(255),
			[cantidadnovendidas] INT
		)
		PRINT('Tabla temporal de Peores Empresas creada')

	END

	ELSE
	BEGIN
		DELETE FROM [SQLITO].[#Temp_EmpresasMalas]
		PRINT('Tabla temporal de Peores Empresas vaciada')
	END

	INSERT INTO [SQLITO].[#Temp_EmpresasMalas] (id_malaEmpresa, empresa_razonsocial, cantidadnovendidas)
	SELECT id_empresa,
	   razonsocial,
	   COUNT(*) AS UbicacionesNoVendidas
	FROM [SQLITO].[Empresas]
		JOIN [SQLITO].[Publicaciones] ON (empresa_id = id_empresa)
		JOIN [SQLITO].[Ubicaciones] ON (publicacion_id = cod_publicacion)
	WHERE id_ubicacion NOT IN (SELECT ubicacion_id
						   	   FROM [SQLITO].[Compras])
	GROUP BY id_empresa, razonsocial
	ORDER BY UbicacionesNoVendidas DESC

END*/