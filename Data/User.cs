using SummerWebinarApp.Models;

namespace SummerWebinarApp.Data
{
    // Represents a user entity with basic authentication and role information
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public UserRole? UserRole { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
