CREATE TABLE [dbo].[Call]
(
	[CallId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StatusCode] INT NOT NULL, 
    [StatusDescription] NCHAR(10) NOT NULL, 
    [ResponseUri] NVARCHAR(50) NOT NULL, 
    [DateCreated] SMALLDATETIME NOT NULL
)
