using Microsoft.Xna.Framework;

namespace PokemonSharp.Core.Systems;

public interface ISystem
{
    void Update(GameTime gameTime);
}