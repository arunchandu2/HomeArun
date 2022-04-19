using HomeArun.Models;
using HomeLoanArun.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeArun.Data
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext()
        {
        }

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }

        public DbSet<PersonalDetails> Personals { get; set; }
        public DbSet<IncomeDetails> Incomes { get; set; }

        public DbSet<LoanDetails> LoanDetails { get; set; }

        public DbSet<LoanTracker> LoanTrackers { get; set; }
        public  DbSet<UploadedDocument> UploadedDocuments { get; set; }

        public DbSet<Login> logins { get; set; }

        public DbSet<Admin> Admins { get; set; }



    }
}
