using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers;

[ApiController]
[Route("[controller]")]

public class GamesController : ControllerBase
{
	private static List<Game> games;

	public class Game{
		public int id { get; set; }
		public string? teamOneName { get; set; }
		public string? teamTwoName { get; set; }
		public int winner { get; set; } 
	} 
	
	List<Game> PopulateGames()
	{
		return new List<Game>(){
			new Game{
				id = 1,
				teamOneName = "Founders & Coders",
				teamTwoName = "Fee-Charging Bootcamp",
				winner = 1
			},
			new Game{
				id = 2,
				teamOneName = "Founders & Coders",
				teamTwoName = "Fee-Charging Bootcamp",
				winner = 1
			}
		};
	}

	private readonly ILogger<GamesController> _logger;

	public GamesController(ILogger<GamesController> logger) 
	{
		games = PopulateGames();
		_logger = logger;
	}

	[HttpGet]
	public IEnumerable<Game> Get()
	{
		return games;
	}
	
	[HttpDelete]
	public IEnumerable<Game> Delete(int id)
	{
		games.RemoveAll(game => game.id == id);
		return games;
	}
	
	[HttpPost]
	public IEnumerable<Game> AddGame(/* Game game */int id, string teamOneName, string teamTwoName, int winner)
	{
		games.Add(
			new Game{
				id = id,
				teamOneName = teamOneName,
				teamTwoName = teamTwoName,
				winner = winner
			}
		);
		return games;
	}
}
