INSERT INTO SettlementType (Name)
SELECT DISTINCT SettlementTypeName
	FROM ZipCodeBase
WHERE NOT EXISTS (SELECT 1 FROM SettlementType)

INSERT INTO Municipality (Name, Key, StateId)
SELECT DISTINCT ZCB.MunicipalityName, ZCB.MunicipalityKey, S.Id
FROM ZipCodeBase ZCB
	INNER JOIN State S ON S.Name = ZCB.StateName
WHERE NOT EXISTS (SELECT 1 FROM Municipality);

INSERT INTO ZipCode (Na)

INSERT INTO Settlement (Name, SettlementTypeId, ZipCodeId)
SELECT ZCB.SettlementName, ST.Id, 
FROM ZipCodeBase ZCB
	INNER JOIN SettlementType ST ON ST.Name = ZCB.SettlementName
WHERE NOT EXISTS (SELECT 1 FROM Settlement)

SELECT * FROM SettlementType;
SELECT * FROM Municipality;