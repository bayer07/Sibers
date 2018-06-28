ALTER TABLE [dbo].[ProjectWorkers]
	ADD CONSTRAINT [ProjectWorkers_Employee_Id_ForeignKeyConstraint]
	FOREIGN KEY (Employee_Id)
	REFERENCES [dbo].[Employees] (Id)
