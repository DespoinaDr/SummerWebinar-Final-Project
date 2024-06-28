namespace SummerWebinarApp.Models
{
    // Represents an error object with code, message, and optional field information
    public class Error
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
        public string? Field { get; set; }


        // Default constructor
        public Error()
        {

        }

        // Constructor with parameters to initialize all properties
        public Error(string? code, string? message, string? field)
        {
            Code = code;
            Message = message;
            Field = field;
        }
    }
}
