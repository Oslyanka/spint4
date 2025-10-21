namespace SwaggerSchoolAPI.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    }
}
