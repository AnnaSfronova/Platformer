using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const KeyCode JumpKey = KeyCode.Space;
    private const int MouseButton = 0;

    private bool _isJump = false;
    private bool _isAttack = false;

    public event Action Jumped;
    public event Action Attacked;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if(Input.GetKeyDown(JumpKey))
            _isJump = true;

        if (Input.GetMouseButton(MouseButton))
            _isAttack = true;
    }

    private void FixedUpdate()
    {
        if(_isJump)
        {
            Jumped?.Invoke();
            _isJump = false;
        }

        if(_isAttack)
        {
            Debug.Log("ATTACK");
            Attacked?.Invoke();
            _isAttack = false;
        }
    }
}
