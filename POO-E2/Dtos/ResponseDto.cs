using System.Text.Json.Serialization;

namespace POO_E2.Dtos
{
    public class ResponseDto<T>
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}