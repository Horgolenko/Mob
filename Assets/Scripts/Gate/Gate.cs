using System.Collections;
using Game;
using Mob;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gate
{
    public class Gate : MonoBehaviour
    {
        private const float Delay = 5;

        [SerializeField]
        private int _id;
        [SerializeField] 
        private GateType _gateType;
        [SerializeField]
        private int _value;
        [SerializeField]
        private GameObject _plane;
        [SerializeField]
        private Image _image;
        [SerializeField]
        private ParticleSystem _particleSystem;
        
        private MobPool _mobPool;
        private Coroutine _active;
        private readonly WaitForSeconds _waitFor = new(Delay);
        private BoxCollider _collider;
        
        public int value => _value;
        public GateType gateType => _gateType;
        
        [Inject]
        private void Construct(MobPool mobPool)
        {
            _mobPool = mobPool;
        }

        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
        }

        private void OnDestroy()
        {
            if (_active != null)
            {
                StopCoroutine(_active);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_gateType == GateType.Kill)
            {
                if (!_collider.enabled) return;
                
                var mobBase = other.GetComponent<MobBase>();
                if (mobBase == null || mobBase.mobData.sideType == SideType.Enemy) return;
                
                TurnOff();
                mobBase.Damage();
                _active = StartCoroutine(TurnOnCoroutine());
            }
            else
            {
                var mobBase = other.GetComponent<MobBase>();
                if (mobBase == null || mobBase.mobData.sideType == SideType.Enemy || mobBase.mobData.IsVisited(_id)) return;
                
                mobBase.mobData.Init(_id);
                _particleSystem.Play();
                var result = _gateType == GateType.Multiply ? _value - 1 : _value;
                for (int i = 0; i < result; i++)
                {
                    var mob = _mobPool.Get(mobBase.mobData.mobType);
                    mob.Copy(mobBase, _id);
                    mob.Run();
                }
            }
        }

        private void TurnOn()
        {
            _plane.SetActive(true);
            _image.enabled = true;
            _collider.enabled = true;
        }
        
        private void TurnOff()
        {
            _collider.enabled = false;
            _plane.SetActive(false);
            _image.enabled = false;
        }

        private IEnumerator TurnOnCoroutine()
        {
            yield return _waitFor;

            TurnOn();
        }
    }
}
