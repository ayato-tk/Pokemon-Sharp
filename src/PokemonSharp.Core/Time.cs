namespace PokemonSharp.Core;

public struct Time(TimeSpan timeSpan, TimeSpan elapsedGameTime)
{
    
    public TimeSpan GameTime { get; set; } = timeSpan;

    public TimeSpan ElapsedGameTime { get; set; } = elapsedGameTime;

    public Time() : this(TimeSpan.Zero, TimeSpan.Zero)
    {
    }
}