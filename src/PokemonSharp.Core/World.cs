using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonSharp.Core.Entities;
using PokemonSharp.Core.Systems;
using PokemonSharp.Core.Systems.Entity.Interfaces;

namespace PokemonSharp.Core;

public abstract class World
{


    protected readonly List<ISystem> Systems;

    protected World()
    {
        
        Systems = [];
        
        InitializeSystems();
        InitializeEntities();
    }

    protected abstract void InitializeSystems();
    
    protected abstract void InitializeEntities();
    
    
    public void Update(GameTime gameTime)
    {
        foreach (var system in Systems)
        {
            system.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (var system in Systems)
        {
            if (system is IRenderSystem renderSystem)
            {
                renderSystem.Draw(gameTime, spriteBatch);
            }
        }
    }

}
