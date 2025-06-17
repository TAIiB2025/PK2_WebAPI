using BLL;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoryzacjaController : ControllerBase
    {
        private readonly IAutoryzacjaService _autoryzacjaService;

        public AutoryzacjaController(IAutoryzacjaService autoryzacjaService)
        {
            _autoryzacjaService = autoryzacjaService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginFormDTO loginFormDTO)
        {
            try
            {
                return Ok(_autoryzacjaService.Login(loginFormDTO));
            } catch(ApplicationException e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
