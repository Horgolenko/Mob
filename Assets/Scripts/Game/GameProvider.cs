using System;
using Data;
using Level;
using Mob;
using States;
using UnityEngine;

namespace Game
{
    public class GameProvider : MonoBehaviour
    {
        private PlayerState _playerState;

        public int currentLevel => _playerState.currentLevel;
        public int coins => _playerState.coins;

        public static Action<int> UpdateCoins;
        
        private void Start()
        {
            StateMachine.OnStateChanged += OnStateChanged;
            MobBase.EnemyKilled += EnemyKilled;
        }

        private void OnDestroy()
        {
            StateMachine.OnStateChanged -= OnStateChanged;
            MobBase.EnemyKilled -= EnemyKilled;
        }

        private void OnStateChanged(AState state)
        {
            switch (state)
            {
                case WinState:
                    LevelPassed();
                    Save();
                    break;
                case LoseState:
                    Save();
                    break;
            }
        }

        private void LevelPassed()
        {
            if (_playerState.currentLevel < LevelLoader.MaxLevels)
            {
                _playerState.LevelPassed();
            }
        }

        private void EnemyKilled()
        {
            _playerState.AddReward();
            UpdateCoins(_playerState.coins);
        }
        
        public void Load()
        {
            _playerState = new PlayerState();
            _playerState.Load();
        }

        private void Save()
        {
            _playerState.Save();
        }
    }
}
