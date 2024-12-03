using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(CollisionChecker))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private CollisionChecker _collisionChecker;
    [SerializeField] private Health _health;

    private int _damage = 10;

    private void OnEnable()
    {
        _inputReader.Jumped += TryJump;
        _inputReader.Attacked += TryAttack;
        _collisionChecker.GatheredCoin += GatherCoin;
        _collisionChecker.GatheredKit += GatherKit;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= TryJump;
        _inputReader.Attacked -= TryAttack;
        _collisionChecker.GatheredCoin -= GatherCoin;
        _collisionChecker.GatheredKit -= GatherKit;
        _health.Died -= Die;
    }

    private void FixedUpdate()
    {
        TryMove();
        TryPlayAnimation();
    }

    public void TakeDamage(int damage)
    {
        _animator.PlayHit();
        _health.TakeDamage(damage);
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

    private void TryAttack()
    {
        _animator.PlayAttack();

        if (_collisionChecker.Enemy != null && _collisionChecker.IsGround())
        {
            Enemy enemy = _collisionChecker.Enemy;
            enemy.TakeDamage(_damage);            
        }
    }

    private void GatherCoin(Coin coin)
    {
        coin.Gather();
    }

    private void GatherKit(MedicineKit kit)
    {
        _health.TakeHeal(kit.Heal);
        kit.Die();
    }

    private void TryPlayAnimation()
    {
        _animator.PlayRun(_inputReader.Direction != 0);
        _animator.PlayJump(_collisionChecker.IsGround() == false);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
