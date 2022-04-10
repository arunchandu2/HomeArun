using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeArun.Migrations
{
    public partial class createHome1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedAmount = table.Column<double>(type: "float", nullable: false),
                    RetirementAge = table.Column<int>(type: "int", nullable: false),
                    OrganizationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxAmountGrantable = table.Column<double>(type: "float", nullable: true),
                    InterestRate = table.Column<double>(type: "float", nullable: true),
                    tenure = table.Column<int>(type: "int", nullable: true),
                    TotalLoanAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "LoanTrackers",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTrackers", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDocuments",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PanCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalarySlip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Noc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agreement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentverifiedStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    LoanApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDocuments", x => x.ApplicationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "LoanTrackers");

            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "UploadedDocuments");
        }
    }
}
