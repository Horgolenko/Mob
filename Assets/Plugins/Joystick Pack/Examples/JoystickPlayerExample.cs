using DG.Tweening;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    private const float MaxX = 3.1f;
    
    public float speed;
    public VariableJoystick variableJoystick;

    private Vector3 _minPosition, _maxPosition;
    private Tweener _tweener;

    private void Start()
    {
        var position = transform.position;
        var y = position.y;
        var z = position.z;
        _minPosition = new Vector3(-MaxX, y, z);
        _maxPosition = new Vector3(MaxX, y, z);
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical +
                            Vector3.right * variableJoystick.Horizontal;
        var position = transform.position;
        var newPosition = position + direction;
        if (Mathf.Abs(newPosition.x) > MaxX)
        {
            transform.position = GetPosition(newPosition.x);
        }
        else
        {
            _tweener?.Kill();
            _tweener = transform.DOMove(newPosition, speed * Time.fixedDeltaTime);
        }
    }

    private Vector3 GetPosition(float x)
    {
        return x > 0 ? _maxPosition : _minPosition;
    }
}