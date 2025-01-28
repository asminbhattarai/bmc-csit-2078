using Microsoft.EntityFrameworkCore;
using StudentModelForm.Models;

namespace StudentModelForm.Data
{
    public class StudentDbContext(DbContextOptions<StudentDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
    }
} 