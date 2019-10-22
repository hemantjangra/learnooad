using System;
using System.Threading.Tasks;
using DogHouse.DoorHelper;
using DogHouse.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseController : ControllerBase
    {
        private readonly IRemoteOperations _remoteOperations;
        private readonly IBarkOperations _barkOperations;
        public HouseController(IRemoteOperations remoteOperations, IBarkOperations barkOperations)
        {
            _remoteOperations = remoteOperations;
            _barkOperations = barkOperations;
        }
        public string Get()
        {
            return "Running";
        }
        [HttpGet("remote/{id}")]
        public async Task<IActionResult> RemoteOp([FromRoute]Guid id)
        {
            await _remoteOperations.PressButton(id);
            return Ok();
        }

        [HttpGet("bark/{id}")]
        public async Task<IActionResult> BarkOp(Guid id, [FromQuery]string sound)
        {
            await _barkOperations.Bark(id, sound);
            return Ok();
        }
    }
}
