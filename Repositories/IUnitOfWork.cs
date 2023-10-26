namespace UserMvcApp.Repositories;

public interface IUnitOfWork
{
    public IUserRepository UserRepository {get;}
    /*
     * public IStudentRepository StudentRepository {get;}
     * public ITeacherRepository TeacherRepository {get;}
     */

    Task<bool> SaveAsync();
}