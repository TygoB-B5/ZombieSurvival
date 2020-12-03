using UnityEngine;

public class ArmAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerEngine playerEngine;
    private PlayerInput playerInput;
    private float walkSpeed, sprintSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerInput = FindObjectOfType<PlayerInput>();
        playerEngine = FindObjectOfType<PlayerEngine>();
    }

    private void Update()
    {
        if (playerInput.Horizontal == 0 && playerInput.Vertical == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isSprinting", false);
        }
        else if(!playerInput.Sprint)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isSprinting", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isSprinting", true);
        }
    }
}
