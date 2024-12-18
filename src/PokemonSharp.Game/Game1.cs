using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PokemonSharp.Domain.Entities.Trainer;

namespace PokemonSharp.Game;

public class Game1 : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private readonly Trainer _trainer = new Trainer();
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _trainer.Position = new Vector2(100, 100);
        _trainer.Texture = Content.Load<Texture2D>("Sprites/Trainer/trainer");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(_trainer.Texture, _trainer.Position, Color.White);
        
        var sourceRectangle = new Rectangle(0, 0, 48, 64);
        
        _spriteBatch.Draw(_trainer.Texture, new Vector2(500, 100), sourceRectangle, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
