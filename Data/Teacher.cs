namespace SummerWebinarApp.Data
{
    // Represents a teacher entity with associated properties and relationships
    public class Teacher
    {
        public int Id { get; set; }

        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Institution { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Webinar> Webinars { get; } = new HashSet<Webinar>(); // Collection of webinars the teacher is associated with
    }
}
