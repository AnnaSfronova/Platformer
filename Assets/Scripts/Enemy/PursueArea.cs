using System;
using UnityEngine;

public class PursueArea : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    private bool _hasPlayer = false;

    public bool HasPlayer => _hasPlayer;
    public Transform PointA => _pointA;
    public Transform PointB => _pointB;

    public event Action<Player> IntruderIn;
    public event Action IntruderOut;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            IntruderIn?.Invoke(player);
            _hasPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            IntruderOut?.Invoke();
            _hasPlayer = false;
        }
    }
}
