using CimeqApi.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace CimeqApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "Home")]
        public Home Index()
        {
            return new Home() { Message = "Hello Word"};
        }
    }
}