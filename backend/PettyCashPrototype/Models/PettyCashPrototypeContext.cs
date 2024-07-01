using PettyCashPrototype.Seeding.Entites;

namespace PettyCashPrototype.Models;

public partial class PettyCashPrototypeContext : IdentityDbContext<User>
{
    public PettyCashPrototypeContext()
    {
    }

    public PettyCashPrototypeContext(DbContextOptions<PettyCashPrototypeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Glaccount> Glaccounts { get; set; }

    public virtual DbSet<MainAccount> MainAccounts { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Purpose> Purposes { get; set; }

    public virtual DbSet<Requisition> Requisitions { get; set; }

    public virtual DbSet<SubAccount> SubAccounts { get; set; }

    public virtual DbSet<TripStatus> TripStatuses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<Glaccount>(entity =>
        {
            entity.ToTable("GLAccount");

            entity.Property(e => e.GlaccountId).HasColumnName("GLAccountID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MainAccountId).HasColumnName("MainAccountID");
            entity.Property(e => e.PurposeId).HasColumnName("PurposeID");
            entity.Property(e => e.SubAccountId).HasColumnName("SubAccountID");

            entity.HasOne(d => d.MainAccount).WithMany(p => p.Glaccounts)
                .HasForeignKey(d => d.MainAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GLAccount_MainAccount");

            entity.HasOne(d => d.Purpose).WithMany(p => p.Glaccounts)
                .HasForeignKey(d => d.PurposeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GLAccount_Purpose");

            entity.HasOne(d => d.SubAccount).WithMany(p => p.Glaccounts)
                .HasForeignKey(d => d.SubAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GLAccount_SubAccount");
        });

        modelBuilder.Entity<MainAccount>(entity =>
        {
            entity.ToTable("MainAccount");

            entity.Property(e => e.MainAccountId).HasColumnName("MainAccountID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.ToTable("Office");

            entity.Property(e => e.OfficeId).HasColumnName("OfficeID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<Purpose>(entity =>
        {
            entity.ToTable("Purpose");

            entity.Property(e => e.PurposeId).HasColumnName("PurposeID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<Requisition>(entity =>
        {
            entity.ToTable("Requisition");

            entity.Property(e => e.RequisitionId).HasColumnName("RequisitionID");
            entity.Property(e => e.AmountRequested).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.CashIssued).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Change).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FinanceApprovalId).HasColumnName("FinanceApprovalID");
            entity.Property(e => e.FinanceOfficerId).HasColumnName("FinanceOfficerID");
            entity.Property(e => e.GlaccountId).HasColumnName("GLAccountID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IssuerId).HasColumnName("IssuerID");
            entity.Property(e => e.ManagerRecommendationId).HasColumnName("ManagerApprovalID");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.TotalExpenses).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Applicant).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requisition_User");

            entity.HasOne(d => d.FinanceApproval).WithMany(p => p.FinanceApprovals)
                .HasForeignKey(d => d.FinanceApprovalId)
                .HasConstraintName("FK_Requisition_TripStatus1");

            entity.HasOne(d => d.FinanceOfficer).WithMany(p => p.FinanceOfficers)
                .HasForeignKey(d => d.FinanceOfficerId)
                .HasConstraintName("FK_Requisition_User1");

            entity.HasOne(d => d.Glaccount).WithMany(p => p.Requisitions)
                .HasForeignKey(d => d.GlaccountId)
                .HasConstraintName("FK_Requisition_GLAccount");

            entity.HasOne(d => d.Issuer).WithMany(p => p.Issuers)
                .HasForeignKey(d => d.IssuerId)
                .HasConstraintName("FK_Requisition_User3");

            entity.HasOne(d => d.ManagerRecommendation).WithMany(p => p.ManagerRecommendations)
                .HasForeignKey(d => d.ManagerRecommendationId)
                .HasConstraintName("FK_Requisition_TripStatus");

            entity.HasOne(d => d.Manager).WithMany(p => p.Managers)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Requisition_User2");
        });

        modelBuilder.Entity<SubAccount>(entity =>
        {
            entity.ToTable("SubAccount");

            entity.Property(e => e.SubAccountId).HasColumnName("SubAccountID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<TripStatus>(entity =>
        {
            entity.ToTable("TripStatus");

            entity.Property(e => e.TripStatusId).HasColumnName("TripStatusID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PurposeSeeding());
        modelBuilder.ApplyConfiguration(new DepartmentSeeding());
        modelBuilder.ApplyConfiguration(new OfficeSeeding());
        modelBuilder.ApplyConfiguration(new SubAccountSeeding());
        modelBuilder.ApplyConfiguration(new MainAccountSeeding());
        modelBuilder.ApplyConfiguration(new RolesSeeding());
        modelBuilder.ApplyConfiguration(new JobTitleSeeding());
    }
}
