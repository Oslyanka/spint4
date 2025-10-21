using Microsoft.AspNetCore.Mvc;
using SwaggerSchoolAPI.Models;
using SwaggerSchoolAPI.Repositories;

namespace SwaggerSchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        private readonly IRepository<Professor> _repo;
        public ProfessoresController(IRepository<Professor> repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity is null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professor p)
        {
            var created = await _repo.AddAsync(p);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Professor p)
        {
            if (id != p.Id) return BadRequest();
            var exists = await _repo.GetByIdAsync(id);
            if (exists is null) return NotFound();
            await _repo.UpdateAsync(p);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _repo.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
