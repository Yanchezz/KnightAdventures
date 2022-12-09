using UnityEngine;
public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponentInParent(typeof(Health)) != null)
        {
                collision.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
        if (collision.gameObject.GetComponent(typeof(EnemiesHealth)) != null)
        {
            collision.gameObject.GetComponent<EnemiesHealth>().EnemieTakeDamage(damage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision1)
    {
        if (collision1.gameObject.GetComponentInParent(typeof(Health)) != null)
        {
                collision1.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
        if (collision1.gameObject.GetComponent(typeof(EnemiesHealth)) != null)
        {
            collision1.gameObject.GetComponent<EnemiesHealth>().EnemieTakeDamage(damage);
        }
    }
}