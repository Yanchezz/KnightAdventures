using UnityEngine;
public class ArrowScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private bool direction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (rb != null)
        {
            if (direction) { rb.AddForce(Vector2.left * speed); }
            if (!direction) { rb.AddForce(Vector2.down * speed); }
        }
    }
}