using UnityEngine;

public class PathPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _stopPoint;

    public Transform StopPoint => _stopPoint;

    public int Length => _points.Length;

    public Transform GetPointTranform(int index)
    {
        return _points[index];
    }
}
