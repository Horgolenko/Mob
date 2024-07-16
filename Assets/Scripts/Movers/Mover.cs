using DG.Tweening;
using UnityEngine;

namespace Movers
{
    public class Mover : MonoBehaviour
    {
        private const float Duration = 2.5f;
        
        [SerializeField]
        private Vector3 _endPosition;

        private Tweener _tweener;

        private void Start()
        {
            if (_endPosition == Vector3.zero) return;
            
            _tweener = transform.DOLocalMove(_endPosition, Duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }

        private void OnDestroy()
        {
            _tweener?.Kill();
        }
    }
}
