using Microsoft.EntityFrameworkCore;

namespace SirSoiProject.Models
{
    public class StudentDB: DbContext
    {
        public StudentDB(DbContextOptions<StudentDB> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
