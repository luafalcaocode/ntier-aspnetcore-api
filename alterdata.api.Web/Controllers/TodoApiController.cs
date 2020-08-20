using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alterdata.api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoApiController : ControllerBase
    {
        [HttpGet]
        [Route("Todo")]
        public IActionResult Get()
        {
            return Ok("TESTE");
        }
    }
}
