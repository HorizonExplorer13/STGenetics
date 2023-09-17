using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using STGeneticsTest.Server.Utilities;
using STGeneticsTest.Shared.DTO;
using STGeneticsTest.Shared.Entities;

namespace STGeneticsTest.Server.Controllers
{
    [ApiController]
    [Route("api/AnimalLogs")]
    public class AnimalController : ControllerBase
    {
        private readonly AppDBContext dBContext;

        public AnimalController(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet("GetData")]
        public async Task<ActionResult> GetAnimals([FromQuery] PaginationDTO pagination)
        {
            var dataA = await dBContext.Animals.OrderBy(a => a.Name).Pager(pagination).Include(b=> b.Breed).Include(s => s.Sex).Include(st=>st.Status)
                .Select(a => new AnimalDatatoShowDTO
                {
                    Name = a.Name,
                    Breed = a.Breed.Name,
                    BirthDate = a.BirthDate,
                    Sex = a.Sex.Name,
                    Price = a.Price,
                    Status = a.Status.Name
                })
                .ToListAsync();
            return Ok(dataA);
        }




        [HttpPost("FilterData")]
        public async Task <ActionResult<List<AnimalDatatoShowDTO>>> Filterdata([FromBody] FilterDataDTO FilteredData, [FromQuery] PaginationDTO pagination)
        {
            try
            {
                var filteredData = await GetFilterData(FilteredData);
                return filteredData; 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}"); 
            }

        }

        private async Task <List<AnimalDatatoShowDTO>> GetFilterData(FilterDataDTO filterData)
        {
            int? BreedId = null;
            var breed = await dBContext.Breeds.FirstOrDefaultAsync(b => b.Name == filterData.Breed);
            if (breed != null)
            {
                BreedId = breed.BreedId; 
            }
            else
            {
                BreedId = 0; 
            }

            var query = dBContext.Animals.AsQueryable();
            if (filterData != null)
            {
                query = query.Include(b => b.Breed).Include(s => s.Sex).Include(st => st.Status).Where(x =>
                 (string.IsNullOrEmpty(filterData.Name) || x.Name.Contains(filterData.Name))
                && (string.IsNullOrEmpty(filterData.Breed) || x.BreedId.Equals(BreedId))
                && (!filterData.BirthDate.HasValue || x.BirthDate == filterData.BirthDate)
                && (!filterData.SexId.HasValue || x.SexId == filterData.SexId)
                && (!filterData.Price.HasValue || x.Price == filterData.Price)
                && (!filterData.StatusId.HasValue || x.StatusId == filterData.StatusId)
            );
            }
            return await query.Select(pr => new AnimalDatatoShowDTO
            {
                Name = pr.Name,
                Breed = pr.Breed.Name,
                BirthDate = pr.BirthDate,
                Sex = pr.Sex.Name,
                Price = pr.Price,
                Status = pr.Status.Name
            }).ToListAsync();
            
        }

        [HttpGet("GetNameslist")]
        public async Task<ActionResult<List<string>>> GetNames()
        {
            return await dBContext.Animals.Select(a => a.Name).Distinct().ToListAsync();
        }
        [HttpPost("PostData")]
        public async Task<ActionResult> PostAnimal(AnimalDataCreateDTO animalData)
        {
            var animalC = new Animal
            {
                Name = animalData.Name,
                BreedId = animalData.BreedId,
                BirthDate = animalData.BirthDate,
                SexId = animalData.SexId,
                ProductoImg = animalData.ProductoImg,
                Price = animalData.Price,
                StatusId = animalData.StatusId,
            };
            dBContext.Animals.Add(animalC);
            var result = await dBContext.SaveChangesAsync();
            if (result is 0)
            {
                return BadRequest(result);
            }
            return Ok(animalC);
        }
    }
}
