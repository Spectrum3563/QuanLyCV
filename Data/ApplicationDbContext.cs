using Microsoft.EntityFrameworkCore;
using QuanLyCV.Models;

namespace QuanLyCV.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<EmployeeCV> EmployeeCVs { get; set; }
    }
}