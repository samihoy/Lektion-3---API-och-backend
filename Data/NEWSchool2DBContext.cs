using Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models;
using Microsoft.EntityFrameworkCore;

namespace Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Data
{
    public class NEWSchool2DBContext : DbContext
    {
        public NEWSchool2DBContext(DbContextOptions<NEWSchool2DBContext> options) : base (options)
        {

        }
        public DbSet<Student> Studens { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ClassCourse> ClassCourses { get; set; }

    }
}
