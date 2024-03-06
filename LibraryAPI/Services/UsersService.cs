using LibraryAPI.Entities;

namespace LibraryAPI.Services
{
    public class UsersService : IUsersService
    {
        private LibraryDbContext _context;

        public UsersService(LibraryDbContext context)
        {
            _context = context;
        }

        public User? GetUser(int id)
        {
            return _context.Users.FirstOrDefault(user => user.UserID == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}
