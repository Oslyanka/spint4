namespace SwaggerSchoolAPI.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public DateTime DataMatricula { get; set; } = DateTime.UtcNow;
        public Aluno? Aluno { get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}
