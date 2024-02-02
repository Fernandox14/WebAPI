using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Pagination
{
    public class ResponseData
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public List<MessageResult>? Messages { get; set; }
    }
}
