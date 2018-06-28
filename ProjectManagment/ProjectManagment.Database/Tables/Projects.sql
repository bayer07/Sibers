CREATE TABLE [dbo].[Projects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(200) NOT NULL, 
    [Customer] VARCHAR(200) NOT NULL, 
    [Executor] VARCHAR(200) NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [Priority] TINYINT NOT NULL, 
    [Comment] VARCHAR(1000) NOT NULL, 
    [ProjectManager_Id] INT NOT NULL
)
