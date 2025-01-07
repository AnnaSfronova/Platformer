using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CollisionChecker))]
public class PlayerMover : MonoBehaviour
{
    private float _speed = 6f;
    private float _jumpForce = 18f;

    private Rigidbody2D _rigidbody;
    private InputReader _input;
    private CollisionChecker _checker;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputReader>();
        _checker = GetComponent<CollisionChecker>();
    }

    private void OnEnable()
    {
        _input.Jumped += Jump;
    }

    private void FixedUpdate()
    {
        if (_input.Direction != 0)
            Move(_input.Direction);
    }

    private void OnDisable()
    {
        _input.Jumped -= Jump;
    }

    public void Move(float directionX)
    {
        _rigidbody.velocity = new Vector2(directionX * _speed, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        if (_checker.IsGround())        
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);        
    }
}
