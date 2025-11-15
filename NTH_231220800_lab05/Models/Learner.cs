namespace Day_12_lab1.Models
{
    public class Learner
    {
        public Learner()
        {
            Enrollment = new HashSet<Enrollment>();
        }
        public int LearnerID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int MajorID { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
