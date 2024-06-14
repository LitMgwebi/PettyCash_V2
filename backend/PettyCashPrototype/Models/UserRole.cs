using System.ComponentModel.DataAnnotations.Schema;

namespace PettyCashPrototype.Models
{
    public class UserRole: IdentityUserRole<string>
    {
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
    }
}
