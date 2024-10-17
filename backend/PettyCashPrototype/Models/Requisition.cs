﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PettyCashPrototype.Models;

public partial class Requisition
{
    public int RequisitionId { get; set; }

    public decimal AmountRequested { get; set; }

    public string? Description { get; set; }

    public decimal? CashIssued { get; set; }

    public decimal? TotalExpenses { get; set; }

    public decimal? Change { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public string ApplicantId { get; set; } = null!;

    public int GlaccountId { get; set; }

    public string? FinanceOfficerId { get; set; }

    public string? ManagerId { get; set; }

    public DateTime? ManagerRecommendationDate { get; set; }

    public int? ManagerRecommendationId { get; set; }

    public DateTime? FinanceApprovalDate {  get; set; }

    public int? FinanceApprovalId { get; set; }

    public bool NeedsMotivation { get; set; }

    public string? IssuerId { get; set; }

    public int ApplicantCode { get; set; }

    public bool ConfirmApplicantCode { get; set; }

    public bool ConfirmChangeReceived { get; set; }

    public bool ReceiptReceived { get; set; }

    public DateTime? IssueDate { get; set; }

    public string Stage { get; set; } = null!;

    public int? StateId { get; set; }

    public string? ManagerComment { get; set; }

    public string? FinanceComment { get; set; }

    public string? ApplicantComment { get; set; }

    public string? IssueComment { get; set; }

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(ApplicantId))]
    public virtual User? Applicant { get; set; }

    [ForeignKey(nameof(FinanceApprovalId))]
    public virtual Status? FinanceApproval { get; set; }

    [ForeignKey(nameof(FinanceOfficerId))]
    public virtual User? FinanceOfficer { get; set; }

    public virtual Glaccount? Glaccount { get; set; }

    [ForeignKey(nameof(IssuerId))]
    public virtual User? Issuer { get; set; }

    [ForeignKey(nameof(ManagerId))]
    public virtual User? Manager { get; set; }

    [ForeignKey(nameof(ManagerRecommendationId))]
    public virtual Status? ManagerRecommendation { get; set; }

    [ForeignKey(nameof(StateId))]
    public virtual Status? State { get; set; }

    [JsonIgnore]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    [JsonIgnore]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
