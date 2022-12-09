using UnityEngine;
public class FireBallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;
    private Vector3 vec;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider2D col = Physics2D.OverlapCircle(transform.position, 100, layer);
        target = col.transform;
        vec = target.transform.position - transform.position;
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
           rb.MovePosition(transform.position + vec.normalized * Time.deltaTime * speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (rb != null)
        {
            if (collider.gameObject.TryGetComponent<PlayerInput>(out PlayerInput player))
            {
                Destroy(gameObject);
            }
        }
    }
}