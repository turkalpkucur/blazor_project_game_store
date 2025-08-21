
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

    public GameSummary[] GetGames() => [.. games];
}
