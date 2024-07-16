using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gate
{
    public class GateView : MonoBehaviour
    {
        [SerializeField]
        private Material _defaultMaterial;
        [SerializeField]
        private Material _killMaterial;
        [SerializeField]
        private MeshRenderer _meshRenderer;
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField] 
        private Image _image;
        
        private Gate _gate;

        private void Awake()
        {
            _gate = GetComponent<Gate>();
        }

        private void Start()
        {
            if (_gate.gateType == GateType.Kill)
            {
                _meshRenderer.material = _killMaterial;
                _text.enabled = false;
                _image.enabled = true;
            }
            else
            {
                _meshRenderer.material = _defaultMaterial;
                if (_gate.gateType == GateType.Add)
                {
                    _text.text = $"+{_gate.value}";
                }
                else if (_gate.gateType == GateType.Multiply)
                {
                    _text.text = $"x{_gate.value}";
                }
                _text.enabled = true;
                _image.enabled = false;
            }
        }
    }
}
