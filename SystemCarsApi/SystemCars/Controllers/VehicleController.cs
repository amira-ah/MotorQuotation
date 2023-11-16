using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemCars.Data.Models;
using Microsoft.Extensions.Configuration;
using SystemCars.Data.Services;
namespace SystemCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        protected const string SuccessCode = "sucess";
        protected const string ErrorCode = "false";
        protected const string ErrorMessage = "couldntConnect";
        public vehicleService _vehicleService;

        public VehicleController(vehicleService vehicleService)
        {
            _vehicleService=vehicleService;
        }
        [HttpGet]
        [Route("get-car-details")]
        public async Task<IActionResult> GetCarDetails([FromQuery(Name = "searchItem")] string? searchItem,
            [FromQuery(Name = "page")] int? page, 
            [FromQuery(Name = "pagesize")]  int? pagesize, 
            [FromQuery(Name = "sortOrder")] string? sortOrder, 
            [FromQuery(Name = "sortColumn")] string? sortColumn)
        {
            var sentReqsearchItem = HttpContext.Request.Query["searchItem"].ToString();
            var sentReqpage = HttpContext.Request.Query["page"].ToString();
            var sentReqpagesize = HttpContext.Request.Query["pagesize"].ToString();
            var sentReqsortOrder = HttpContext.Request.Query["sortOrder"].ToString();
            var sentReqsortColumn = HttpContext.Request.Query["sortColumn"].ToString();
            return Ok(await _vehicleService.GetData(searchItem, sentReqpage, sentReqpagesize, sentReqsortOrder, sentReqsortColumn));

        }
    }
}
