namespace PettyCashPrototype.Services.AuthService
{
    public interface IAuth
    {
        public Task<JWTToken> CreateToken(User user);
        public Task<bool> ValidateUser(string password, User user);
    }
}
