CREATE TABLE [dbo].[PingResult]
(
	[PingResultID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[StatusCode] INT NULL,
	[StatusDescription] NVARCHAR (50) NULL,
	[Server] NVARCHAR (50) NULL,
	[ResponseUri] NVARCHAR (50) NULL,
	[ResponseStatus] NVARCHAR (50) NULL,
    [DateCreated] DATETIME NOT NULL DEFAULT getdate()
)
