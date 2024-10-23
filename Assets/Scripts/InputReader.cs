using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const KeyCode _jumpKey = KeyCode.Space;

    public event Action Jumped;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if(Input.GetKeyDown(_jumpKey))
            Jumped?.Invoke();
    }
}
