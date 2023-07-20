using Database.Entities;
using InternalApplication.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DBcontext : DbContext
    {
        public DBcontext()
        {

        }
        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {

        }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Positionapplied> Positionapplied { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<ForgotPassword> ForgotPasswords { get; set; }
        public virtual DbSet<UserSign> UserSign { get; set; }
        public virtual DbSet<StudentDetails> StudentDetails { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Native> Natives { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<EmployeeManagement> EmployeeManagements { get; set; }
    }
}

