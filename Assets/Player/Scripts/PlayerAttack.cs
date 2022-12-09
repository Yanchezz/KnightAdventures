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
        playerAnimator.Attack1(); //������ �������� �����
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer); //�������� ������ ����������� ���� ������ ������� ������ � ������ �����
        if (hitEnemies != null)
        {
            GameObject[] hitEnemiesObj = new GameObject[hitEnemies.Length]; 
            for (int i = 0; i < hitEnemies.Length; i++)
            {
                hitEnemiesObj[i] = hitEnemies[i].gameObject; // ������� ������ �������� � ���������� ���� ��� ������� ��� ���������� ������ � ���� �����
            }
            GameObject[] hitEnemiesUniq = hitEnemiesObj.Distinct().ToArray(); //������� ���������� �� ������� ��� ��� ����� ����� �������� � ���� ����� (� �� ��������� ������ ��������� ����������)
            foreach (GameObject enemy in hitEnemiesUniq)
            {
                enemy.gameObject.GetComponent<EnemiesHealth>().EnemieTakeDamage(damage); //������� ���� �� ������� ����� � �������
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