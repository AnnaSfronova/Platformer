using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string AnimationRun = "isRun";
    private const string AnimationJump = "isJump";

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
}