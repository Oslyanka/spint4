using Microsoft.AspNetCore.Mvc;
using SwaggerSchoolAPI.Models;
using SwaggerSchoolAPI.Repositories;
using SwaggerSchoolAPI.Services;

namespace SwaggerSchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IRepository<Aluno> _repo;
        private readonly AlunoService _service;

        public AlunosController(IRepository<Aluno> repo, AlunoService service)
        {
            _repo = repo;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aluno = await _repo.GetByIdAsync(id);
            return aluno is null ? NotFound() : Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            var created = await _repo.AddAsync(aluno);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Aluno aluno)
        {
            if (id != aluno.Id) return BadRequest();
            var exists = await _repo.GetByIdAsync(id);
            if (exists is null) return NotFound();
            await _repo.UpdateAsync(aluno);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _repo.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }

        // LINQ searches
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? nome)
            => Ok(await _service.SearchByNomeAsync(nome));

        [HttpGet("ranking-matriculas")]
        public async Task<IActionResult> RankingMatriculas()
            => Ok(await _service.RankingMatriculasAsync());
    }
}
