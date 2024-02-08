/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Update a buyer
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spBuyer_Update]
	@BuyerId INT,
	@BuyerName VARCHAR(100),
	@Email VARCHAR(100),
	@IsActive BIT,
	@UpdatedBy INT
AS
BEGIN
	UPDATE dbo.Buyer 
	SET [BuyerName] = @BuyerName, 
		[Email] = @Email, 
		[IsActive] = @IsActive, 
		[UpdatedBy] = @UpdatedBy, 
		[UpdatedDate] = GETDATE()
	WHERE [BuyerId] = @BuyerId;

END