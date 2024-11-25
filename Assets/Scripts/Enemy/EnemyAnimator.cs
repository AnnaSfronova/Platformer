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

    public string AnimationRun => "isRun";
}
