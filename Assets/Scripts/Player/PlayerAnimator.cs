using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string AnimationRun = "isRun";
    private const string AnimationJump = "isJump";
    private const string AnimationAttack = "isAttack";
    private const string AnimationHit = "isHit";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRun(bool value)
    {
        _animator.SetBool(AnimationRun, value);
    }

    public void PlayJump(bool value)
    {
        _animator.SetBool(AnimationJump, value);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(AnimationAttack);
    }

    public void PlayHit()
    {
        _animator.SetTrigger(AnimationHit);
    }
}