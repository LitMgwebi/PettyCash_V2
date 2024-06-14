using AutoMapper;

namespace PettyCashPrototype.Mappers.UserMapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserMapper>();
        }
    }
}
