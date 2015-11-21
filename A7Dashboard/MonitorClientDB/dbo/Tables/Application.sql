CREATE TABLE [dbo].[Application]
(
	[ApplicationID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [Timeout] INT NOT NULL, 
    [Interval] INT NOT NULL
)
