namespace SummerWebinarApp.Models
{

    // Represents a view model for displaying error details in views
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
