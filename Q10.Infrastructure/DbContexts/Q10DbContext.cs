using Microsoft.EntityFrameworkCore;
using Q10.Domain.Entities;

namespace Q10.Infrastructure.DbContexts
{
    public partial class Q10DbContext : DbContext
    {
        public Q10DbContext()
        {
        }

        public Q10DbContext(DbContextOptions<Q10DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectRegistration> SubjectRegistrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
