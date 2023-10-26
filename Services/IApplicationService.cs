namespace UserMvcApp.Services;

public interface IApplicationService
{
    IUserService UserService { get; }
}