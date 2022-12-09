using UnityEngine;
public class EnemiesScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToRevert;
    [SerializeField] private float attackDelay;
    [SerializeField] private float damage;
    [SerializeField] private AudioSource strikeSound;
    private float currentTime;
    private float currentTimeAttack;
    private float currentState;
    private EnemiesAnimator anim;
    private EnemiesHealth health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private GameObject target;
    private bool playerIn;
    private bool reversAngle;
    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;
    private const float COMBAT_STATE = 3;
    private void Awake()
    {
        anim = GetComponent<EnemiesAnimator>();
        health = GetComponent<EnemiesHealth>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentTime = timeToRevert;
        currentState = IDLE_STATE;
        currentTimeAttack = attackDelay;
    }
    private void FixedUpdate()
    {
        if (playerIn)
        {
            Combat();
        }
    }
    private void Update()
    {
        if (!health.isDeath)
        {
            if (currentTime <= 0)
            {
                currentTime = timeToRevert;
                currentState = REVERT_STATE;
            }
            switch (currentState)
            {
                case IDLE_STATE:
                    anim.EnemyIdle();
                    currentTime -= Time.deltaTime;
                    break;
                case WALK_STATE:
                    anim.EnemyWalk();
                    rb.velocity = Vector2.right * speed;
                    break;
                case REVERT_STATE:
                    //sr.flipX = !sr.flipX;
                    Reverse();
                    speed *= -1;
                    currentState = WALK_STATE;
                    break;
                case COMBAT_STATE:
                    anim.EnemyCombat();
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StopZone"))
        {
            currentState = IDLE_STATE;
        }
        if (collision.CompareTag("PlayerBody"))
        {
            currentState = COMBAT_STATE;
            target = collision.gameObject;
            playerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBody"))
        {
            currentState = IDLE_STATE;
            playerIn = false;
        }
    }
    private void Combat()
    {
      
        if (target.transform.position.x>transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (!health.isDeath && target.GetComponentInParent<Health>().isAlive)
        {
            if (currentTimeAttack <= 0)
            {
                anim.EnemyAttack();
                currentTimeAttack = attackDelay;
            }
            else
            {
                currentTimeAttack -= Time.deltaTime;
            }
        }
    }
    public void Attack()
    {
        strikeSound.Play();
        if (target.GetComponentInParent(typeof(Health)) != null)
        {
            target.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }
    private void Reverse()
    {
        if (reversAngle)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            reversAngle = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            reversAngle = true;
        }
    }
}