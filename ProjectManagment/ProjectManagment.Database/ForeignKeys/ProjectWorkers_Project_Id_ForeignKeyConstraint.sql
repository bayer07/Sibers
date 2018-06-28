ALTER TABLE [dbo].[ProjectWorkers]
	ADD CONSTRAINT [ProjectWorkers_Project_Id_ForeignKeyConstraint]
	FOREIGN KEY (Project_Id)
	REFERENCES [dbo].[Projects] (Id)
