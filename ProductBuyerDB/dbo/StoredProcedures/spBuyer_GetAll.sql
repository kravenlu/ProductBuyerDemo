/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Get all buyers for a product reference
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spBuyer_GetAll]
AS
BEGIN
	SELECT [BuyerId], [BuyerName], [Email] FROM dbo.Buyer
	WHERE IsActive = 1;
END
