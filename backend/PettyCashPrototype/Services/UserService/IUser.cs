using PettyCashPrototype.Mappers.UserMapper;

namespace PettyCashPrototype.Services.UserService
{
    public interface IUser
    {
        public Task<IEnumerable<UserMapper>> GetAll();
        public Task<User> GetUserByEmail(string email);
        public Task<UserMapper> GetMappedUserByEmail(string email);
        public Task<string> Create(User user, string password);
    }
}
