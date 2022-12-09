using UnityEngine;
public class TrampolinePlatformScript : MonoBehaviour
{
    [SerializeField] private float power;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
        }
    }
}