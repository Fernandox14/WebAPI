using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Domain.Entities
{
    public class Provider
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Description { get; set; }
        public long Document { get; set; }

        [JsonIgnore]
        public ICollection<Product>? Product { get; set; }
    }
}
