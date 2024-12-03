using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public void PlayTriggerAnimation(string name)
    {
        _animator.SetTrigger(name);
    }

    public string AnimationRun => "isRun";
    public string AnimationAttack => "isAttack";
    public string AnimationHit => "isHit";

}
