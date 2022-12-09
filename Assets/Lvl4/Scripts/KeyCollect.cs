using UnityEngine;
public class KeyCollect : MonoBehaviour
{
    [SerializeField] private GameObject doorClosed;
    [SerializeField] private GameObject doorOpen;
    [SerializeField] private AudioSource collectSound;
    private void Awake()
    {
        doorClosed.SetActive(true);
        doorOpen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            collectSound.Play();
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
            Destroy(gameObject);
        }
    }
}