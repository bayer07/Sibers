CREATE TABLE [dbo].[ProjectExecutors]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Project_Id] INT NOT NULL, 
    [Employee_Id] INT NOT NULL
)
