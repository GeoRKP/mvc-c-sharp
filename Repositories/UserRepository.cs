using Microsoft.EntityFrameworkCore;
using UserMvcApp.Data;
using UserMvcApp.DTO;
using UserMvcApp.Security;

namespace UserMvcApp.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(StudentsCf4dbContext context)
            : base(context)
        {

        }

        public async Task<bool> SignUpUserAsync(UserSignupDTO request)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if (existingUser != null)
            {
                return false;
            }

            var user = new User()
            {
                Username = request.Username,
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Password = EncryptionUtil.Encrypt(request.Password!),
                Institution = request.Institution,
                PhoneNumber = request.PhoneNumber,
                UserRole = request.UserRole
            };

            await context.Users.AddAsync(user);
            return true;
        }

        public async Task<User?> GetUserAsync(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username); // || x.Email == username
            if (user is null) return null;

            if (!EncryptionUtil.IsValidPassword(password, user.Password!)) return null;

            return user;
        }

        public async Task<User?> UpdateUserAsync(int userId, UserPatchDTO request)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null) return null;

            user.Email = request.Email;
            user.Password = request.Password;
            user.PhoneNumber = request.PhoneNumber;

            context.Users.Update(user);
            return user;

        }

        public async Task<User?> GetByUsername(string username)
        {
            return await context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        }
    }
}
