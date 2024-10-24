using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(CollisionChecker))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private CollisionChecker _collisionChecker;

    private void OnEnable()
    {
        _inputReader.Jumped += TryJump;
        _collisionChecker.Gathered += GatherCoin;
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= TryJump;
        _collisionChecker.Gathered -= GatherCoin;
    }

    private void FixedUpdate()
    {
        TryMove();
        TryFlip();
        TryPlayRun();
        TryPlayJump();
    }

    private void TryMove()
    {
        if (_inputReader.Direction != 0)
            _mover.Move(_inputReader.Direction);
    }

    private void TryJump()
    {
        if (_collisionChecker.IsGround())
            _mover.Jump();
    }

    private void TryFlip()
    {
        if (_inputReader.Direction > 0.1f)
            _animator.Flip(false);
        else if (_inputReader.Direction < -0.1f)
            _animator.Flip(true);
    }

    private void TryPlayRun()
    {
        _animator.PlayRun(_inputReader.Direction != 0);
    }

    private void TryPlayJump()
    {
        _animator.PlayJump(_collisionChecker.IsGround() == false);
    }

    private void GatherCoin(Coin coin)
    {
        coin.ReturnToPool();        
    }
}
