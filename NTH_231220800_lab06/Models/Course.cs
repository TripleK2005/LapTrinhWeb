using System.ComponentModel.DataAnnotations.Schema;

namespace Day_12_lab1.Models
{
    public class Course
    {
        public Course()
        {
            Enrollment = new HashSet<Enrollment>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
