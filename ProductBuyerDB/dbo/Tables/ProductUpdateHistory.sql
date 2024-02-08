/*
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: ProductBuyer Demo - ProductUpdateHistory table
*/
CREATE TABLE [dbo].[ProductUpdateHistory]
(
	[ProductUpdateHistoryId] INT NOT NULL PRIMARY KEY,
	[ProductId] INT NOT NULL,
	[BuyerId] INT NOT NULL,
	[NewBuyerId] INT,
	[Message] VARCHAR(100) NOT NULL,
	[UpdatedBy] INT NOT NULL,
	[UpdatedDate] DATETIME NOT NULL
)
