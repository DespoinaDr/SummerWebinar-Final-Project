namespace SummerWebinarApp.Services
{

    // Interface defining the application service, providing access to domain services.
    public interface IApplicationService
    {
        UserService UserService { get; }
        StudentService StudentService { get; }
        TeacherService TeacherService { get; }
        WebinarService WebinarService { get; }
    }
}
