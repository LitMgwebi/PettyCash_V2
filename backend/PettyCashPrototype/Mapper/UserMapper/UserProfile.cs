using AutoMapper;

namespace PettyCashPrototype.Mapper.UserMapper
{
    public class UserProfile: Profile
    {
        public UserProfile() => CreateMap<User, UserMapper>();
    }
}
