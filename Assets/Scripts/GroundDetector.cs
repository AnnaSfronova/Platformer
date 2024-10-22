using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            IsGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            IsGround = false;
    }
}