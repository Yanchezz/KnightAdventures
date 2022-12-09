using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLvlScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            NextLvl();
        }
    }
    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}