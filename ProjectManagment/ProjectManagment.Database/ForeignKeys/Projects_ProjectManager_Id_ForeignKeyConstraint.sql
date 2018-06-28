ALTER TABLE [dbo].[Projects]
	ADD CONSTRAINT [Projects_ProjectManager_Id_ForeignKeyConstraint]
	FOREIGN KEY (ProjectManager_Id)
	REFERENCES [dbo].[Employees] (Id)
