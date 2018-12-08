--- FUNCIONES PARA LLAMAR DESDE C# EN LOS ABMs ---

--Para ABM de Estadisticas--

--Llenar tabla temporal con empresas con mas localidades no vendidas
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'estadistica_empresasMenosVendedoras')
BEGIN

	DROP PROCEDURE estadistica_empresasMenosVendedoras

END
GO

CREATE PROCEDURE estadistica_empresasMenosVendedoras
				 (@anio INT, @trimestre INT, @grado INT)
AS
BEGIN
	
	SELECT TOP 5 E.razonsocial,
	       COUNT(*)
	FROM [SQLITO].[Empresas] AS E
		JOIN [SQLITO].[Publicaciones] AS P ON (empresa_id = id_empresa)
		JOIN [SQLITO].[Ubicaciones] AS U ON (publicacion_id = cod_publicacion)
		LEFT JOIN [SQLITO].[Compras] AS C ON (ubicacion_id = id_ubicacion)
	WHERE id_ubicacion NOT IN (SELECT ubicacion_id
						   	   FROM [SQLITO].[Compras])
		AND (DATEPART(QUARTER, P.fecha_funcion) = @trimestre)
		AND (YEAR(P.fecha_funcion) = @anio)
		AND (P.grado_id = @grado)
	GROUP BY id_empresa, razonsocial
	ORDER BY COUNT(*) DESC

END
GO


--Llenar tabla temporal con clientes con mayor cantidad de puntos vencidos
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'estadistica_clientesConMasPuntosVencidos')
BEGIN

	DROP PROCEDURE estadistica_clientesConMasPuntosVencidos

END
GO

CREATE PROCEDURE estadistica_clientesConMasPuntosVencidos
				 (@anio INT, @trimestre INT)
AS
BEGIN

	--Creo una variable para almacenar el primer dia del trimestre y del añp ingresados
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