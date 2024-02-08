/*
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: ProductBuyer Demo - Product table
*/
CREATE TABLE [dbo].[Product]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY,
	[SKU] VARCHAR(255) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(200),
	[BuyerId] INT NOT NULL,
	[IsActive] BIT NOT NULL,
	[UpdatedBy] INT NOT NULL,
	[UpdatedDate] DATETIME NOT NULL

)
