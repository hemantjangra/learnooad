using HeadFirst.FirstIteration.Interface;
using HeadFirst.FirstIteration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HeadFirst.FirstIteration.Enums;
using HeadFirst.FirstIteration.Models;

namespace HeadFirst.Controllers
{
    [Route("api/{controller}")]
    public class GuitarsController : ControllerBase
    {
        private readonly IInventory _inventory;
        public GuitarsController(IInventory inventory)
        {
            _inventory = inventory;
        }
        [HttpGet]
        [Route("getGuitar")]
        public List<Guitar> GetGuitar()
        {
            GuitarSpec whatErinLikes = new GuitarSpec{Builder=Builder.Fendor, Model="Stratocastor", Type=Type.Electric, BackWood=Wood.Alder, TopWood=Wood.Alder, NumString = "12"};
            var guitars = _inventory.SearchGuitar(whatErinLikes);
            return guitars;
        }
    }
}