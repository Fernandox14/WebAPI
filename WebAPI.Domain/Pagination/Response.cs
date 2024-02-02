using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Pagination
{
    public class Response
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public List<MessageResult>? Messages { get; set; }
    }
}
