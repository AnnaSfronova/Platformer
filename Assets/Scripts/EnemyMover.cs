using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    

    private Rigidbody2D _rigidbody;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.fixedDeltaTime);        
    }
}
