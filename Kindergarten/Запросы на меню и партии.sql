﻿

--SELECT 
--DT.Name
--,DD.Quantity
--,P.Name
--,DD.DateCreated
--,S.Name
--FROM DocumentData AS DD
--LEFT JOIN
--Documents AS D
--ON
--D.Id = DD.DocumentId

--LEFT JOIN
--DocumentTypes AS DT
--ON
--DT.Id = D.DocumentTypeId

--LEFT JOIN
--Products AS P
--ON
--P.Id = DD.ProductId

--LEFT JOIN
--Invoices AS I
--ON
--I.ID = D.InvoiceId

--LEFT JOIN
--Suppliers AS S
--ON
--S.Id = I.SupplierId

SELECT
M.Name
,D.Name
,D.DishNurseryNorm
,D.DishYardNorm
,P.Name
,DI.NurseryNorm
,DI.YardNorm
FROM DishItems AS DI

LEFT JOIN
Dishes AS D
ON
D.Id = DI.DishId

LEFT JOIN
Menus AS M
ON
M.Id = D.MenuId

LEFT JOIN
Products AS P
ON
P.Id = DI.ProductId


SELECT 
MF.Name,
DF.Name,
P.Name,
DIF.NurseryNorm,
DIF.YardNorm
FROM DishItemFacts AS DIF

LEFT JOIN
DishFacts AS DF
ON
DIF.DishFactId = DF.Id

LEFT JOIN
MenuFacts AS MF
ON
MF.Id = DF.MenuFactId

LEFT JOIN
Products AS P
ON
P.Id = DIF.ProductId

ORDER BY DF.Id, DIF.Id


