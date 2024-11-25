using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _rightRotation = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion _leftRotation = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion _rotation;

    public void Flip(bool value)
    {
        _rotation = value ? _leftRotation : _rightRotation;

        transform.rotation = _rotation;
    }
}
