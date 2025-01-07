using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CollisionChecker))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Run = nameof(Run);
    private const string Jump = nameof(Jump);
    private const string Attack = nameof(Attack);
    private const string Hit = nameof(Hit);

    private Animator _animator;
    private InputReader _input;
    private CollisionChecker _checker;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<InputReader>();
        _checker = GetComponent<CollisionChecker>();
    }

    private void OnEnable()
    {
        _input.Attacked += PlayAttack;
    }

    private void Update()
    {
        _animator.SetBool(Run, _input.Direction != 0);
        _animator.SetBool(Jump, _checker.IsGround() == false);
    }

    private void OnDisable()
    {
        _input.Attacked -= PlayAttack;
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void PlayHit()
    {
        _animator.SetTrigger(Hit);
    }
}