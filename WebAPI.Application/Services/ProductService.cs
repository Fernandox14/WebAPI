using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;
using WebAPI.Application.DTO;
using WebAPI.Application.Entities.DTO;
using WebAPI.Application.interfaces;
using WebAPI.Application.Validation;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Pagination;
using Response = WebAPI.Domain.Pagination.Response;

namespace WebAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidator<ProductDTO> _validator;
        private readonly IProductRepository _productRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;
        public ProductService(IValidator<ProductDTO> validator,
            IProductRepository productRepository,
            IProviderRepository providerRepository,
            IMapper mapper)
        {
            _validator = validator;
            _productRepository = productRepository;
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        public async Task<Response> Create(ProductDTO model)
        {
            var response = new Response { IsSuccess = true };

            try
            {
                var validation = await _validator.ValidateAsync(model);

                if (!validation.IsValid)
                {
                    response.IsSuccess = false;
                    response.Messages = Util.GetErrors(validation.Errors);
                    return response;
                }

                var product = _mapper.Map<Product>(model);

                var provider = await _providerRepository.GetDocumentAsync(product.Provider!.Document);

                if(provider != null)
                {
                    product.Provider = provider;
                }

                response.Data = await _productRepository.ToSaveAsync(product);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Messages = new List<MessageResult>
                {
                    new MessageResult("Cria Produto", ex.Message)
                };
            }

            return response;
        }

        public async Task<ResponseData> GetAll(RequestData filter)
        {
            var response = new ResponseData { IsSuccess = false };

            try
            {
                var products = await _productRepository.GetAllAsync(
                    $"{filter?.Status}",
                    filter.ProviderDocument,
                    filter.ProviderId
                    );

                var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);


                response.TotalRecords = products.Count();
                response.PageNumber = filter.PageNumber;
                response.PageSize = filter.PageSize;

                response.TotalPages = (int)Math.Ceiling( (response.TotalRecords / (double)response.PageSize) );
                response.IsSuccess = true;
                response.Data = products.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Messages = new List<MessageResult>
                {
                    new MessageResult("", ex.Message)
                };
            }

            return response;
        }

        public async Task<Response> GetById(int Id)
        {
            var response = new Response { IsSuccess = false };

            try
            {
                var prodctModel = await _productRepository.GetByProductAsync(Id);
                var product = _mapper.Map<ProductDTO>(prodctModel);

                response.IsSuccess = true;

                if( prodctModel != null )
                    response.Data = new List<ProductDTO> { product };
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Messages = new List<MessageResult>
                {
                    new MessageResult("", ex.Message)
                };
            }

            return response;
        }

        public async Task<Response> Alter(ProductDTO model)
        {
            var response = new Response { IsSuccess = true };

            try
            {
                var validation = await _validator.ValidateAsync(model);

                if (!validation.IsValid)
                {
                    response.IsSuccess = false;
                    response.Messages = Util.GetErrors(validation.Errors);
                    return response;
                }

                var product = _mapper.Map<Product>(model);

                var provider = await _providerRepository.GetDocumentAsync(product.Provider!.Document);

                if (provider != null)
                {
                    provider.Document = product.Provider.Document;
                    provider.Description = product.Provider.Description;
                    product.Provider = provider;
                }
                else
                {
                    throw new Exception("Fornecedor não encontrado");
                }

                response.Data = await _productRepository.ToUpdateAsync(product);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Messages = new List<MessageResult>
                {
                    new MessageResult("", ex.Message)
                };
            }

            return response;
        }

        public async Task<Response> Delete(int Id)
        {
            var response = new Response { IsSuccess = true };

            try
            {
                var product = await _productRepository.GetByIdAsync(Id);

                if(product == null)
                {
                    throw new Exception("Produto não encontrado");
                }

                if (product.Status == "Inativo")
                {
                    throw new Exception("Não é permitido desativar um produto já desativado");
                }

                product.Status = "Inativo";
                await _productRepository.ToUpdateAsync(product);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Messages = new List<MessageResult>
                {
                    new MessageResult("", ex.Message)
                };
            }

            return response;
        }
    }
}
