using Microsoft.Xna.Framework.Input;

namespace PokemonSharp.Core.Components.Entity;

public class InputComponent
{
    private KeyboardState CurrentKeyboardState { get; set; } = Keyboard.GetState();
    private KeyboardState PreviousKeyboardState { get; set; } = Keyboard.GetState();

    public void Update()
    {
        PreviousKeyboardState = CurrentKeyboardState;
        CurrentKeyboardState = Keyboard.GetState();
    }
    
    public bool IsKeyDown(Keys key)
    {
        return CurrentKeyboardState.IsKeyDown(key);
    }
    
    public bool IsKeyPressed(Keys key)
    {
        return CurrentKeyboardState.IsKeyDown(key) && PreviousKeyboardState.IsKeyUp(key);
    }
    
    public bool IsKeyReleased(Keys key)
    {
        return CurrentKeyboardState.IsKeyUp(key) && PreviousKeyboardState.IsKeyDown(key);
    }
    
}