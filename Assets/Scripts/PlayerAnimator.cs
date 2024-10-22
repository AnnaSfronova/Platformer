using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string AnimationRun = "isRun";
    private const string AnimationJump = "isJump";

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void Flip(bool value)
    {
        _spriteRenderer.flipX = value;
    }

    public void PlayRun(bool value)
    {
        _animator.SetBool(AnimationRun, value);
    }

    public void PlayJump(bool value)
    {
        _animator.SetBool(AnimationJump, value);
    }
}