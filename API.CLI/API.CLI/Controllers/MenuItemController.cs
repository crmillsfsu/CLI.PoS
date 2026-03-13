using API.CLI.Database;
using API.CLI.Enterprise;
using CLI.PoS.Model;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace API.CLI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuItemController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return new MenuItemEC().Items;
        }
    }
}
