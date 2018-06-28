namespace ProjectManagment
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectManagmentModel : DbContext
    {
        public ProjectManagmentModel()
            : base("name=pmModel")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ProjectExecutor> ProjectExecutors { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectWorker> ProjectWorkers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ProjectExecutors)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.ProjectManager_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ProjectWorkers)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Customer)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Executor)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectExecutors)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.Project_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectWorkers)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.Project_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
