using BrasilApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api/clima")]
public class ClimaCidadeController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ClimaService _climaService;
    private readonly ApplicationDbContext _dbContext;

    public ClimaCidadeController(IHttpClientFactory httpClientFactory, ClimaService climaService, ApplicationDbContext dbContext)
    {
        _httpClientFactory = httpClientFactory;
        _climaService = climaService;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Busca dados de clima de uma cidade especifica.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Clima da cidade</returns>
    /// <remarks>
    /// Requisição de exemplo usando o cityCode "4751":
    ///
    ///     Method/GET 
    ///      {
    ///        "id": 7,
    ///        "cidade": "São Benedito do Rio Preto",
    ///        "estado": "MA",
    ///        "atualizadoEm": "2023-09-03T00:00:00",
    ///        "clima": [
    ///         {
    ///          "id": 2,
    ///          "data": "2023-09-04T00:00:00",
    ///          "condicao": "pn",
    ///          "min": 23,
    ///          "max": 36,
    ///          "indiceUV": 12,
    ///          "condicaoDescricao": "Parcialmente Nublado",
    ///          "createdAt": "2023-09-03T18:51:37.9844626-03:00"
    ///         }
    ///        ],
    ///        "createdAt": "2023-09-03T18:51:37.9844675-03:00" 
    ///      }
    /// </remarks>
    [HttpGet("cidade/{cityCode}")]
    [ProducesResponseType(typeof(ClimaCidade), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetClimaCidade(string cityCode)
    {
        try
        {
            var routeApi = "clima/previsao/";
            var clientApi = _httpClientFactory.CreateClient("BrasilApi");
            var response = await clientApi.GetAsync($"{routeApi}{cityCode}");
            Uri uri = clientApi.BaseAddress;

            if (response.IsSuccessStatusCode)
            {
                var climaJson = await response.Content.ReadAsStringAsync();
                var clima = JsonConvert.DeserializeObject<ClimaCidade>(climaJson);

                await _climaService.SalvarClimaCidade(clima);

                Console.WriteLine(clima);

                return Ok(clima);
            }
            else
            {
                var errorLog = new Logs
                {
                    StatusCode = (int)response.StatusCode,
                    ApiOrigem = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}",
                    ApiDestino = $"{uri.ToString()}{routeApi}{cityCode}",
                    CreatedAt = DateTime.Now,
                    Request = cityCode,
                    Method = HttpContext.Request.Method,
                    Message = response.ReasonPhrase
                };

                try
                {
                    _dbContext.Logs.Add(errorLog);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao salvar o log no banco de dados:");
                    Console.WriteLine(ex.ToString());
                    return StatusCode(500, "Erro interno do servidor ao salvar o log.");
                }

                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro não tratado:");
            Console.WriteLine(ex.ToString());
            return BadRequest("Erro interno do servidor.");
        }
    }
}
