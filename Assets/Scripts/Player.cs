using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private void OnEnable()
    {
        _inputReader.Jumped += TryJump;
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= TryJump;
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
            _playerMover.Move(_inputReader.Direction);
    }

    private void TryJump()
    {
        if (_groundChecker.IsGround())
            _playerMover.Jump();
    }

    private void TryFlip()
    {
        if (_inputReader.Direction > 0.1f)
            _playerAnimator.Flip(false);
        else if (_inputReader.Direction < -0.1f)
            _playerAnimator.Flip(true);
    }

    private void TryPlayRun()
    {
        if (_inputReader.Direction != 0)
            _playerAnimator.PlayRun(true);
        else
            _playerAnimator.PlayRun(false);
    }

    private void TryPlayJump()
    {
        if (_groundChecker.IsGround() == false)
            _playerAnimator.PlayJump(true);
        else
            _playerAnimator.PlayJump(false);
    }
}
