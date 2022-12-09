using UnityEngine;
using UnityEngine.UI;
public class EndLvlScript : MonoBehaviour
{
    [SerializeField] private GameObject winWindow;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text endScore;
    private void Awake()
    {
        winWindow.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            collision.gameObject.GetComponentInParent<PlayerInput>().enabled = false;
            winWindow.SetActive(true);
            endScore.text = currentScore.text;
        }
    }
}