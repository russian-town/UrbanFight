using Code.Infrastructure.Installers;
using Code.Infrastructure.States.Abstract;
using Code.Infrastructure.Systems;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class BattleLoopState : IState
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _gameContext;
        
        private BattleFeature _battleFeature;

        public BattleLoopState(ISystemFactory systems, GameContext gameContext)
        {
            _systems = systems;
            _gameContext = gameContext;
        }
        
        public void Enter()
        {
            Debug.Log("Enter to battle loop state.");
            
            _battleFeature = _systems.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        public void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        public void Exit()
        {
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();

            DestructEntities();
            
            _battleFeature.Cleanup();
            _battleFeature.TearDown();
            _battleFeature = null;
        }

        private void DestructEntities()
        {
            foreach (var entity in _gameContext.GetEntities())
                entity.isDestructed = true;
        }
    }
}
