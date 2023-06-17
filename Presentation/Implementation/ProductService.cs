
using AutoMapper;
using Contracts.DTOs;
using Contracts.Interfaces;
using Domain.Entities;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class ProductService: IProductService
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;
        public ProductService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper= repositoryWrapper;
            _mapper= mapper;
        }

        public CreateProductDto CreateProduct(CreateProductDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _repositoryWrapper.productRepository.CreateProduct(productEntity);
            _repositoryWrapper.Save();

            var ProductToReturn = _mapper.Map<CreateProductDto>(productEntity);
            return ProductToReturn;
        }

        public void DeleteProduct(int productId, bool trackChanges)
        {
            var product = _repositoryWrapper.productRepository.GetProduct(productId, trackChanges);
            if(product == null)
            {
                throw new Exception("empty");
            }
            _repositoryWrapper.productRepository.DeleteProduct(product);
            _repositoryWrapper.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            try
            {
                var products = _repositoryWrapper.productRepository.GetAllProducts(trackChanges);
                return products;
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<Product>();
            }
        }

        public GetOneProductDto GetProduct(int productId, bool trackChanges)
        {
            var product = _repositoryWrapper.productRepository.GetProduct(productId, trackChanges);
            //Check if the company is null
            var productDto = _mapper.Map<GetOneProductDto>(product);
            return productDto;

        }

        public IEnumerable<GetProductDto> GetProducts(bool trackChanges)
        {
            try
            {
                var products = _repositoryWrapper.productRepository.GetAllProducts(trackChanges);
                var productsDto = products.Select(p =>
                        new GetProductDto(p.ProductId, p.Name, string.Join(' ', p.Category, p.Description))).ToList();
                return productsDto;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public async Task UpdateProduct(int productId, UpdateProductDto productUpdate, bool trackChanges)
        {
            var productEntityId = _mapper.Map<Product>(productUpdate);
            _repositoryWrapper.productRepository.GetProduct(productId, trackChanges);
            if (productEntityId.ProductId != productUpdate.ProductId)
            {
                throw new Exception();
            }

         /*   var productEntity = _mapper.Map<Product>(productUpdate);
              _repositoryWrapper.productRepository.UpdateProduct(productEntity);*/

            _mapper.Map(productUpdate, productEntityId);
             _repositoryWrapper.Save();
        }
    }
}
