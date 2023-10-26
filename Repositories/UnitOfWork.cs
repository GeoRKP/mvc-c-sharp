using UserMvcApp.Data;

namespace UserMvcApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentsCf4dbContext context;

        public IUserRepository UserRepository => new UserRepository(context);

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
