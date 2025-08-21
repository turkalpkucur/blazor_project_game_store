
using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
    [
    new (){
Id=1,Name="Street Fighter 2",
Genre="Fighting",
Price=1.99M,
ReleaseDate=new DateOnly(1992,7,15)
},
new (){
Id=1,Name="Final Fantasy XIV",
Genre="Roleplaying",
Price=59.99M,
ReleaseDate=new DateOnly(2010,9,30)
},

new (){
Id=1,Name="FIFA 2023",
Genre="Sports",
Price=69.99M,
ReleaseDate=new DateOnly(2022,9,27)
},
];

    private readonly Genre[] genres = new GenresClient().GetGenres();


    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));
        var GameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        games.Add(GameSummary);
    }
}
