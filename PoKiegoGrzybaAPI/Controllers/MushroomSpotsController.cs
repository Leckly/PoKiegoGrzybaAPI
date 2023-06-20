using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using PoKiegoGrzybaAPI.Data;
using PoKiegoGrzybaAPI.Data.Req;
using PoKiegoGrzybaAPI.Data.Response;
using PoKiegoGrzybaAPI.Models;

namespace PoKiegoGrzybaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MushroomSpotsController : ControllerBase
    {
        private readonly PoKiegoGrzybaDbContext context;
        public ILogger<MushroomSpotsController> _logger;

        public MushroomSpotsController(PoKiegoGrzybaDbContext context, ILogger<MushroomSpotsController> logger)
        {
            this.context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpot([FromBody] MushroomSpotAdd mushroomSpotAdd)
        {
            try
            {
                var item = new MushroomSpot()
                {
                    Description = mushroomSpotAdd.Description,
                    Latitude = mushroomSpotAdd.Latitude,
                    Longitude = mushroomSpotAdd.Longitude,
                    MushroomHunterId = mushroomSpotAdd.UserID,
                    SpotName = mushroomSpotAdd.SpotName
                };
                await context.MushroomSpot.AddAsync(item);
                await context.SaveChangesAsync();
                return Ok(item);
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUserSpots([FromQuery] long id)
        {
            try
            {
                var items = context.MushroomSpot.Where(x => x.MushroomHunterId == id).ToList();
                return Ok(items);
            }
            catch(Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpot([FromBody] MushroomSpotUpdate mushroomSpotUpdate)
        {
            try
            {
                var item = context.MushroomSpot.FirstOrDefault(x => x.Id == mushroomSpotUpdate.ID);
                if (item != null)
                {
                    item.Longitude = mushroomSpotUpdate.Longitude;
                    item.Latitude = mushroomSpotUpdate.Latitude;
                    item.SpotName = mushroomSpotUpdate.SpotName;
                    item.Description = mushroomSpotUpdate.Description;
                    await context.SaveChangesAsync();
                }
                else
                {
                    return NotFound(new ErrorMessage()
                    {
                        Message = "There is no spot with that Id"
                    });
                }
            }catch(Exception ex)
            {
                return Conflict(ex);
            }
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpot([FromQuery] long id)
        {
            try
            {
                var item = context.MushroomSpot.FirstOrDefault(x => x.Id == id);
                context.MushroomSpot.Remove(item);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return Conflict(ex);
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetSpots()
        {
            return Ok(context.MushroomSpot.ToList());
        }
    }
}
