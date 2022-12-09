using UnityEngine;
public class SecretDoorSript : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            gameObject.SetActive(false);
        }
    }
}