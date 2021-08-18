using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult Post()
        {
            
            return Ok();
        }
    }
}
