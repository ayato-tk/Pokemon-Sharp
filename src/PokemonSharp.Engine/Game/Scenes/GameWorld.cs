using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using PokemonSharp.Core;
using PokemonSharp.Core.Components.Entity;
using PokemonSharp.Core.Systems.Entity;

namespace PokemonSharp.Engine.Game.Scenes;

public class GameWorld(
    ContentManager contentManager
) : World
{
    protected override void InitializeSystems()
    {
        Systems.Add(new RenderSystem(EntityManager, contentManager));
        Systems.Add(new MovementSystem(EntityManager, 100f));
    }

    protected override void InitializeEntities()
    {
        var playerEntity = EntityManager.CreateEntity();
        EntityManager.AddComponent(playerEntity, new PositionComponent(100, 200));
        EntityManager.AddComponent(playerEntity, new InputComponent());
        EntityManager.AddComponent(playerEntity,
            new SpriteComponent("Sprites/Trainer/trainer",
                new Rectangle(0, 0, 48, 64)));
    }
}