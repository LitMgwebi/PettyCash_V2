namespace PettyCashPrototype.Mapper.UserMapper
{
    public class UserMapper
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
