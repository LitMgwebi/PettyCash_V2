namespace PettyCashPrototype.Models
{
    public class Role: IdentityRole
    {
        public IList<UserRole>? UserRoles { get; set; }
    }
}
