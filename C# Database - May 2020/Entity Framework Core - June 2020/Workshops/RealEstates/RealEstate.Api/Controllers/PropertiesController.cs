using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.DataTransferObject;
using System.Linq;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertiesService _propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this._propertiesService = propertiesService;
        }

        [HttpGet]
        public IActionResult Get(int count = 5)
        {
            var result = this._propertiesService.GetAll(count).Result;

            return Ok(result);
        }

        [HttpGet("ByPrice")]
        public IActionResult Get(int minPrice, int maxPrice, int count)
        {
            var result = this._propertiesService.SearchByPrice(minPrice, maxPrice).Result.Take(count);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<PropertyViewModel> Create(PropertyCreateDto model)
        {
            var result = this._propertiesService.CreateOne(model);

            return Ok(result);
        }
    }
}
