using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using PokemonSharp.Core.Components.Entity;
using PokemonSharp.Core.Components.Player;

namespace PokemonSharp.Core.Systems.Entity;

//TODO: Adaptar Sistema para permitir outras entidades além do player andarem
public class MovementSystem(Entities.Entity entityManager, float speed, OrthographicCamera camera) : ISystem
{
    private readonly Entities.Entity _entityManager = entityManager;
    
    private readonly OrthographicCamera _camera = camera;
    
    private Vector2 _cameraPosition;
    

    private readonly Dictionary<Keys, Vector2> _keyDirectionMap = new()
    {
        { Keys.A, new Vector2(-1, 0) },
        { Keys.D, new Vector2(1, 0) },
        { Keys.W, new Vector2(0, -1) },
        { Keys.S, new Vector2(0, 1) }
    };
    
    public void Update(GameTime gameTime)
    {
        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        foreach (var (entityId, components) in entityManager.GetEntitiesWithComponents(typeof(PositionComponent),
                     typeof(InputComponent)))
        {
            if (!components.TryGetValue(typeof(PositionComponent), out var positionObj) ||
                !components.TryGetValue(typeof(InputComponent), out var inputObj)) continue;
            if (positionObj is not PositionComponent position || inputObj is not InputComponent input) continue;

            input.Update();

            var direction = _keyDirectionMap.Where(keyDirectionPair => input.IsKeyDown(keyDirectionPair.Key))
                .Aggregate(Vector2.Zero, (current, keyDirectionPair) => current + keyDirectionPair.Value);

            _camera.Move(direction * speed * deltaTime);
            
            position.Position += direction * speed * deltaTime;
        }
    }
    
    
}