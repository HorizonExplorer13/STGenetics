using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace STGeneticsTest.Server.Controllers
{
    [ApiController]
    [Route("api/Utils")]
    public class SexandStatusController : ControllerBase
    {
        private readonly AppDBContext dBContext;

        public SexandStatusController(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet("Sex")]
        public async Task<ActionResult> GetSexData()
        {
            var data = await dBContext.Sex.ToListAsync();
            return Ok(data);
        }
        [HttpGet("Status")]
        public async Task<ActionResult> GetStatusData()
        {
            var data = await dBContext.Status.ToListAsync();
            return Ok(data);
        }
    }
}
