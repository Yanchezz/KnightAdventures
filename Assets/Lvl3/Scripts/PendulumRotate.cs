using UnityEngine;
public class PendulumRotate : MonoBehaviour
{
    [SerializeField] private float speed;
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, speed);
    }
}