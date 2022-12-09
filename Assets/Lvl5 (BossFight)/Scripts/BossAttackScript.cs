using UnityEngine;
public class BossAttackScript : MonoBehaviour
{
    [SerializeField] private Transform bossAttackPoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float delay;
    [SerializeField] private AudioSource laugh;
    [SerializeField] private AudioSource cast;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject WinWindow;
    private float currentTime;
    private EnemiesAnimator anim;
    private EnemiesHealth health;
    private Health playerHealth;
    private Vector2 direction;
    private bool isPlay = true;
    private void Awake()
    {
        currentTime = delay;
        direction = new Vector2(bossAttackPoint.position.x, bossAttackPoint.position.y);
        anim = GetComponent<EnemiesAnimator>(); 
        health = GetComponent<EnemiesHealth>();
        playerHealth = player.GetComponent<Health>();
    }
    private void FixedUpdate()
    {
        BossCombat();
        Finish();
    }
    private void BossCombat()
    {
            if (!health.isDeath && playerHealth.isAlive)
            {
                if (currentTime <= 0)
                {
                    anim.EnemyAttack();
                    cast.Play();
                    currentTime = delay;
                }
                else
                {
                    currentTime -= Time.deltaTime;
                }
            }
            if (!playerHealth.isAlive)
            {
                if (isPlay)
                {
                    laugh.Play();
                    isPlay = false;
                }
            }
    }
    private void Finish()
    {
        if (health.isDeath)
        {
            WinWindow.SetActive(true);
        }
    }
    public void BossAttack()
    {
        Instantiate(fireBall , direction , Quaternion.identity);
    }
}