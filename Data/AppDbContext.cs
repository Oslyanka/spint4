using Microsoft.EntityFrameworkCore;
using SwaggerSchoolAPI.Models;

namespace SwaggerSchoolAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos => Set<Aluno>();
        public DbSet<Professor> Professores => Set<Professor>();
        public DbSet<Disciplina> Disciplinas => Set<Disciplina>();
        public DbSet<Matricula> Matriculas => Set<Matricula>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Professor)
                .WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno)
                .WithMany(a => a.Matriculas)
                .HasForeignKey(m => m.AlunoId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Disciplina)
                .WithMany(d => d.Matriculas)
                .HasForeignKey(m => m.DisciplinaId);
        }
    }
}
