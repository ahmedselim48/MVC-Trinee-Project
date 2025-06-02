using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tech.Models
{
    public class TechContext :DbContext 
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructore> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<crsResult> crsResults { get; set; }

        public TechContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BLI6H89\\SQLDEV;Initial Catalog=LabMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
               new Department { Id = 1, Name = "Computer Science", Manager = "Dr.Ali" },
               new Department { Id = 2, Name = "AI", Manager = "Dr.Osama" },
               new Department { Id = 3, Name = "Information System ", Manager = "Dr.Omar" }
           );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C# Programming", Degree = 90 , MinDegree = 70, Hours = 3, DeptId = 1 },
                new Course { Id = 2, Name = "OOP", Degree = 70, MinDegree = 65,Hours = 3 , DeptId  = 1 },
                new Course { Id = 3, Name = "Database", Degree = 65, MinDegree = 60,Hours = 3 , DeptId  = 2 }
            );
            modelBuilder.Entity<Instructore>().HasData(
                new Instructore { Id = 1, Name = "Ahmed Selim", Address = "Alex", Salary = 7000, ImageUrl = "ahmed.jpg", DeptId  = 1, CrsId  = 1 },
                new Instructore { Id = 2, Name = "Mohamed", Address = "Giza", Salary = 5500, ImageUrl = "mohamed.png", DeptId  = 2, CrsId  = 2 }

                );
            modelBuilder.Entity<Trainee>().HasData(
               new Trainee { Id = 1, Name = "AHMED AHMED",  ImageUrl=" ",Address = "ALex", Grade = 3.2, DeptId = 1 },
               new Trainee { Id = 2, Name = "ALI ALI ", ImageUrl=" ", Address = "Cairo", Grade = 3.1, DeptId = 1 },
               new Trainee { Id = 3, Name = "OMAR OMAR",  ImageUrl=" ",Address = "Damanhour", Grade = 2.7, DeptId = 2 }
           );
            modelBuilder.Entity<crsResult>().HasData(
               new crsResult { Id = 1, Degree = 85, CrsId  = 1, TraineeID = 1 },
               new crsResult { Id = 2, Degree = 78, CrsId  = 2, TraineeID = 1 },
               new crsResult { Id = 3, Degree = 92, CrsId  = 1, TraineeID = 2 },
               new crsResult { Id = 4, Degree = 88, CrsId  = 3, TraineeID = 3 }
           );


        }



    }
}
