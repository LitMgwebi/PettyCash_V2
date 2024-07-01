using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                });

            migrationBuilder.CreateTable(
                name: "MainAccount",
                columns: table => new
                {
                    MainAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAccount", x => x.MainAccountID);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.OfficeID);
                });

            migrationBuilder.CreateTable(
                name: "Purpose",
                columns: table => new
                {
                    PurposeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.PurposeID);
                });

            migrationBuilder.CreateTable(
                name: "SubAccount",
                columns: table => new
                {
                    SubAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAccount", x => x.SubAccountID);
                });

            migrationBuilder.CreateTable(
                name: "TripStatus",
                columns: table => new
                {
                    TripStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStatus", x => x.TripStatusID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Division_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GLAccount",
                columns: table => new
                {
                    GLAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainAccountID = table.Column<int>(type: "int", nullable: false),
                    SubAccountID = table.Column<int>(type: "int", nullable: false),
                    PurposeID = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLAccount", x => x.GLAccountID);
                    table.ForeignKey(
                        name: "FK_GLAccount_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GLAccount_MainAccount",
                        column: x => x.MainAccountID,
                        principalTable: "MainAccount",
                        principalColumn: "MainAccountID");
                    table.ForeignKey(
                        name: "FK_GLAccount_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GLAccount_Purpose",
                        column: x => x.PurposeID,
                        principalTable: "Purpose",
                        principalColumn: "PurposeID");
                    table.ForeignKey(
                        name: "FK_GLAccount_SubAccount",
                        column: x => x.SubAccountID,
                        principalTable: "SubAccount",
                        principalColumn: "SubAccountID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisition",
                columns: table => new
                {
                    RequisitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountRequested = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashIssued = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Change = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicantID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GLAccountID = table.Column<int>(type: "int", nullable: false),
                    FinanceOfficerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ManagerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ManagerRecommendationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerApprovalID = table.Column<int>(type: "int", nullable: true),
                    FinanceApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinanceApprovalID = table.Column<int>(type: "int", nullable: true),
                    IssuerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    TripStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisition", x => x.RequisitionID);
                    table.ForeignKey(
                        name: "FK_Requisition_GLAccount",
                        column: x => x.GLAccountID,
                        principalTable: "GLAccount",
                        principalColumn: "GLAccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisition_TripStatus",
                        column: x => x.ManagerApprovalID,
                        principalTable: "TripStatus",
                        principalColumn: "TripStatusID");
                    table.ForeignKey(
                        name: "FK_Requisition_TripStatus1",
                        column: x => x.FinanceApprovalID,
                        principalTable: "TripStatus",
                        principalColumn: "TripStatusID");
                    table.ForeignKey(
                        name: "FK_Requisition_TripStatus_TripStatusId",
                        column: x => x.TripStatusId,
                        principalTable: "TripStatus",
                        principalColumn: "TripStatusID");
                    table.ForeignKey(
                        name: "FK_Requisition_User",
                        column: x => x.ApplicantID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requisition_User1",
                        column: x => x.FinanceOfficerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requisition_User2",
                        column: x => x.ManagerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requisition_User3",
                        column: x => x.IssuerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16ea7aa2-f170-4433-bb6a-08266ada6029", null, "CEO_Admin", null },
                    { "3b3146f8-9aba-4770-83de-c538e5cae3a7", null, "DEEC_Admin", null },
                    { "40323865-3ca6-47a9-be1f-b81a6c4d5f1b", null, "SCM_Admin", null },
                    { "4a3e14ec-b870-4534-90dc-0e5d72bf622a", null, "PA_Admin", null },
                    { "4e58e31f-3bc5-4bc1-97f8-a74832efb73f", null, "Manager", null },
                    { "5e1e28d6-da03-401e-b558-00ed0eea805f", null, "Super_User", null },
                    { "6d64c097-8c33-4e33-8986-0432a2cbac55", null, "Finance_Admin", null },
                    { "6f17444f-e17b-4576-aedf-411c68912ed4", null, "HR_Admin", null },
                    { "765bcc05-9271-435b-9db7-0f8443b3164f", null, "Employee", null },
                    { "7776b4d0-9a3e-42eb-8730-f6f987bd9c62", null, "ICT_Admin", null },
                    { "9ecceff9-7fb0-4d0c-9597-884d8e4957d7", null, "Cashier", null },
                    { "aa44333f-aa07-4491-a851-b043ba55b34d", null, "GM_Manager", null },
                    { "fdb012f2-c43d-4cc0-b4c2-52ad400ef930", null, "SRM_Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentID", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, null, true, "CEO Office" },
                    { 2, null, true, "CFO Office" },
                    { 3, null, true, "Governance" },
                    { 4, null, true, "Regulatory Compliance" },
                    { 5, null, true, "Corporate Services" },
                    { 6, null, true, "Trade" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "JobTitleId", "Description" },
                values: new object[,]
                {
                    { 1, "CEO" },
                    { 2, "CFO" },
                    { 3, "GM: Corporate Services" },
                    { 4, "GM: Governance" },
                    { 5, "GM: Regulatory Compliance" },
                    { 6, "GM: Trade" },
                    { 7, "Manager" },
                    { 8, "Staff" },
                    { 9, "Consultant" },
                    { 10, "Chair Person" },
                    { 11, "Board Member" },
                    { 12, "WGM" },
                    { 13, "General Manager" }
                });

            migrationBuilder.InsertData(
                table: "MainAccount",
                columns: new[] { "MainAccountID", "AccountNumber", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, "2013", null, true, "Insurance" },
                    { 2, "2012", null, true, "Inspection" },
                    { 3, "2007", null, true, "Domestic Travel" }
                });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "OfficeID", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, "Johannesburg", true, "JHB" },
                    { 2, "Kimberely", true, "KIM" },
                    { 3, "Cape Town", true, "CPT" }
                });

            migrationBuilder.InsertData(
                table: "Purpose",
                columns: new[] { "PurposeID", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, "Administration", true, "ADM" },
                    { 2, "Regulatory Compliance", true, "RGC" },
                    { 3, "Diamond Trade", true, "DMT" },
                    { 4, null, true, "ZZZ" }
                });

            migrationBuilder.InsertData(
                table: "SubAccount",
                columns: new[] { "SubAccountID", "AccountNumber", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, "0206", null, true, "IT Audit" },
                    { 2, "0045", null, true, "Meeting Fees" },
                    { 3, "0001", null, true, "Accomodation" }
                });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "DivisionId", "DepartmentId", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 4, "Inspectorate", true, "INS" },
                    { 2, 5, "Information Communication Technology", true, "ICT" },
                    { 3, 3, "Governance", true, "LEG" },
                    { 4, 5, "Human Resources", true, "HRE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DivisionId",
                table: "AspNetUsers",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobTitleId",
                table: "AspNetUsers",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfficeId",
                table: "AspNetUsers",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Division_DepartmentId",
                table: "Division",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccount_DivisionId",
                table: "GLAccount",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccount_MainAccountID",
                table: "GLAccount",
                column: "MainAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccount_OfficeId",
                table: "GLAccount",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccount_PurposeID",
                table: "GLAccount",
                column: "PurposeID");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccount_SubAccountID",
                table: "GLAccount",
                column: "SubAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_ApplicantID",
                table: "Requisition",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_FinanceApprovalID",
                table: "Requisition",
                column: "FinanceApprovalID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_FinanceOfficerID",
                table: "Requisition",
                column: "FinanceOfficerID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_GLAccountID",
                table: "Requisition",
                column: "GLAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_IssuerID",
                table: "Requisition",
                column: "IssuerID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_ManagerApprovalID",
                table: "Requisition",
                column: "ManagerApprovalID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_ManagerID",
                table: "Requisition",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_TripStatusId",
                table: "Requisition",
                column: "TripStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Requisition");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GLAccount");

            migrationBuilder.DropTable(
                name: "TripStatus");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MainAccount");

            migrationBuilder.DropTable(
                name: "Purpose");

            migrationBuilder.DropTable(
                name: "SubAccount");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
