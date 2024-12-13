using PokemonSharp.Core;
using PokemonSharp.UI.Implementations;

namespace PokemonSharp.UI;

public class Program
{
    public static void Main(string[] args)
    {
        Engine game = new Game("Pokemon Sharp", 800, 600);
        game.Run();
    }
    
}