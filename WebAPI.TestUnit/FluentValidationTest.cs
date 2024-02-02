using WebAPI.Application.Entities.DTO;
using WebAPI.Application.Validation;

namespace WebAPI.TestUnit
{
    public class FluentValidationTest
    {
        private ProductDTOValidator _validator = new();

        public FluentValidationTest()
        {
            _validator = new ProductDTOValidator();
        }

        [Fact]
        public void VerificaSeADataDeFabricacaoEMaiorQueADataDeValidade()
        {
            var productDTO = new ProductDTO
            {
                DateManufacturing = new DateTime(2024,01,02),
                DateValidation = new DateTime(2024, 01, 01),
                Description = "Chocolate NESTLÉ",
                Status = "Inativo",
                Provider = new ProviderDTO { 
                    Document = 60409075000152,
                    Description = "NESTLÉ BRASIL LTDA",
                }
            };

            var response = _validator.Validate(productDTO);

            Assert.False(response.IsValid);
        }

        [Fact]
        public void VerificaSeADataDeValidadeEMaiorQueAFabricacao()
        {
            var productDTO = new ProductDTO
            {
                DateManufacturing = new DateTime(2024, 01, 01),
                DateValidation = new DateTime(2024, 01, 02),
                Description = "Chocolate NESTLÉ",
                Status = "Inativo",
                Provider = new ProviderDTO
                {
                    Document = 60409075000152,
                    Description = "NESTLÉ BRASIL LTDA",
                }
            };

            var response = _validator.Validate(productDTO);

            Assert.True(response.IsValid);
        }

        [Fact]
        public void VerificaDescricaoDoProdutoNaoEValida()
        {
            var productDTO = new ProductDTO
            {
                DateManufacturing = new DateTime(2024, 01, 01),
                DateValidation = new DateTime(2024, 01, 02),
                Description = string.Empty,
                Status = "Inativo",
                Provider = new ProviderDTO
                {
                    Document = 60409075000152,
                    Description = "NESTLÉ BRASIL LTDA",
                }
            };

            var response = _validator.Validate(productDTO);

            Assert.False(response.IsValid);
        }
        [Fact]
        public void VerificaDescricaoDoFornecedorNaoValida()
        {
            var productDTO = new ProductDTO
            {
                DateManufacturing = new DateTime(2024, 01, 01),
                DateValidation = new DateTime(2024, 01, 02),
                Description = "Chocolate NESTLÉ",
                Status = "Inativo",
                Provider = new ProviderDTO
                {
                    Document = 60409075000152,
                    Description = string.Empty,
                }
            };

            var response = _validator.Validate(productDTO);

            Assert.False(response.IsValid);
        }
        [Fact]
        public void VerificaSeNaoExisteDocumentoFornecedor()
        {
            var productDTO = new ProductDTO
            {
                DateManufacturing = new DateTime(2024, 01, 01),
                DateValidation = new DateTime(2024, 01, 02),
                Description = "Chocolate NESTLÉ",
                Status = "Inativo",
                Provider = new ProviderDTO
                {
                    Document = 0,
                    Description = "NESTLÉ BRASIL LTDA",
                }
            };

            var response = _validator.Validate(productDTO);

            Assert.False(response.IsValid);
        }
        [Fact]
        public void VerificaSeExisteDocumentoFornecedor()
        {
            var productDTO = new ProductDTO
            {
                DateManufacturing = new DateTime(2024, 01, 01),
                DateValidation = new DateTime(2024, 01, 02),
                Description = "Chocolate NESTLÉ",
                Status = "Inativo",
                Provider = new ProviderDTO
                {
                    Document = 60409075000152,
                    Description = "NESTLÉ BRASIL LTDA",
                }
            };

            var response = _validator.Validate(productDTO);

            Assert.True(response.IsValid);
        }
    }
}