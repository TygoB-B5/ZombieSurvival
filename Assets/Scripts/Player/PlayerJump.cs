using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpStrength = default;
    private PlayerInput playerInput;
    private Rigidbody rb;
    public bool isGrounded { get; private set; }

    public event Action OnJump = delegate { };

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        OnJump += Jump;
    }

    private void Update()
    {
        isGrounded = IsOnGround();

        if (playerInput.Jump && isGrounded)
            OnJump();
    }

    private bool IsOnGround()
    {
        if (Physics.Raycast(transform.position, -transform.up, 2))
            return true;
        else
            return false;
    }

    private void Jump()
    {
        rb.velocity = new Vector3(0, jumpStrength, 0);
    }

}
