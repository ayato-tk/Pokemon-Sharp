using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace PokemonSharp.Core;

public abstract class Engine(string windowTitle, int initialWindowWidth, int initialWindowHeight)
{
    private string WindowTitle { get; set; } = windowTitle;

    private int InitialWindowWidth { get; set; } = initialWindowWidth;

    private int InitialWindowHeight { get; set; } = initialWindowHeight;
    
    private readonly GameWindowSettings _gameWindowSettings = GameWindowSettings.Default;
    private readonly NativeWindowSettings _nativeWindowSettings = NativeWindowSettings.Default;

    public void Run()
    {
        Initialize();
        using var gameWindow = new GameWindow(_gameWindowSettings, _nativeWindowSettings);
 
        var time = new Time();
        
        gameWindow.Title = WindowTitle;
        gameWindow.Load += LoadContent;
        gameWindow.UpdateFrame += (FrameEventArgs e) =>
        {
            var currentTime = e.Time;
            time.ElapsedGameTime = TimeSpan.FromMicroseconds(currentTime);
            time.GameTime = TimeSpan.FromMicroseconds(currentTime);
            Update(time);
        };
        gameWindow.RenderFrame += (FrameEventArgs e) =>
        {
            Render(time);
            gameWindow.SwapBuffers();
        };
        gameWindow.Run();
    }
    
    protected abstract void Initialize();
    
    protected abstract void LoadContent();
    
    protected abstract void Update(Time time);

    protected abstract void Render(Time time);
}