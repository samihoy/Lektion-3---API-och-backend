namespace Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<ClassCourse> ClassCourses { get; set; }

    }
}
