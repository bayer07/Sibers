CREATE TABLE [dbo].[ProjectWorkers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Project_Id] INT NOT NULL, 
    [Employee_Id] INT NOT NULL
)
