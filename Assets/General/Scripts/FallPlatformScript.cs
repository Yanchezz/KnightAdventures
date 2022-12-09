using UnityEngine;
public class FallPlatformScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float fallTime;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerInput>(out PlayerInput playerInput))
        {
            Invoke("Fall", fallTime);
        }
    }
    private void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 1);
    }
}