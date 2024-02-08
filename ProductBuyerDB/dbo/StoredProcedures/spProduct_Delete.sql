/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Delete a product by ProductId
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_Delete]
	@ProductId int
AS
BEGIN
	INSERT INTO dbo.ProductArchived
	SELECT [ProductId], [SKU], [Title], [Description], [BuyerId], [IsActive], 0, GETDATE() FROM dbo.Product
	WHERE ProductId = @ProductId;

	DELETE FROM dbo.Product
	WHERE ProductId = @ProductId;
END

