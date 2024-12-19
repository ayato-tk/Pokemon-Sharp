using Microsoft.Xna.Framework;
using PokemonSharp.Core.Components.Entity;
using PokemonSharp.Core.Managers;

namespace PokemonSharp.Core.Systems.Entity;

public class MovementSystem(EntityManager entityManager, float speed) : ISystem
{

    private readonly EntityManager _entityManager = entityManager;

    private readonly float _speed = speed;

    public void Update(GameTime gameTime)
    {
        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        foreach (var (entityId, components) in entityManager.GetEntitiesWithComponents(typeof(PositionComponent)))
        {
            if (!components.TryGetValue(typeof(PositionComponent), out var positionObj)) continue;
            if (positionObj is not PositionComponent position) continue;
            position.Position += new Vector2(_speed * deltaTime, 0);
        }
    }
}