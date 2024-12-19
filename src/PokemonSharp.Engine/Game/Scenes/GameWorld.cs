using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using PokemonSharp.Core;
using PokemonSharp.Core.Components.Entity;
using PokemonSharp.Core.Components.Player;
using PokemonSharp.Core.Entities.Trainer;
using PokemonSharp.Core.Entities.NPCs;
using PokemonSharp.Core.Systems.Entity;

namespace PokemonSharp.Engine.Game.Scenes;

public class GameWorld(ContentManager contentManager) : World
{

    private readonly Trainer _trainer = new();

    private readonly NPC _npc1 = new();



    protected override void InitializeSystems()
    {
        Systems.Add(new RenderSystem(_trainer, contentManager));
        Systems.Add(new MovementSystem(_trainer, 100f));


        Systems.Add(new RenderSystem(_npc1, contentManager));
    }

    protected override void InitializeEntities()
    {   
        var npcEntity = _npc1.CreateEntity();

        /*_npc1.AddComponent(npcEntity, new PositionComponent(200, 200));
        _npc1.AddComponent(npcEntity,
            new SpriteComponent("Sprites\\NPC\\NPC_0\\npc_0.png",
                new Rectangle(0, 0, 48, 64)));*/


        var playerEntity = 
            _trainer.CreateEntity();
        _trainer.AddComponent(playerEntity, new PositionComponent(100, 200));
        _trainer.AddComponent(playerEntity, new InputComponent());
        _trainer.AddComponent(playerEntity,
            new SpriteComponent("Sprites/Trainer/trainer",
                new Rectangle(0, 0, 48, 64)));
    }
}