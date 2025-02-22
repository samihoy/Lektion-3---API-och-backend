using System.ComponentModel.DataAnnotations.Schema;

namespace Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models
{
    public class ClassCourse
    {
        public int ID { get; set; }

        [ForeignKey("Classes")]
        public int FK_ClassID { get; set; }
        public virtual Class Classes { get; set; }
        [ForeignKey("Courses")]
        public int FK_CourseID { get; set; }
        public virtual Course Courses { get; set; }

    }
}
