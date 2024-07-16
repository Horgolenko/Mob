using Game;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CoinsUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        
        [Inject]
        private void Construct(GameProvider gameProvider)
        {
            _text.text = $"{gameProvider.coins}";
        }

        private void Start()
        {
            GameProvider.UpdateCoins += UpdateCoins;
        }

        private void OnDestroy()
        {
            GameProvider.UpdateCoins -= UpdateCoins;
        }

        private void UpdateCoins(int value)
        {
            _text.text = $"{value}";
        }
    }
}
