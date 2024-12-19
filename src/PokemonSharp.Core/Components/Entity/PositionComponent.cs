using Microsoft.Xna.Framework;

namespace PokemonSharp.Core.Components.Entity;

public class PositionComponent
{
    public Vector2 Position { get; set; }

    public PositionComponent(float x, float y)
    {
        Position = new Vector2(x, y);
    }

    public PositionComponent(Vector2 position)
    {
        Position = position;
    }
}