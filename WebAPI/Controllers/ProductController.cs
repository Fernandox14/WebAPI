
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebAPI.Application;
using WebAPI.Application.DTO;
using WebAPI.Application.Entities.DTO;
using WebAPI.Application.interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Pagination;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseData), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseData), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] RequestData request)
        {
            return Ok(await _productService.GetAll(request));
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _productService.GetById(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO product)
        {
            var response = await _productService.Create(product);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDTO product)
        {
            var response = await _productService.Alter(product);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.Delete(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
    }
}
