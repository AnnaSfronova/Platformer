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

    public string Run => nameof(Run);
    public string Attack => nameof(Attack);
    public string Hit => nameof(Hit);
}
