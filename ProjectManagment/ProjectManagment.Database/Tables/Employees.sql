﻿CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(200) NOT NULL, 
    [LastName] VARCHAR(200) NOT NULL, 
    [MiddleName] VARCHAR(200) NOT NULL, 
    [Email] VARCHAR(200) NOT NULL
)
