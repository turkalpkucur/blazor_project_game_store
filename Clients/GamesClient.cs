
using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
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
Id=2,Name="Final Fantasy XIV",
Genre="Roleplaying",
Price=59.99M,
ReleaseDate=new DateOnly(2010,9,30)
},

new (){
Id=3,Name="FIFA 2023",
Genre="Sports",
Price=69.99M,
ReleaseDate=new DateOnly(2022,9,27)
},
];
    private readonly Genre[] genres = new GenresClient(httpClient).GetGenres();
    public async Task<GameSummary[]> GetGamesAsync() => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);
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

    public async Task<GameDetails> GetGameAsync(int id) => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Could not find game!");

    public async Task UpdateGameAsync(GameDetails updatedGame) => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);

    public async Task DeleteGameAsync(int id) => await httpClient.DeleteAsync($"games/{id}");
    private GameSummary GetGameSummaryById(int id)
    {
        var game = games.Find(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var genre = genres.Single(genre => genre.Id == int.Parse(id));
        return genre;
    }

}
