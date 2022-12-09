using UnityEngine;
public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float time;
    [SerializeField] private float QuatX;
    [SerializeField] private float QuatY;
    [SerializeField] private float QuatZ;
    private float currentTime;
    private bool donck;
    private Vector2 v2;
    private void Awake()
    {
        currentTime = time;
        v2 = new Vector2(transform.position.x, transform.position.y);
    }
    private void FixedUpdate()
    {
        Timer();
        if (donck) { Shot(); }
    }
    private void Shot()
    {
        Instantiate(arrow, v2, Quaternion.Euler(QuatX, QuatY, QuatZ));
    }
    private void Timer()
    {
        if (currentTime <= 0) { donck = true; currentTime = time; }
        else { donck = false;  currentTime -= Time.deltaTime; }
    }
}