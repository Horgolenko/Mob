using System;
using Game;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class MobTypeUI : MonoBehaviour
    {
        [SerializeField]
        private Button _redButton;
        [SerializeField]
        private Button _greenButton;
        [SerializeField]
        private Button _blueButton;

        public static Action<MobType> OnMobTypeChanged;
        
        private void Awake()
        {
            _redButton.onClick.AddListener(OnRedClicked());
            _greenButton.onClick.AddListener(OnGreenClicked());
            _blueButton.onClick.AddListener(OnBlueClicked());
        }
        
        private UnityAction OnRedClicked()
        {
            void RedClicked()
            {
                OnMobTypeChanged(MobType.Red);
            }
            
            return RedClicked;
        }
        
        private UnityAction OnGreenClicked()
        {
            void GreenClicked()
            {
                OnMobTypeChanged(MobType.Green);
            }
            
            return GreenClicked;
        }
        
        private UnityAction OnBlueClicked()
        {
            void BlueClicked()
            {
                OnMobTypeChanged(MobType.Blue);
            }
            
            return BlueClicked;
        }
    }
}
