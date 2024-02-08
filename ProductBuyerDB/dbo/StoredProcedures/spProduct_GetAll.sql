/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Get all products
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	SELECT [ProductId], [SKU], [Title], [Description], T1.[BuyerId], T2.[BuyerName], T1.[IsActive], T1.[UpdatedBy], T1.[UpdatedDate] 
	FROM dbo.Product T1
	INNER JOIN dbo.Buyer T2 ON T1.BuyerId = T2.BuyerId
END

