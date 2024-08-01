using System.ComponentModel.DataAnnotations.Schema;

namespace PettyCashPrototype.Models
{
    [Table("Vault")]
    public class Vault
    {
        public int VaultId { get; set; }

        public decimal CurrentAmount { get; set; }

        public bool IsActive { get; set; } = true;

        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
