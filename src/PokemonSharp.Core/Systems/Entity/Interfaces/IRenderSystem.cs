using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokemonSharp.Core.Systems.Entity.Interfaces;

public interface IRenderSystem : ISystem
{
    void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}