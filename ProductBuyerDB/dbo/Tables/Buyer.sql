/*
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: ProductBuyer Demo - Buyers table
*/
CREATE TABLE [dbo].[Buyer]
(
	[BuyerId] INT NOT NULL PRIMARY KEY IDENTITY,
	[BuyerName] VARCHAR(100) NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[IsActive] BIT NOT NULL,
	[UpdatedBy] INT NOT NULL,
	[UpdatedDate] DATETIME NOT NULL
)
