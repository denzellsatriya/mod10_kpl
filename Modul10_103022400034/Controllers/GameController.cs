
using Microsoft.AspNetCore.Mvc;
using Modul10_103022400034;
namespace Modul10_103022400034.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static List<Game> Games = new List<Game>
        {
            new Game{id = 1, Nama= "Valorant", Developer= "Riot Games", TahunRilis= 2020, Genre= "FPS",Rating= 8.5,
                 Platform="PC", Mode="Multiplayer",  isOnline=true, Harga=0},

            new Game{id=2, Nama = "GTA V", Developer = "Rockstar Games", TahunRilis= 2013, Genre = "Open World", Rating =9.5,
                Platform= "PC, PS4, PS5, Xbox", Mode ="Singleplayer, Multiplayer", isOnline= true, Harga=300000},

            new Game{id=3, Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis= 2015, Genre = "RPG", Rating =9.7,
                Platform="PC, PS4, PS5, Xbox, Switch", Mode ="Singleplayer", isOnline= false, Harga=250000}
        };

        //GET /api/Game
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Games;
        }

        //GET api/Game/{id}
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            if (id < 0 || id >= Games.Count) return NotFound();
            return Games[id];
        }

        //POST /api/Game
        [HttpPost]
        public ActionResult<Game> Create([FromBody] Game newGame)
        {
            Games.Add(newGame);
            return Ok(newGame);
        }
        
        //PUT /api/Game/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, Game newGame)
        {
            var index = Games.FindIndex(g => g.id == id);
            if (index==-1) return NotFound();
            Games[index] = newGame;
            return Ok(newGame);
        }

        //DELETE /api/Game/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= Games.Count) return NotFound();
            Games.RemoveAt(id);
            return Ok();
        }
    }
}
