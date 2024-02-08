/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Add a product
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_Insert]
	@SKU VARCHAR(255),
	@Title VARCHAR(50),
	@Description VARCHAR(200),
	@BuyerId INT,
	@IsActive BIT,
	@UpdatedBy INT
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM dbo.Product WHERE SKU = @SKU)
	BEGIN
		INSERT INTO dbo.Product ([SKU], [Title], [Description], [BuyerId], [IsActive], [UpdatedBy], [UpdatedDate])
		VALUES (@SKU, @Title, @Description, @BuyerId, @IsActive, @UpdatedBy, GETDATE())
	END
END

