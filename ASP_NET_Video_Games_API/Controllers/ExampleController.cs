using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ExampleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var gamePublishers = _context.VideoGames.Select(vg => vg.Publisher).Distinct();
            return Ok(gamePublishers);
        }

        [HttpGet("{pubName}")]
        public IActionResult GetGamesByPublisher(string pubName)
        {
            var gamesByPublisher = _context.VideoGames.Where(vg => vg.Publisher == pubName);
            return Ok(gamesByPublisher);
        }
    }
}
