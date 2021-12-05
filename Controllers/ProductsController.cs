using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei_Lab5.Database;
using Wsei_Lab5.Entities;
using Wsei_Lab5.Models;
using Wsei_Lab5.Services;

namespace Wsei_Lab5.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult Add(ProductModel product)
        {
            var viewModel = new ProductStatsViewModel
            {
                NameLength = product.Name.Length,
                DescriptionLength = product.Description.Length,
            };

            return View(viewModel);
        }
        */

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel product)
        {
            await _productService.Add(product);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            var products = await _productService.GetItemsByName(name);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Product(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _productService.GetItem((int)id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
