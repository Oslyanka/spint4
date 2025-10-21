using Microsoft.AspNetCore.Mvc;

namespace SwaggerSchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IntegracoesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IntegracoesController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        /// <summary>
        /// Lista os estados do Brasil a partir da API pública do IBGE.
        /// </summary>
        [HttpGet("ibge/estados")]
        public async Task<IActionResult> GetEstados()
        {
            var client = _httpClientFactory.CreateClient();
            var resp = await client.GetAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
            var json = await resp.Content.ReadAsStringAsync();
            return Content(json, "application/json");
        }
    }
}
