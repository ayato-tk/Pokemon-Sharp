using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonSharp.Core;
using PokemonSharp.Core.Entities.Trainer;
using PokemonSharp.Engine.Game.Scenes;

namespace PokemonSharp.Engine;

public class Game1 : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private World _currentWorld;
    
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _currentWorld = new GameWorld(Content, GraphicsDevice);
        
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
        _spriteBatch.Begin();
        /*_spriteBatch.Draw(_trainer.Texture, _trainer.Position, Color.White);
        
        var sourceRectangle = new Rectangle(0, 0, 48, 64);
        
        _spriteBatch.Draw(_trainer.Texture, new Vector2(500, 100), sourceRectangle, Color.White);*/

        _currentWorld.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }


    private void ChangeWorld(World world)
    {
        _currentWorld = world;
    }
}
