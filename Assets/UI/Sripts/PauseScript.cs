using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseImage;
    [SerializeField] private GameObject player;
    private bool isActive = false;
    private void Awake()
    {
        pauseImage.SetActive(false);
        Time.timeScale = 1.0f;
    }
    void Update()
    {

        if (Input.GetButtonUp("Cancel") && !isActive)
        {
            pauseImage.SetActive(true);
            isActive = true;
            Time.timeScale = 0f;
            player.GetComponent<PlayerInput>().enabled = false;
        }
        else
        {
            if (Input.GetButtonUp("Cancel") && isActive)
            {
                Return();
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Return()
    {
        pauseImage.SetActive(false);
        isActive = false;
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerInput>().enabled = true;
    }
}