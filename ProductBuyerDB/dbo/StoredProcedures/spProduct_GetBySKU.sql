/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/6/2024
	UpdateDate: 2/6/2024
	Notes: Get a product by SKU to verify being unique
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_GetBySKU]
	@SKU VARCHAR(255)
AS
BEGIN
	SELECT [ProductId], [SKU], [Title], [Description], [BuyerId], [IsActive], [UpdatedBy], [UpdatedDate] FROM dbo.Product
	WHERE SKU = @SKU
END
