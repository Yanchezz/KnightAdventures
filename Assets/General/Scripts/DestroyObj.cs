using UnityEngine;
public class DestroyObj : MonoBehaviour
{
    [SerializeField] private float delay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Object")) { Destroy(collision.gameObject, delay); }
    }
}