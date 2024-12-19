using Microsoft.Xna.Framework;

namespace PokemonSharp.Core.Components.Entity;

public class SpriteComponent(string texturePath, Rectangle? sourceRectangle = null)
{
    public string TexturePath { get; set; } = texturePath;
    public Rectangle? SourceRectangle { get; set; } = sourceRectangle;
}