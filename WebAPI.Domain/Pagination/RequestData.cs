
using System.Text.Json.Serialization;

namespace WebAPI.Domain.Pagination
{
    public class RequestData
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductStatus Status { get; set; }
        public int ProviderId { get; set; }
        public long ProviderDocument { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public RequestData()
        {
            PageNumber = PageNumber <= 0 ? 1 : PageNumber;
            PageSize = PageSize <= 0 ? 10 : PageSize;
        }

        public enum ProductStatus
        {
            Ativo,
            Inativo
        }
    }
}
