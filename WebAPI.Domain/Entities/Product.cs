using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime DateManufacturing { get; set; }
        public DateTime DateValidation { get; set; }
        public Provider? Provider { get; set; }
    }
}