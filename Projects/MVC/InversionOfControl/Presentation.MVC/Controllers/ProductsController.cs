using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Domain;
using Domain.Dto;
using Repository.Interfaces;

namespace Presentation.MVC.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Products
        public ActionResult Index()
        {
            var dtos = _productRepository.GetProductsToManage(null);
            return View(dtos);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
                return View(productDto);

         

            var product = new Product(productDto.Name,
                productDto.Description, productDto.Price, productDto.Ranking,
               new List<string> {"0"});

            _productRepository.Save(product);


          return  RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProduct(long productId)
        {
            var product = _productRepository.Get<Product>(productId);

            var productDto = new ProductDetailsDto
            {
                ProductId = product.Id,
                Description = product.Description,
                CategoryCount = product.CategoryCount,
                ProductName = product.Name

            };

            return View(productDto);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductDetailsDto productDto)
        {
            var product = _productRepository.Get<Product>(productDto.ProductId);

            product.Name = productDto.ProductName;

            _productRepository.Save(product);

            return RedirectToAction("Index");
        }

    }
}