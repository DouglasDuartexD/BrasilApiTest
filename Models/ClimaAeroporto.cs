using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrasilApi.Models
{
    public class ClimaAeroporto
    {
        public int Id { get; set; }

        [JsonProperty("umidade")]
        public int Umidade { get; set; }

        [JsonProperty("visibilidade")]
        public string Visibilidade { get; set; }

        [JsonProperty("codigo_icao")]
        public string CodigoICAO { get; set; }

        [JsonProperty("pressao_atmosferica")]
        public int PressaoAtmosferica { get; set; }

        [JsonProperty("vento")]
        public int Vento { get; set; }

        [JsonProperty("direcao_vento")]
        public int DirecaoVento { get; set; }

        [JsonProperty("condicao")]
        public string Condicao { get; set; }

        [JsonProperty("condicao_desc")]
        public string CondicaoDescricao { get; set; }

        [JsonProperty("temp")]
        public int Temperatura { get; set; }

        [JsonProperty("atualizado_em")]
        public DateTime AtualizadoEm { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
