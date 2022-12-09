using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuWindow;
    private GameObject currentWindow;
    private void Awake()
    {
        currentWindow = MenuWindow;
        currentWindow.SetActive(true);
        Time.timeScale = 1;
    }
    public void ChangeWindow(GameObject nextWindow)
    {
        if (currentWindow != null)
        {
            currentWindow.SetActive(false);
            nextWindow.SetActive(true);
            currentWindow = nextWindow;
        }
    }
    public void Exit()
    {
        Application.Quit(); 
    }
    public void ChooseLvl(int bildIndex)
    {
        SceneManager.LoadScene(bildIndex);
    }
}