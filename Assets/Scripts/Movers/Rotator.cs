using UnityEngine;

namespace Movers
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private Vector3 _rot;

        private void Update() 
        {
            transform.Rotate(_rot * (Time.deltaTime * _speed));
        }
    }
}