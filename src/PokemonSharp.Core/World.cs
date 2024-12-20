using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using PokemonSharp.Core.Entities;
using PokemonSharp.Core.Systems;
using PokemonSharp.Core.Systems.Entity.Interfaces;

namespace PokemonSharp.Core;

public abstract class World
{
    protected readonly List<ISystem> Systems;

    protected TiledMap _tiledMap;

    private TiledMapRenderer _tiledMapRenderer;
    
    private readonly ContentManager _contentManager;

    private readonly GraphicsDevice _graphicsDevice;
    
    private readonly string _mapPath;

    protected World(ContentManager contentManager, GraphicsDevice graphicsDevice, string mapPath)
    {
        Systems = [];

        _contentManager = contentManager;
        _graphicsDevice = graphicsDevice;
        _mapPath = mapPath;

        InitializeSystems();
        InitializeEntities();
    }

    protected abstract void InitializeSystems();

    protected abstract void InitializeEntities();

    public void LoadMap()
    {
        _tiledMap = _contentManager.Load<TiledMap>(_mapPath);
        _tiledMapRenderer = new TiledMapRenderer(_graphicsDevice, _tiledMap);
    }


    public void Update(GameTime gameTime)
    {
        _tiledMapRenderer.Update(gameTime);
        foreach (var system in Systems)
        {
            system.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _tiledMapRenderer.Draw();
        foreach (var system in Systems)
        {
            if (system is IRenderSystem renderSystem)
            {
                renderSystem.Draw(gameTime, spriteBatch);
            }
        }
    }
}