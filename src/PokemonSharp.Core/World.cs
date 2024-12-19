using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonSharp.Core.Managers;
using PokemonSharp.Core.Systems;
using PokemonSharp.Core.Systems.Entity.Interfaces;

namespace PokemonSharp.Core;

public abstract class World
{
    protected readonly EntityManager EntityManager;

    protected readonly List<ISystem> Systems;

    protected World()
    {
        EntityManager = new EntityManager();
        Systems = [];
        
        InitializeSystems();
        InitializeEntities();
    }

    protected abstract void InitializeSystems();
    
    protected abstract void InitializeEntities();
    
    
    public virtual void Update(GameTime gameTime)
    {
        foreach (var system in Systems)
        {
            system.Update(gameTime);
        }
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
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
