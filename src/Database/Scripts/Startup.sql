DELETE FROM ZipCodeBase WHERE '' IN (CityName, MunicipalityName, SettlementName, StateName);

INSERT INTO Municipality (Name, Key, StateId)
SELECT DISTINCT ZCB.MunicipalityName, ZCB.MunicipalityKey, S.Id
FROM ZipCodeBase ZCB
	INNER JOIN State S ON S.Name = ZCB.StateName
WHERE NOT EXISTS (SELECT 1 FROM Municipality);

INSERT INTO SettlementType (Name)
SELECT DISTINCT SettlementTypeName
	FROM ZipCodeBase
WHERE NOT EXISTS (SELECT 1 FROM SettlementType);

INSERT INTO Settlement (Name, SettlementTypeId)
SELECT DISTINCT ZCB.SettlementName, ST.Id
FROM ZipCodeBase ZCB
	INNER JOIN SettlementType ST ON ST.Name = ZCB.SettlementTypeName
WHERE NOT EXISTS (SELECT 1 FROM Settlement);

INSERT INTO City (Name, Key)
SELECT DISTINCT CityName, CityKey
	FROM ZipCodeBase
WHERE NOT EXISTS (SELECT 1 FROM City);

INSERT INTO ZipCode (
	Code, StateId, MunicipalityId,
	SettlementId, CityId, IsUrban
)
SELECT ZCB.Code, S.Id AS StateId, M.Id AS MunicipalityId,
	SE.Id AS SettlementId, C.Id AS CityId, ZoneAddress = 'Urbano'
FROM ZipCodeBase ZCB
	INNER JOIN Municipality M ON M.Name = ZCB.MunicipalityName AND M.Key = ZCB.MunicipalityKey
	INNER JOIN State S ON S.Id = M.StateId AND S.Id = ZCB.StateKey
	INNER JOIN Settlement SE ON SE.Name = ZCB.SettlementName
	INNER JOIN SettlementType ST ON ST.Id = SE.SettlementTypeId AND ST.Name = ZCB.SettlementTypeName
	INNER JOIN City C ON C.Name = ZCB.CityName AND C.Key = ZCB.CityKey
WHERE NOT EXISTS (SELECT 1 FROM ZipCode);

DELETE FROM ZipCodeBase;

VACUUM;