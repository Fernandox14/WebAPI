using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Application.Entities.DTO
{
    public class ProviderDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Description { get; set; }
        public long? Document { get; set; }
    }
}
