/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Update a product
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_Update]
	@ProductId INT,
	@SKU VARCHAR(255),
	@Title VARCHAR(50),
	@Description VARCHAR(200),
	@BuyerId INT,
	@IsActive BIT,
	@UpdatedBy INT,
	@Message VARCHAR(100)
AS
BEGIN
	DECLARE @OldBuyerId INT=0;

	SELECT @OldBuyerId = BuyerId FROM dbo.Product WHERE [ProductId] = @ProductId;
	 
	UPDATE dbo.Product 
	SET [SKU] = @SKU, 
		[Title] = @Title, 
		[Description] = @Description, 
		[BuyerId] = @BuyerId, 
		[IsActive] = @IsActive, 
		[UpdatedBy] = @UpdatedBy, 
		[UpdatedDate] = GETDATE()
	WHERE [ProductId] = @ProductId;

	IF (@BuyerId=@OldBuyerId)
		SET @BuyerId = null;

	INSERT INTO dbo.ProductUpdateHistory ([ProductId], [BuyerId], [NewBuyerId], [Message], [UpdatedBy], [UpdatedDate])
	VALUES (@ProductId, @OldBuyerId, @BuyerId, @Message, @UpdatedBy, GETDATE())
END
