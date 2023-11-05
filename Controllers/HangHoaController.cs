using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Reponsitory.Abastract;
using web_api.Reponsitory.Implementation;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly IProductservice _productservice;

        public HangHoaController(IProductservice productservice) {
            _productservice = productservice;
        }
        [HttpGet]
        public IActionResult Get(int s)
        {
            try
            {
                var result = _productservice.GetAll(s);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
