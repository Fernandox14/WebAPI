using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Entities.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime DateManufacturing { get; set; }
        public DateTime DateValidation { get; set; }
        public ProviderDTO? Provider { get; set; }
    }
}