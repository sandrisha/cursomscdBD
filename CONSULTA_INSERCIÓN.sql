-- CONSULTAS PARA HACER INSERCIONES EN UNA TABLA

INSERT INTO ServiceImages (IdService, imageUrl)
VALUES ('C2133C0A-06C4-4DF8-A862-9EB1A9D63825', 'http://')

-- CONSULTA PARA INSERCIONES MASIVAS INSERT - SELECT
INSERT INTO ServiceImages (IdService, imageUrl)
SELECT IdService, imageUrl FROM ServiceImages


-- CREAR UNA TABLA TEMPORAL A PARTIR DE UNA SELECT
SELECT *  INTO ServiceImagesTemporal FROM ServiceImages