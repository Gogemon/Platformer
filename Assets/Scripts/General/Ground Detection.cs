using UnityEngine;

public class GroundDetection: MonoBehaviour
{
    private const string GroundTag = "Ground";

    private bool _isGround;

    public bool IsGround { get { return _isGround; }}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            _isGround = false;
        }
    }
}
