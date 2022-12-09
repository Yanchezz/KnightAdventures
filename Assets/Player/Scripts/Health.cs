using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject healthbar;
    [SerializeField] private GameObject deathImage;
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private AudioSource dieSound;
    private float currentHealth;
    public bool isAlive;
    private Image healthImage;
    private PlayerAnimator playerAnimator;
    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();    
        healthImage = healthbar.GetComponent<Image>();
        currentHealth = maxHealth;
        isAlive = true;
        deathImage.SetActive(false);
    }
    private void Update()
    {
        if (!isAlive && Input.GetButtonDown("Cancel")) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    }
    private void CheckIsAlive()
    {
        if (currentHealth <= 0) { Death();  }
    }
    public void TakeDamage(float damage) 
    {
        hurtSound.Play();
        currentHealth -= damage;
        healthImage.fillAmount -= damage * 0.01f;
        CheckIsAlive();
        playerAnimator.Hurt();
    }
    private void Death()
    {
        dieSound.Play();
        isAlive = false;
        deathImage.SetActive(true);
        playerAnimator.Death(isAlive);
        GetComponent<PlayerInput>().enabled = false;
    }
}