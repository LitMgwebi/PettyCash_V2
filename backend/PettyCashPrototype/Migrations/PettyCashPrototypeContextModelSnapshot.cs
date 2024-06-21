﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PettyCashPrototype.Models;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    [DbContext(typeof(PettyCashPrototypeContext))]
    partial class PettyCashPrototypeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", (string)null);

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            Description = "Inspectorate",
                            IsActive = true,
                            Name = "INS"
                        },
                        new
                        {
                            DepartmentId = 2,
                            Description = "Information Communication Technology",
                            IsActive = true,
                            Name = "ICT"
                        },
                        new
                        {
                            DepartmentId = 3,
                            Description = "Legal",
                            IsActive = true,
                            Name = "LEG"
                        });
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Glaccount", b =>
                {
                    b.Property<int>("GlaccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GLAccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GlaccountId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<int>("MainAccountId")
                        .HasColumnType("int")
                        .HasColumnName("MainAccountID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurposeId")
                        .HasColumnType("int")
                        .HasColumnName("PurposeID");

                    b.Property<int>("SubAccountId")
                        .HasColumnType("int")
                        .HasColumnName("SubAccountID");

                    b.HasKey("GlaccountId");

                    b.HasIndex("MainAccountId");

                    b.HasIndex("PurposeId");

                    b.HasIndex("SubAccountId");

                    b.ToTable("GLAccount", (string)null);
                });

            modelBuilder.Entity("PettyCashPrototype.Models.MainAccount", b =>
                {
                    b.Property<int>("MainAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MainAccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MainAccountId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MainAccountId");

                    b.ToTable("MainAccount", (string)null);

                    b.HasData(
                        new
                        {
                            MainAccountId = 1,
                            AccountNumber = "2013",
                            IsActive = true,
                            Name = "Insurance"
                        },
                        new
                        {
                            MainAccountId = 2,
                            AccountNumber = "2012",
                            IsActive = true,
                            Name = "Inspection"
                        },
                        new
                        {
                            MainAccountId = 3,
                            AccountNumber = "2007",
                            IsActive = true,
                            Name = "Domestic Travel"
                        });
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OfficeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfficeId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.ToTable("Office", (string)null);

                    b.HasData(
                        new
                        {
                            OfficeId = 1,
                            Description = "Johannesburg",
                            IsActive = true,
                            Name = "JHB"
                        },
                        new
                        {
                            OfficeId = 2,
                            Description = "Kimberely",
                            IsActive = true,
                            Name = "KIM"
                        },
                        new
                        {
                            OfficeId = 3,
                            Description = "Cape Town",
                            IsActive = true,
                            Name = "CPT"
                        });
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Purpose", b =>
                {
                    b.Property<int>("PurposeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PurposeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurposeId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PurposeId");

                    b.ToTable("Purpose", (string)null);

                    b.HasData(
                        new
                        {
                            PurposeId = 1,
                            Description = "Administration",
                            IsActive = true,
                            Name = "ADM"
                        },
                        new
                        {
                            PurposeId = 2,
                            Description = "Regulatory Compliance",
                            IsActive = true,
                            Name = "RGC"
                        },
                        new
                        {
                            PurposeId = 3,
                            Description = "Diamond Trade",
                            IsActive = true,
                            Name = "DMT"
                        },
                        new
                        {
                            PurposeId = 4,
                            IsActive = true,
                            Name = "ZZZ"
                        });
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Requisition", b =>
                {
                    b.Property<int>("RequisitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RequisitionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequisitionId"));

                    b.Property<decimal>("AmountRequested")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ApplicantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ApplicantID");

                    b.Property<decimal?>("CashIssued")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("Change")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateOnly?>("CloseDate")
                        .HasColumnType("date");

                    b.Property<int?>("FinanceApprovalId")
                        .HasColumnType("int")
                        .HasColumnName("FinanceApprovalID");

                    b.Property<string>("FinanceOfficerId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("FinanceOfficerID");

                    b.Property<int?>("GlaccountId")
                        .HasColumnType("int")
                        .HasColumnName("GLAccountID");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("IssuerId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IssuerID");

                    b.Property<int?>("ManagerApprovalId")
                        .HasColumnType("int")
                        .HasColumnName("ManagerApprovalID");

                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ManagerID");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("TotalExpenses")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("RequisitionId");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("FinanceApprovalId");

                    b.HasIndex("FinanceOfficerId");

                    b.HasIndex("GlaccountId");

                    b.HasIndex("IssuerId");

                    b.HasIndex("ManagerApprovalId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Requisition", (string)null);
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("PettyCashPrototype.Models.SubAccount", b =>
                {
                    b.Property<int>("SubAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SubAccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubAccountId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubAccountId");

                    b.ToTable("SubAccount", (string)null);

                    b.HasData(
                        new
                        {
                            SubAccountId = 1,
                            AccountNumber = "0206",
                            IsActive = true,
                            Name = "IT Audit"
                        },
                        new
                        {
                            SubAccountId = 2,
                            AccountNumber = "0045",
                            IsActive = true,
                            Name = "Meeting Fees"
                        },
                        new
                        {
                            SubAccountId = 3,
                            AccountNumber = "0001",
                            IsActive = true,
                            Name = "Accomodation"
                        });
                });

            modelBuilder.Entity("PettyCashPrototype.Models.TripStatus", b =>
                {
                    b.Property<int>("TripStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TripStatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripStatusId"));

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.HasKey("TripStatusId");

                    b.ToTable("TripStatus", (string)null);
                });

            modelBuilder.Entity("PettyCashPrototype.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Idnumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("OfficeId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PettyCashPrototype.Models.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("PettyCashPrototype.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PettyCashPrototype.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PettyCashPrototype.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PettyCashPrototype.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Glaccount", b =>
                {
                    b.HasOne("PettyCashPrototype.Models.MainAccount", "MainAccount")
                        .WithMany("Glaccounts")
                        .HasForeignKey("MainAccountId")
                        .IsRequired()
                        .HasConstraintName("FK_GLAccount_MainAccount");

                    b.HasOne("PettyCashPrototype.Models.Purpose", "Purpose")
                        .WithMany("Glaccounts")
                        .HasForeignKey("PurposeId")
                        .IsRequired()
                        .HasConstraintName("FK_GLAccount_Purpose");

                    b.HasOne("PettyCashPrototype.Models.SubAccount", "SubAccount")
                        .WithMany("Glaccounts")
                        .HasForeignKey("SubAccountId")
                        .IsRequired()
                        .HasConstraintName("FK_GLAccount_SubAccount");

                    b.Navigation("MainAccount");

                    b.Navigation("Purpose");

                    b.Navigation("SubAccount");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Requisition", b =>
                {
                    b.HasOne("PettyCashPrototype.Models.User", "Applicant")
                        .WithMany("Applicants")
                        .HasForeignKey("ApplicantId")
                        .IsRequired()
                        .HasConstraintName("FK_Requisition_User");

                    b.HasOne("PettyCashPrototype.Models.TripStatus", "FinanceApproval")
                        .WithMany("FinanceApprovals")
                        .HasForeignKey("FinanceApprovalId")
                        .HasConstraintName("FK_Requisition_TripStatus1");

                    b.HasOne("PettyCashPrototype.Models.User", "FinanceOfficer")
                        .WithMany("FinanceOfficers")
                        .HasForeignKey("FinanceOfficerId")
                        .HasConstraintName("FK_Requisition_User1");

                    b.HasOne("PettyCashPrototype.Models.Glaccount", "Glaccount")
                        .WithMany("Requisitions")
                        .HasForeignKey("GlaccountId")
                        .HasConstraintName("FK_Requisition_GLAccount");

                    b.HasOne("PettyCashPrototype.Models.User", "Issuer")
                        .WithMany("Issuers")
                        .HasForeignKey("IssuerId")
                        .HasConstraintName("FK_Requisition_User3");

                    b.HasOne("PettyCashPrototype.Models.TripStatus", "ManagerApproval")
                        .WithMany("ManagerApprovals")
                        .HasForeignKey("ManagerApprovalId")
                        .HasConstraintName("FK_Requisition_TripStatus");

                    b.HasOne("PettyCashPrototype.Models.User", "Manager")
                        .WithMany("Managers")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK_Requisition_User2");

                    b.Navigation("Applicant");

                    b.Navigation("FinanceApproval");

                    b.Navigation("FinanceOfficer");

                    b.Navigation("Glaccount");

                    b.Navigation("Issuer");

                    b.Navigation("Manager");

                    b.Navigation("ManagerApproval");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.User", b =>
                {
                    b.HasOne("PettyCashPrototype.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("PettyCashPrototype.Models.Office", "Office")
                        .WithMany("Users")
                        .HasForeignKey("OfficeId");

                    b.Navigation("Department");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.UserRole", b =>
                {
                    b.HasOne("PettyCashPrototype.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PettyCashPrototype.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("PettyCashPrototype.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PettyCashPrototype.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Glaccount", b =>
                {
                    b.Navigation("Requisitions");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.MainAccount", b =>
                {
                    b.Navigation("Glaccounts");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Office", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Purpose", b =>
                {
                    b.Navigation("Glaccounts");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.SubAccount", b =>
                {
                    b.Navigation("Glaccounts");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.TripStatus", b =>
                {
                    b.Navigation("FinanceApprovals");

                    b.Navigation("ManagerApprovals");
                });

            modelBuilder.Entity("PettyCashPrototype.Models.User", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("FinanceOfficers");

                    b.Navigation("Issuers");

                    b.Navigation("Managers");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
