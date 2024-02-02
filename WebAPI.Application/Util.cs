using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Pagination;

namespace WebAPI.Application
{
    public class Util
    {
        public static List<MessageResult>? GetErrors(List<ValidationFailure> erros)
        {
            return erros?.Select(error => new MessageResult(error.PropertyName, error.ErrorMessage)).ToList();
        }
    }
}
