/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Add a Buyer
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spBuyer_Insert]
	@BuyerName VARCHAR(100),
	@Email VARCHAR(100),
	@IsActive BIT,
	@UpdatedBy INT
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM dbo.Buyer WHERE [Email] = @Email)
	BEGIN
		INSERT INTO dbo.Buyer ([BuyerName], [Email], [IsActive], [UpdatedBy], [UpdatedDate])
		VALUES (@BuyerName, @Email, @IsActive, @UpdatedBy, GETDATE())
	END
END