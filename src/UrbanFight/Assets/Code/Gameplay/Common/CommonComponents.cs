using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class EntityLink : IComponent { [EntityIndex] public int Value; }
  
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class Destructed : IComponent { }
}
