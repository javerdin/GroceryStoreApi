using GroceryStoreApi.Models;
using GroceryStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace GroceryStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroceryController : ControllerBase
    {
        private readonly GroceryService _groceryService;

        public GroceryController(GroceryService groceryService) => _groceryService = groceryService;

        [HttpGet]
        public async Task<List<Grocery>> Get() =>
            await _groceryService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Grocery>> Get(string id)
        {
            var grocery = await _groceryService.GetAsync(id);

            if (grocery is null)
            {
                return NotFound();
            }
            return grocery;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Grocery newGrocery)
        {
            await _groceryService.CreateAsync(newGrocery);

            return CreatedAtAction(nameof(Get), new { id = newGrocery.Id }, newGrocery);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Grocery updateGrocery)
        {
            var grocery = await _groceryService.GetAsync(id);

            if (grocery is null)
            {
                return NotFound();
            }

            updateGrocery.Id = grocery.Id;

            await _groceryService.UpdateAsync(id, updateGrocery);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var grocery = await _groceryService.GetAsync(id);

            if (grocery is null)
            {
                return NotFound();
            }

            await _groceryService.RemoveAsync(id);

            return NoContent();
        }

    }
}
