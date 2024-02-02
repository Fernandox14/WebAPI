using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class FilterQueryDTO
    {
        public int ProductId { get; set; }
        public bool Status { get; set; }
        public string? ProviderName { get; set; }
        public string? ProviderDocument { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }

    }
}
