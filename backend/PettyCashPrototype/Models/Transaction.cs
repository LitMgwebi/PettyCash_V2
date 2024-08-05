using System.ComponentModel.DataAnnotations.Schema;

namespace PettyCashPrototype.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string TransactionType { get; set; } = null!;

        public DateTime TransactionDate { get; set; }

        public int? RequisitionId { get; set; }

        public int VaultId { get; set; }

        public string? Note { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(RequisitionId))]
        public virtual Requisition? Requisition { get; set; }

        [ForeignKey(nameof(VaultId))]
        public virtual Vault? Vault { get; set; }

    }
}
