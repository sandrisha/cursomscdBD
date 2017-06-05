SELECT 
	Marcas.denominacion as denominacionMarca
	,Coches.matricula as denominacionMatricula	
	,Coches.nPlazas as denominacionnPlazas
		
    FROM Marcas, Coches
	
	GROUP BY 
	Marcas.denominacion    
    , Coches.matricula
	, Coches.nPlazas 
    ORDER BY Marcas.denominacion,  Coches.matricula, Coches.nPlazas