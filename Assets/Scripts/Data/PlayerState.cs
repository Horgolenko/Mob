using Level;
using UnityEngine;

namespace Data
{
    public class PlayerState
    {
        private const string CurrentLevel = "CurrentLevel";
        private const string Coins = "Coins";
        
        private int _currentLevel;
        private int _coins;
        
        public int currentLevel => _currentLevel;
        public int coins => _coins;
        
        public void Load()
        {
            _currentLevel = LoadValue(CurrentLevel);
            _coins = LoadValue(Coins);
        }

        public void Save()
        {
            SaveValue(CurrentLevel, _currentLevel);
            SaveValue(Coins, _coins);
        }
        
        private int LoadValue(string valueId)
        {
            return PlayerPrefs.GetInt(valueId);
        }

        private void SaveValue(string valueId, int value)
        {
            PlayerPrefs.SetInt(valueId, value);
        }

        public void AddReward()
        {
            _coins++;
        }

        public void LevelPassed()
        {
            _currentLevel++;
        }
    }
}
