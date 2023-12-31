﻿using BrasilApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


[ApiController]
[Route("api/clima")]
public class ClimaAeroportoController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ClimaService _climaService;
    private readonly ApplicationDbContext _dbContext;

    public ClimaAeroportoController(IHttpClientFactory httpClientFactory, ClimaService climaService, ApplicationDbContext dbContext)
    {
        _httpClientFactory = httpClientFactory;
        _climaService = climaService;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Busca dados de clima de um aeroporto especifico.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Clima do aeroporto</returns>
    /// <remarks>
    /// Requisição de exemplo usando codigoICAO "SBAR":
    ///
    ///     Method/GET
    ///      {
    ///        "id": 7,
    ///        "umidade": 70,
    ///        "visibilidade": ">10000",
    ///        "codigoICAO": "SBAR",
    ///        "pressaoAtmosferica": 1015,
    ///        "vento": 18,
    ///        "direcaoVento": 80,
    ///        "condicao": "ps",
    ///        "condicaoDescricao": "Predomínio de Sol",
    ///        "temperatura": 27,
    ///        "atualizadoEm": "2023-09-03T16:00:00.23Z",
    ///        "createdAt": "2023-09-03T18:40:26.3244506-03:00"
    ///      }
    ///
    /// </remarks>
    [HttpGet("aeroporto/{icaoCode}")]
    [ProducesResponseType(typeof(ClimaAeroporto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetClimaAeroporto(string icaoCode)
    {
        try
        {
            var routeApi = "clima/aeroporto/";
            var clientApi = _httpClientFactory.CreateClient("BrasilApi");
            var response = await clientApi.GetAsync($"{routeApi}{icaoCode}");
            Uri uri = clientApi.BaseAddress;

            if (response.IsSuccessStatusCode)
            {
                var climaJson = await response.Content.ReadAsStringAsync();
                var clima = JsonConvert.DeserializeObject<ClimaAeroporto>(climaJson);

                await _climaService.SalvarClimaAeroporto(clima);

                Console.WriteLine(clima);

                return Ok(clima);
            }
            else
            {
                var errorLog = new Logs
                {
                    StatusCode = (int)response.StatusCode,
                    ApiOrigem = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}",
                    ApiDestino = $"{uri.ToString()}{routeApi}{icaoCode}",
                    CreatedAt = DateTime.Now,
                    Request = icaoCode,
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
