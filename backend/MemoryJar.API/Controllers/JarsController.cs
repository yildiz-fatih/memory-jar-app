using MemoryJar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoryJar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JarsController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public JarsController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jars = await _ctx.Jars
                .Select(j => new { j.Id, j.Name, j.IsPublic })
                .ToListAsync();
            return Ok(jars);
        }
    }
}