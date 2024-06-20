using System.ComponentModel.DataAnnotations.Schema;

namespace PettyCashPrototype.Models;

public partial class Requisition
{
    public int RequisitionId { get; set; }

    public decimal AmountRequested { get; set; }

    public decimal? CashIssued { get; set; }

    public decimal? TotalExpenses { get; set; }

    public decimal? Change { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? CloseDate { get; set; }

    public string ApplicantId { get; set; } = null!;

    public int? GlaccountId { get; set; }

    public string? FinanceOfficerId { get; set; }

    public string? ManagerId { get; set; }

    public int? ManagerApprovalId { get; set; }

    public int? FinanceApprovalId { get; set; }

    public string? IssuerId { get; set; }

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(ApplicantId))]
    public virtual User Applicant { get; set; } = null!;

    [ForeignKey(nameof(FinanceApprovalId))]
    public virtual TripStatus? FinanceApproval { get; set; }

    [ForeignKey(nameof(FinanceOfficerId))]
    public virtual User? FinanceOfficer { get; set; }

    public virtual Glaccount? Glaccount { get; set; }

    [ForeignKey(nameof(IssuerId))]
    public virtual User? Issuer { get; set; }

    [ForeignKey(nameof(ManagerId))]
    public virtual User? Manager { get; set; }

    [ForeignKey(nameof(ManagerApprovalId))]
    public virtual TripStatus? ManagerApproval { get; set; }
}
