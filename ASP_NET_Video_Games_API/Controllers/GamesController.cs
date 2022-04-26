using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_Video_Games_API.Data;

namespace ASP_NET_Video_Games_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        //insantiating database info into variable
        private readonly ApplicationDbContext _context;

        //creating contructor
        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetGames()
        {
            var videoGames = _context.VideoGames;
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public IActionResult GetGamesById(int id)
        {
            var videoGames = _context.VideoGames.Where(vg => vg.Id == id);
            return Ok(videoGames);
        }

        [HttpGet("search/{searchTerm}")]
        public IActionResult GetGames(string searchTerm)
        {
            var videoGames = _context.VideoGames.Where(vg => vg.Name.Contains(searchTerm));
            return Ok(videoGames);
        }
    }
}



















////creating an endpoint starts with defining what type of endpoint it will be as seen below in the attribute '[HttpGet]'
//[HttpGet]
////For every endpoint IActionResult will be the return type of the function
//public IActionResult GetPublishers()
//{
//    //We use var which is a runtime determined variable                     .Distinct() returns only a single publisher in the result
//    var videoGamePublishers = _context.VideoGames.Select(vg => vg.Publisher).Distinct();

//    //The Ok method will send a 200 status code
//    return Ok(videoGamePublishers);
//}
