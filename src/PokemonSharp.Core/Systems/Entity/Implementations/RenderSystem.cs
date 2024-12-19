using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonSharp.Core.Components.Entity;
using PokemonSharp.Core.Systems.Entity.Interfaces;

namespace PokemonSharp.Core.Systems.Entity;

public class RenderSystem(Entities.Entity entity, ContentManager contentManager) : IRenderSystem
{
    public void Update(GameTime gameTime)
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (var (entityId, components) in entity.GetEntitiesWithComponents(typeof(PositionComponent),
                     typeof(SpriteComponent)))
        {
            if (!components.TryGetValue(typeof(PositionComponent), out var positionObj) ||
                !components.TryGetValue(typeof(SpriteComponent), out var spriteObj)) continue;
            if (positionObj is not PositionComponent position || spriteObj is not SpriteComponent sprite) continue;

            if (sprite.SourceRectangle.HasValue)
            {
                spriteBatch.Draw(contentManager.Load<Texture2D>(sprite.TexturePath), position.Position,
                    sprite.SourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(contentManager.Load<Texture2D>(sprite.TexturePath), position.Position,
                    Color.White);
            }
        }
    }
}