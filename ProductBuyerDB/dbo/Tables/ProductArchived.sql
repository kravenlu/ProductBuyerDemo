/*
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: ProductBuyer Demo - ProductArchived table - save deleted record
*/
CREATE TABLE [dbo].[ProductArchived]
(
	[ProductId] INT NOT NULL PRIMARY KEY,
	[SKU] VARCHAR(255) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(200),
	[BuyerId] INT NOT NULL,
	[IsActive] BIT NOT NULL,
	[ArchivedBy] INT NOT NULL,
	[ArchivedDate] DATETIME NOT NULL
)
