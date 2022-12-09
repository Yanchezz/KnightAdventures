using UnityEngine;
[RequireComponent(typeof(Animator))]
public class EnemiesAnimator : MonoBehaviour
{
    private Animator enemiesAnim;
    private void Awake()
    {
        enemiesAnim = GetComponent<Animator>();
    }
    public void EnemieDie(bool isDie)
    {
        enemiesAnim.SetBool("Death", isDie);
    }
    public void EnemieHurt()
    {
        enemiesAnim.SetTrigger("Hurt");
    }
    public void EnemieDead()
    {
        EnemieDie(false);
    }
    public void EnemyAttack()
    {
        enemiesAnim.SetTrigger("Attack");
    }
    public void EnemyWalk()
    {
        enemiesAnim.SetInteger("AnimState", 2);
    }
    public void EnemyCombat()
    {
        enemiesAnim.SetInteger("AnimState", 1);
    }
    public void EnemyIdle()
    {
        enemiesAnim.SetInteger("AnimState", 0);
    }
}