using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using RestApi_Demo.Models.Restaurant;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;
        // GET: api/<RestaurantController>
        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantModel>>> Get()
        {
            var result = await _restaurantService.GetRestaurants();

            return Ok(result.Select(x => _mapper.Map<RestaurantModel>(x)).ToList());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantModel>> Get(Guid id)
        {
            var restaurant = await _restaurantService.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RestaurantModel>(restaurant));
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public async Task<ActionResult<RestaurantModel>> Post([FromBody] RestaurantModel restaurant)
        {
            var newR = _mapper.Map<Restaurant>(restaurant);

            await _restaurantService.AddRestaurant(newR);

            return CreatedAtAction(
                nameof(Get),
                new { id = newR.Id },
                _mapper.Map<RestaurantModel>(newR));
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            //var restaurant = await _restaurantService.GetRestaurantById(id);

            //if (restaurant == null)
            //{
            //    return NotFound();
            //}

            try
            {
                var deleteSuceeded = await _restaurantService.DeleteRestaurant(id);

                return deleteSuceeded ? NoContent() : NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
