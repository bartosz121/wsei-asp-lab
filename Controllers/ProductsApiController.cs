using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei_Lab5.Models;

namespace Wsei_Lab5.Controllers
{
    [Route("api/products")]
    public class ProductsApiController : Controller
    {
        [HttpPost]
        public IActionResult Add(ProductModel product)
        {
            return Ok();
        }
    }
}
