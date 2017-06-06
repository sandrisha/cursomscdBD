-- CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE GET_COCHE_POR_MARCA
AS
BEGIN
    SELECT 
	Marcas.denominacion as denominacionMarca
	,TiposCombustible.denominacion as denominacionTiposCombustible
	,Coches.idMarca, Coches.idTipoCombustible
	,Coches.id, Coches.matricula, Coches.color 
	,Coches.nPlazas, Coches.fechaMatriculacion, Coches.cilindrada
	
	
    FROM Marcas
        INNER JOIN Coches on Marcas.id = Coches.idMarca
		INNER JOIN TiposCombustible on Coches.idTipoCombustible = TiposCombustible.id   
	GROUP BY 
	Marcas.denominacion
    , TiposCombustible.denominacion
    , Coches.idMarca
    , Coches.idTipoCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
	ORDER BY Marcas.denominacion
END

-- MOSTRAR COLUMNAS COCHE POR MARCA, MATRICULA, Nº DE PLAZAS
ALTER PROCEDURE GET_COCHE_POR_MARCA_MATRICULA_PLAZAS
AS
BEGIN
    SELECT 
         M.denominacion as Marca
        ,C.matricula
        ,C.nPlazas
    FROM Marcas M
        INNER JOIN Coches C ON M.id = C.idMarca
    GROUP BY 
         M.denominacion
        ,C.matricula
        ,C.nPlazas
    ORDER BY nPlazas 
END

-- MOSTRAR COLUMNAS COCHE POR MARCA, MATRICULA, Nº DE PLAZAS 2
ALTER PROCEDURE GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2
	-- Pasar parámetros
	-- =NULL hace que el valor se convierta en opcional
	@marca nvarchar(50) = NULL
	, @nPlazas smallint = NULL
AS
BEGIN
    SELECT 
         M.denominacion as Marca
        ,C.matricula
        ,C.nPlazas
    FROM Marcas M
        INNER JOIN Coches C ON M.id = C.idMarca
	WHERE  
		(M.denominacion LIKE '%' + @marca + '%' OR @marca is null)
		--hacer que siempre que sea verdadero
    and (C.nPlazas >= @nPlazas OR @nPlazas is null)
		
	AND C.nPlazas >= @nPlazas
    
    ORDER BY nPlazas
END

-- MOSTRAR COLUMNAS COCHE POR ID COCHE CON PARÁMETRO
ALTER PROCEDURE [dbo].[GET_COCHE_POR_MARCA_ID]
	@id bigint
AS
BEGIN
SELECT 
	  Marcas.denominacion as denominacionMarca
	, TiposCombustible.denominacion as denominacionTipoCombustible
	, Coches.idMarca
	, Coches.idTipoCombustible
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, Coches.cilindrada
FROM Marcas
	INNER JOIN Coches on Marcas.id = Coches.idMarca
	INNER JOIN TiposCombustible on Coches.idTipoCombustible = TiposCombustible.id
WHERE Coches.id = @id
GROUP BY 
	  Marcas.denominacion
	, TiposCombustible.denominacion
	, Coches.idMarca
	, Coches.idTipoCombustible
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, Coches.cilindrada
ORDER BY Marcas.denominacion
END

-- CREAR PROCEDIMIENTO PARA OBTENER LA LISTA DE MARCAS
ALTER PROCEDURE GetMarcas
AS
BEGIN
	SELECT id, denominacion FROM Marcas
END

-- CREAR PROCEDIMIENTO PARA OBTENER LA LISTA DE MARCAS POR ID
ALTER PROCEDURE GetMarcasPorId
	@id bigint = NULL
AS
BEGIN
	SELECT id, denominacion FROM Marcas
	WHERE Marcas.id = @id
END