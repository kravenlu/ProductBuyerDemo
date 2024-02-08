

USE [ProductBuyerDB]
GO

/****** Object: Table [dbo].[Buyer] Script Date: 2/8/2024 9:00:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Buyer] (
    [BuyerId]     INT           IDENTITY (1, 1) NOT NULL,
    [BuyerName]   VARCHAR (100) NOT NULL,
    [Email]       VARCHAR (100) NOT NULL,
    [IsActive]    BIT           NOT NULL,
    [UpdatedBy]   INT           NOT NULL,
    [UpdatedDate] DATETIME      NOT NULL
);

CREATE TABLE [dbo].[Product] (
    [ProductId]   INT           IDENTITY (1, 1) NOT NULL,
    [SKU]         VARCHAR (255) NOT NULL,
    [Title]       VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (200) NULL,
    [BuyerId]     INT           NOT NULL,
    [IsActive]    BIT           NOT NULL,
    [UpdatedBy]   INT           NOT NULL,
    [UpdatedDate] DATETIME      NOT NULL
);

CREATE TABLE [dbo].[ProductArchived] (
    [ProductId]    INT           NOT NULL,
    [SKU]          VARCHAR (255) NOT NULL,
    [Title]        VARCHAR (50)  NOT NULL,
    [Description]  VARCHAR (200) NULL,
    [BuyerId]      INT           NOT NULL,
    [IsActive]     BIT           NOT NULL,
    [ArchivedBy]   INT           NOT NULL,
    [ArchivedDate] DATETIME      NOT NULL
);

CREATE TABLE [dbo].[ProductUpdateHistory] (
    [ProductUpdateHistoryId] INT           NOT NULL,
    [ProductId]              INT           NOT NULL,
    [BuyerId]                INT           NOT NULL,
    [NewBuyerId]             INT           NULL,
    [Message]                VARCHAR (100) NOT NULL,
    [UpdatedBy]              INT           NOT NULL,
    [UpdatedDate]            DATETIME      NOT NULL
);

--------------------------------------------------

USE [ProductBuyerDB]
GO

/****** Object: SqlProcedure [dbo].[spBuyer_GetAll] Script Date: 2/8/2024 9:03:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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



/****** Object: SqlProcedure [dbo].[spProduct_Delete] Script Date: 2/8/2024 9:05:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Delete a product by ProductId
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_Delete]
	@ProductId int
AS
BEGIN
	INSERT INTO dbo.ProductArchived
	SELECT [ProductId], [SKU], [Title], [Description], [BuyerId], [IsActive], 0, GETDATE() FROM dbo.Product
	WHERE ProductId = @ProductId;

	DELETE FROM dbo.Product
	WHERE ProductId = @ProductId;
END


/****** Object: SqlProcedure [dbo].[spProduct_Get] Script Date: 2/8/2024 9:06:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Get a product by ProductId
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_Get]
	@ProductId int
AS
BEGIN
	SELECT [ProductId], [SKU], [Title], [Description], T1.[BuyerId], T2.[BuyerName], T1.[IsActive], T1.[UpdatedBy], T1.[UpdatedDate] 
	FROM dbo.Product T1 
	INNER JOIN dbo.Buyer T2 ON T1.BuyerId=T2.BuyerId
	WHERE ProductId = @ProductId
END


/****** Object: SqlProcedure [dbo].[spProduct_GetAll] Script Date: 2/8/2024 9:07:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/5/2024
	UpdateDate: 2/5/2024
	Notes: Get all products
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	SELECT [ProductId], [SKU], [Title], [Description], T1.[BuyerId], T2.[BuyerName], T1.[IsActive], T1.[UpdatedBy], T1.[UpdatedDate] 
	FROM dbo.Product T1
	INNER JOIN dbo.Buyer T2 ON T1.BuyerId = T2.BuyerId
END


/****** Object: SqlProcedure [dbo].[spProduct_GetBySKU] Script Date: 2/8/2024 9:07:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
-------------------------------------------
	Author:		dl
	CreateDate: 2/6/2024
	UpdateDate: 2/6/2024
	Notes: Get a product by SKU to verify being unique
-------------------------------------------
*/
CREATE PROCEDURE [dbo].[spProduct_GetBySKU]
	@SKU VARCHAR(255)
AS
BEGIN
	SELECT [ProductId], [SKU], [Title], [Description], [BuyerId], [IsActive], [UpdatedBy], [UpdatedDate] FROM dbo.Product
	WHERE SKU = @SKU
END


/****** Object: SqlProcedure [dbo].[spProduct_Insert] Script Date: 2/8/2024 9:07:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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


/****** Object: SqlProcedure [dbo].[spProduct_Update] Script Date: 2/8/2024 9:07:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

-----------------------------------------------------------------------------------
--Add reference data to Buyer table

IF NOT EXISTS (SELECT 1 FROM dbo.Buyer)
BEGIN
    INSERT INTO dbo.Buyer
    VALUES  ('Johnny Buyer', 'jbuyer@test.com', 1, 0, GETDATE()),
            ('Jennie Purchaser', 'jpurchaser@test.com', 1, 0, GETDATE()),
            ('Don Buyer', 'dbuyer@test.com', 1, 0, GETDATE())
END


