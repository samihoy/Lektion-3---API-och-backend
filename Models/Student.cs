using System.ComponentModel.DataAnnotations.Schema;

namespace Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [ForeignKey("Class")]
        public int? FK_ClassID { get; set; }
        public virtual Class Class { get; set; }

    }
}
