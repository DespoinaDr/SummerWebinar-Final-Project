namespace SummerWebinarApp.DTO
{

    // Data Transfer Object (DTO) for filtering users based on criteria
    public class UserFiltersDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? UserRole { get; set; }
    }
}
