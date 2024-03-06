using LibraryAPI.Entities;

namespace LibraryAPI.Services
{
    public interface IUsersService
    {
        public IEnumerable<User> GetUsers();
        public User? GetUser(int id);
    }
}
