CREATE TABLE [dbo].[Call]
(
	[CallID] INT NOT NULL PRIMARY KEY, 
    [StatusDescription] NCHAR(10) NOT NULL, 
    [DateCreated] DATETIME2 NOT NULL
)
