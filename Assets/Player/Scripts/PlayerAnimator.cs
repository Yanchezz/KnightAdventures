using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnim;
    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }
    public void Run()
    {
        playerAnim.SetBool("isRun", true);
    }
    public void StopRun()
    {
        playerAnim.SetBool("isRun", false);
    }
    public void IsGrounded(bool isIt)
    {
        playerAnim.SetBool("isGrounded", isIt);
    }
    public void SpeedCheck(float speed)
    {
        playerAnim.SetFloat("vSpeed", speed);
    }
    public void Hurt()
    {
        playerAnim.SetTrigger("Hurt");
    }
    public void Death(bool isDeath)
    {
        playerAnim.SetBool("Death", isDeath);
    }
    public void Attack1()
    {
        playerAnim.SetTrigger("Attack1");
    }
    public void Attack2()
    {
        playerAnim.SetTrigger("Attack2");
    }
    public void Attack3()
    {
        playerAnim.SetTrigger("Attack3");
    }
    public void Block(bool isIt)
    {
        playerAnim.SetBool("Block", isIt);
    }
}