using UnityEngine;
using System.Linq;
public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimator playerAnimator;
    [SerializeField] private AudioSource attackSound;
    public Transform attackPoint;
    public float attackRange;
    public float damage;
    public LayerMask enemyLayer;
    public bool isAttack;
    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();    
    }
    public void Attack()
    {
        isAttack = true;
        playerAnimator.Attack1(); //запуск анимации атаки
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer); //получаем массив коллайдеров всех врагов которые попали в радиус атаки
        if (hitEnemies != null)
        {
            GameObject[] hitEnemiesObj = new GameObject[hitEnemies.Length]; 
            for (int i = 0; i < hitEnemies.Length; i++)
            {
                hitEnemiesObj[i] = hitEnemies[i].gameObject; // создаем массив обьектов и закидываем туда все обьекты чьи коллайдеры попали в зону атаки
            }
            GameObject[] hitEnemiesUniq = hitEnemiesObj.Distinct().ToArray(); //удаляем повторения из массива так нам нужны враги попавшие в зону атаки (а на некоторых врагах несколько колайдеров)
            foreach (GameObject enemy in hitEnemiesUniq)
            {
                enemy.gameObject.GetComponent<EnemiesHealth>().EnemieTakeDamage(damage); //наносим урон по каждому врагу в массиве
            }
        }
    }
    public void AttackEnd()
    {
        isAttack = false;
    }
    public void AttackSound()
    {
        attackSound.Play();
    }
}