using BLL;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OsobyController : ControllerBase
    {
        private readonly IOsobyService _osobyService;

        public OsobyController(IOsobyService osobyService)
        {
            _osobyService = osobyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<OsobaDTO> Get()
        {
            return _osobyService.Get();
        }

        [HttpGet("{id}")]
        public OsobaDTO GetByID(int id)
        {
            return _osobyService.GetByID(id);
        }

        [HttpPost]
        public void Post([FromBody] OsobaPostDTO osobaPostDTO)
        {
            _osobyService.Post(osobaPostDTO);
        }
    }
}
