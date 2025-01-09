using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Coroutine _coroutine;
    private Color _defaultColor = Color.white;
    private Color _hitColor = Color.red;
    private float _delay = 0.05f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void PlayAnimation(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public void PlayHit()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        _sprite.color = _hitColor;

        yield return new WaitForSeconds(_delay);

        _sprite.color = _defaultColor;
    }

    public string Run => nameof(Run);
    public string Attack => nameof(Attack);
    public string Hit => nameof(Hit);
}
