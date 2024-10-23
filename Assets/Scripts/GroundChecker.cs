using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;

    private float _radius = 0.2f;

    public bool IsGround() =>
        Physics2D.OverlapCircle(transform.position, _radius, _groundMask);
}
