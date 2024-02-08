/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Get a buyer by id
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spBuyer_Get]
	@BuyerID INT
AS
BEGIN
	SELECT [BuyerId], [BuyerName], [Email] FROM dbo.Buyer
	WHERE BuyerID = @BuyerID
END
