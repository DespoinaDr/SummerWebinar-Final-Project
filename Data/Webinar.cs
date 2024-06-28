namespace SummerWebinarApp.Data
{
    // Represents a webinar entity with associated properties and relationships
    public class Webinar
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Student> Students { get; } = new HashSet<Student>();
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
