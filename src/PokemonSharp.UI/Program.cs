using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

class Program
{
    static void Main()
    {

        var gws = GameWindowSettings.Default;
        var nws = NativeWindowSettings.Default;
        
        nws.ClientSize = new Vector2i(1280, 720);
        nws.Title = "Pokemon Sharp";

        gws.UpdateFrequency = 60;

        var window = new GameWindow(gws, nws);

        var i = 0;
        var playerX = 0;

        window.UpdateFrame += (FrameEventArgs args) =>
        {
            playerX += 1;
            Console.WriteLine(playerX);
        };
        
        window.Run();
    }

    private static Shader LoadShader(string shaderLocation, ShaderType type)
    {
        var shaderId = GL.CreateShader(type);
        GL.ShaderSource(shaderId, File.ReadAllText(shaderLocation));
        GL.CompileShader(shaderId);
        var infoLog = GL.GetShaderInfoLog(shaderId);

        if (!string.IsNullOrEmpty(infoLog))
        {
            throw new Exception(infoLog);
        }
        
        return new Shader() { Id=shaderId };
    }
    
    //private static ShaderPr
    
    public struct Shader
    {
        public int Id;
    }
}