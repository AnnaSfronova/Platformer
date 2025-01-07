using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _rightRotation = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion _leftRotation = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion _rotation;

    private float _currentPosition;
    private float _previousPosition;

    private void Start()
    {
        _currentPosition = transform.position.x;
        _previousPosition = _currentPosition;
    }

    private void Update()
    {
        TryFlip();
    }

    private void TryFlip()
    {
        _currentPosition = transform.position.x;

        if (_currentPosition < _previousPosition)
            Flip(true);
        else if (_currentPosition > _previousPosition)
            Flip(false);

        _previousPosition = _currentPosition;
    }

    public void Flip(bool value)
    {
        _rotation = value ? _leftRotation : _rightRotation;

        transform.rotation = _rotation;
    }
}
