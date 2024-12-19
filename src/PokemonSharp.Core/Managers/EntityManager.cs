using System;
using System.Collections.Generic;

namespace PokemonSharp.Core.Managers;

public class EntityManager
{
    private int _nextEntityId = 0;
    private readonly Dictionary<int, Dictionary<Type, object>> _entityComponents = new();

    public int CreateEntity()
    {
        var entityId = _nextEntityId++;
        _entityComponents[entityId] = new Dictionary<Type, object>();
        return entityId;
    }

    public void RemoveEntity(int entityId)
    {
        _entityComponents.Remove(entityId);
    }

    public void AddComponent<T>(int entityId, T component) where T : class
    {
        if (!_entityComponents.TryGetValue(entityId, out var components))
            throw new ArgumentException($"Entity {entityId} does not exist.");

        components[typeof(T)] = component;
    }
    
    public T GetComponent<T>(int entityId) where T : class
    {
        if (!_entityComponents.TryGetValue(entityId, out var components))
            throw new ArgumentException($"Entity {entityId} does not exist.");

        if (components.TryGetValue(typeof(T), out var component))
        {
            return component as T;
        }

        throw new ArgumentException($"Component {typeof(T)} not found for entity {entityId}.");
    }

    public void RemoveComponent<T>(int entityId) where T : class
    {
        if (!_entityComponents.TryGetValue(entityId, out var components))
            throw new ArgumentException($"Entity {entityId} does not exist.");

        components.Remove(typeof(T));
    }

    public bool HasComponent<T>(int entityId, T component) where T : class
    {
        return _entityComponents.ContainsKey(entityId) &&
               _entityComponents[entityId].ContainsKey(typeof(T));
    }

    public IEnumerable<(int EntityId, Dictionary<Type, object> Components)> GetEntitiesWithComponents(params Type[] componentTypes)
    {
        foreach (var (entityId, components) in _entityComponents)
        {
            var matchedComponents = new Dictionary<Type, object>();

            foreach (var componentType in componentTypes)
            {
                if (components.TryGetValue(componentType, out var component))
                {
                    matchedComponents[componentType] = component;
                }
            }
            
            if (matchedComponents.Count == componentTypes.Length)
            {
                yield return (entityId, matchedComponents);
            }
        }
    }


}