using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
    }
    void Update()
    {
        Movement();
        Combat();
    }
    private void Movement()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
        playerMovement.Move(horizontalDirection, isJumpPressed);
    }
    private void Combat()
    {
        if (Input.GetButtonDown(GlobalStringVars.ATTACK) && !playerAttack.isAttack) { playerAttack.Attack(); }
    }
}