/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT 1 FROM dbo.Buyer)
BEGIN
    INSERT INTO dbo.Buyer
    VALUES  ('Johnny Buyer', 'jbuyer@test.com', 1, 0, GETDATE()),
            ('Jennie Purchaser', 'jpurchaser@test.com', 1, 0, GETDATE()),
            ('Don Buyer', 'dbuyer@test.com', 1, 0, GETDATE())
END