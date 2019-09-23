using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogHouse.Controllers
{
    [Route("api/[controller]")]
    public class HouseController : ControllerBase
    {
        public async Task<IActionResult> GateState(GateTrigger gateTrigger)
        {
            
        }
    }
}
