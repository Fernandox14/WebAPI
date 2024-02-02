
using WebAPI.Application.Entities.DTO;
using WebAPI.Domain.Pagination;

namespace WebAPI.Application.interfaces
{
    public interface IProductService
    {
        Task<Response> Create(ProductDTO model);
        Task<ResponseData> GetAll(RequestData requestData);
        Task<Response> GetById(int Id);
        Task<Response> Alter(ProductDTO model);
        Task<Response> Delete(int Id);
    }
}
