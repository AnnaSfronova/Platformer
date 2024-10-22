using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private int _currentPoint;

    public Transform Target { get; private set; }

    private void Awake()
    {
        Target = _points[_currentPoint];
    }

    public void ChangePoint()
    {
        _currentPoint = (_currentPoint + 1) % _points.Length;
        Target = _points[_currentPoint];
    }
}
