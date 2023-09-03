

namespace BrasilApi.Models
{
    public class Logs
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Method { get; set; }
        public string ApiOrigem { get; set; }
        public string ApiDestino { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
