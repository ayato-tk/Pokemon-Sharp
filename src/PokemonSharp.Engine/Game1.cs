using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using PokemonSharp.Core;
using PokemonSharp.Core.Entities.Trainer;
using PokemonSharp.Engine.Game.Scenes;

namespace PokemonSharp.Engine;

public class Game1 : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private World _currentWorld;
    private OrthographicCamera _camera;
    
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
        var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 600);
        _camera = new OrthographicCamera(viewportAdapter);
        _currentWorld = new GameWorld(Content, GraphicsDevice, _camera);
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _currentWorld.LoadMap();
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        /*_trainer.Position = new Vector2(100, 100);
        _trainer.Texture = Content.Load<Texture2D>("Sprites/Trainer/trainer");*/
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        _currentWorld.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());
        
        _currentWorld.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }


    private void ChangeWorld(World world)
    {
        _currentWorld = world;
    }
}
