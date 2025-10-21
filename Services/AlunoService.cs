using Microsoft.EntityFrameworkCore;
using SwaggerSchoolAPI.Data;
using SwaggerSchoolAPI.Models;

namespace SwaggerSchoolAPI.Services
{
    public class AlunoService
    {
        private readonly AppDbContext _ctx;

        public AlunoService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Aluno>> SearchByNomeAsync(string? nome)
        {
            nome ??= string.Empty;
            return await _ctx.Alunos
                .Where(a => a.Nome.ToLower().Contains(nome.ToLower()))
                .OrderBy(a => a.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> RankingMatriculasAsync()
        {
            // LINQ: agrupamento por aluno com contagem de matrículas
            return await _ctx.Matriculas
                .GroupBy(m => m.AlunoId)
                .Select(g => new {
                    AlunoId = g.Key,
                    Quantidade = g.Count()
                })
                .OrderByDescending(x => x.Quantidade)
                .ToListAsync();
        }
    }
}
