using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_api.Services;

namespace core_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ProductService _productService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public Product Get(int id)
        {
            return _productService.FindProduct(id);
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
    }
}
