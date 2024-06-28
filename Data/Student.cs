namespace SummerWebinarApp.Data
{

    // Represents a student entity with associated properties and relationships
    public class Student
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Institution { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; } = null!;

        public virtual ICollection<Webinar> Webinars { get; } = new HashSet<Webinar>();

        // Overrides the default ToString() method to provide a custom string representation
        public override string? ToString()
        {
            // Returns a formatted string containing the student's first name, last name, and institution
            return $"{User!.Firstname}, {User.Lastname}, {Institution}";
        }
    }
}
