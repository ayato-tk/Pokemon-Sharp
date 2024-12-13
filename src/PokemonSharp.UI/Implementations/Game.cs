
using OpenTK.Graphics.OpenGL4;
using PokemonSharp.Core;

namespace PokemonSharp.UI.Implementations;

internal class Game(string windowTitle, int initialWindowWidth, int initialWindowHeight) : Engine(windowTitle, initialWindowWidth, initialWindowHeight)
{
    protected override void Initialize()
    {
    
    }

    protected override void LoadContent()
    {

    }

    protected override void Update(Time time)
    {

    }

    protected override void Render(Time time)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(1, 0, 0, 0);
    }
}