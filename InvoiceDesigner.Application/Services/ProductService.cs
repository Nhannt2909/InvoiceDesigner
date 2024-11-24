﻿
using AutoMapper;
using InvoiceDesigner.Application.Interfaces;
using InvoiceDesigner.Domain.Shared.DTOs.Product;
using InvoiceDesigner.Domain.Shared.Interfaces;
using InvoiceDesigner.Domain.Shared.Models;
using InvoiceDesigner.Domain.Shared.QueryParameters;
using InvoiceDesigner.Domain.Shared.Responses;

namespace InvoiceDesigner.Application.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;
		private readonly IInvoiceServiceHelper _invoiceServiceHelper;
		private readonly ICurrencyService _currencyService;

		public ProductService(IProductRepository repository,
								IMapper mapper,
								IInvoiceServiceHelper invoiceServiceHelper,
								ICurrencyService currencyService)
		{
			_repository = repository;
			_mapper = mapper;
			_invoiceServiceHelper = invoiceServiceHelper;
			_currencyService = currencyService;
		}

		public async Task<ResponsePaged<ProductsViewDto>> GetPagedProductsAsync(QueryPaged queryPaged)
		{
			queryPaged.PageSize = Math.Max(queryPaged.PageSize, 1);
			queryPaged.Page = Math.Max(queryPaged.Page, 1);

			var productsTask = _repository.GetProductsAsync(queryPaged, GetOrdering(queryPaged.SortLabel));
			var totalCountTask = _repository.GetCountProductsAsync(queryPaged.ShowDeleted);

			await Task.WhenAll(productsTask, totalCountTask);

			var productsDto = _mapper.Map<IReadOnlyCollection<ProductsViewDto>>(await productsTask);
			var result = new ResponsePaged<ProductsViewDto>
			{
				Items = productsDto,
				TotalCount = await totalCountTask
			};

			return result;
		}

		public async Task<ResponseRedirect> CreateProductAsync(ProductEditDto productEditDto)
		{
			var existsProduct = new Product();
			await MapProduct(existsProduct, productEditDto);

			var entityId = await _repository.CreateProductAsync(existsProduct);

			return new ResponseRedirect
			{
				RedirectUrl = "/Products"
			};
		}

		public Task<Product> GetProductByIdAsync(int id) => ValidateExistsEntityAsync(id);

		public async Task<ProductEditDto> GetProductEditDtoByIdAsync(int id)
		{
			var existsProduct = await ValidateExistsEntityAsync(id);
			return _mapper.Map<ProductEditDto>(existsProduct);
		}

		public async Task<ResponseRedirect> UpdateProductAsync(ProductEditDto productEditDto)
		{
			var existsProduct = await ValidateExistsEntityAsync(productEditDto.Id);
			await MapProduct(existsProduct, productEditDto);

			var entityId = await _repository.UpdateProductAsync(existsProduct);
			return new ResponseRedirect
			{
				RedirectUrl = "/Products"
			};
		}

		public async Task<ResponseBoolean> DeleteProductAsync(int id)
		{
			var existsProduct = await ValidateExistsEntityAsync(id);

			if (await _invoiceServiceHelper.IsProductUsedInInvoiceItems(id))
				throw new InvalidOperationException($"Product {existsProduct.Name} is in use in Invoices and cannot be deleted.");

			return new ResponseBoolean
			{
				Result = await _repository.DeleteProductAsync(existsProduct)
			};
		}

		public async Task<ResponseBoolean> DeleteOrMarkAsDeletedAsync(int id, int modeDelete)
		{
			if (modeDelete == 0)
			{
				var existsEntity = await ValidateExistsEntityAsync(id);
				existsEntity.IsDeleted = true;

				await _repository.UpdateProductAsync(existsEntity);

				return new ResponseBoolean { Result = true };
			}
			return await DeleteProductAsync(id);
		}

		public Task<int> GetCountProductsAsync() => _repository.GetCountProductsAsync();

		public async Task<IReadOnlyCollection<ProductAutocompleteDto>> FilteringData(string searchText)
		{
			var queryPaged = new QueryPaged
			{
				PageSize = 10,
				Page = 1,
				SearchString = searchText
			};

			var products = await _repository.GetProductsAsync(queryPaged, GetOrdering("Value"));
			return _mapper.Map<IReadOnlyCollection<ProductAutocompleteDto>>(products);
		}

		private async Task<Product> ValidateExistsEntityAsync(int id)
		{
			var existsProduct = await _repository.GetProductByIdAsync(id)
				?? throw new InvalidOperationException("Product not found");
			return existsProduct;
		}

		private async Task MapProduct(Product existsProduct, ProductEditDto dto)
		{
			existsProduct.Name = dto.Name.Trim();

			List<ProductPrice> newProductPrices = new List<ProductPrice>();

			foreach (var productPrice in dto.ProductPrice)
			{
				var currency = await _currencyService.GetCurrencyByIdAsync(productPrice.Currency.Id)
								?? throw new InvalidOperationException($"Currency with ID {productPrice.Id} not found.");

				newProductPrices.Add(new ProductPrice
				{
					ProductId = existsProduct.Id,
					CurrencyId = currency.Id,
					Currency = currency,
					Price = productPrice.Price,
				});
			}
			existsProduct.ProductPrice = newProductPrices;
		}

		private Func<IQueryable<Product>, IOrderedQueryable<Product>> GetOrdering(string sortLabel)
		{
			var sortingOptions = new Dictionary<string, Func<IQueryable<Product>, IOrderedQueryable<Product>>>
			{
				{ "Id_desc", q => q.OrderByDescending(e => e.Id) },
				{ "Name", q => q.OrderBy(e => e.Name) },
				{ "Name_desc", q => q.OrderByDescending(e => e.Name) }
			};

			return sortingOptions.TryGetValue(sortLabel, out var orderFunc) ? orderFunc : q => q.OrderBy(e => e.Id);
		}
	}
}
