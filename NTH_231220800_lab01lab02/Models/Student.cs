namespace NTH_231220800_lab01lab02.Models
{
    public class Student
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? password { get; set; }
        public Branch? Branch { get; set; }
        public Gender? Gender { get; set; }
        public bool isRegular { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }


    }
}
