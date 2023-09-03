using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrasilApi.Models
{
    public class ClimaCidade
    {
        public int Id { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("atualizado_em")]
        public DateTime AtualizadoEm { get; set; }

        [JsonProperty("clima")]
        public List<PrevisaoClimaCidade> Clima { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class PrevisaoClimaCidade
    {
        public int Id { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        [JsonProperty("condicao")]
        public string Condicao { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("indice_uv")]
        public int IndiceUV { get; set; }

        [JsonProperty("condicao_desc")]
        public string CondicaoDescricao { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
