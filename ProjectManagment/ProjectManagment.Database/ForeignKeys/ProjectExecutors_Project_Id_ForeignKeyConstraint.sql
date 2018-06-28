ALTER TABLE [dbo].[ProjectExecutors]
	ADD CONSTRAINT [ProjectExecutors_Project_Id_ForeignKeyConstraint]
	FOREIGN KEY (Project_Id)
	REFERENCES [dbo].Projects (Id)
