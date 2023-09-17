using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STGeneticsTest.Shared.DTO;
using STGeneticsTest.Shared.Entities;

namespace STGeneticsTest.Server.Controllers
{
    [ApiController]
    [Route("api/BreedLogs")]
    public class BreedController : ControllerBase
    {
        private readonly AppDBContext dBContext;

        public BreedController(AppDBContext dBContext) {
            this.dBContext = dBContext;
        }

        [HttpGet("GetData")]
        public async Task<ActionResult> GetBreed()
        {
            var dataB = await dBContext.Breeds.ToListAsync();
            return Ok(dataB);
        }

        [HttpGet("GetBreedNames")]
        public async Task<ActionResult<List<string>>> GetNames()
        {
            return await dBContext.Breeds.Select(a => a.Name).Distinct().ToListAsync();
        }
        [HttpPost("PostData")]
        public async Task<ActionResult> PostBreed(BreedDataCreateDTO breedData)
        {
            var breedC = new Breed
            {
                Name = breedData.Name,
            };
            dBContext.Breeds.Add(breedC);
            var result = await dBContext.SaveChangesAsync();
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(breedC);

        }

        
    }
}
