using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpOffset;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private PlayerAnimator playerAnimator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<PlayerAnimator>();    
    }
    private void FixedUpdate()
    { 
        isGrounded = Physics2D.OverlapCircle(groundColliderTransform.position, jumpOffset, groundMask);
        playerAnimator.IsGrounded(isGrounded);
        playerAnimator.SpeedCheck(rb.velocity.y);
    }
    public void Move(float direction, bool isJumpPressed)
    {
        if (direction != 0) 
        { 
            if (direction <0)
            {
                transform.localScale = new Vector2(-1 , 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            playerAnimator.Run();
        }
        else
        {
            playerAnimator.StopRun();
        }
        if (isJumpPressed) { Jump(); }
    }
    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}