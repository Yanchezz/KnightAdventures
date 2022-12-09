using UnityEngine;
public class BallScript : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Vector2 point;
    [SerializeField] private float time;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            Invoke("InstBall", time);
        }
    }
    private void InstBall()
    {
        Instantiate(ball, point, Quaternion.identity);
    }
}