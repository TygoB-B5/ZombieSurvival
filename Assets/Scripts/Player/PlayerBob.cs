using System;
using UnityEngine;

public class PlayerBob : MonoBehaviour
{
    private PlayerEngine playerEngine;
    private PlayerInput playerInput;
    private PlayerJump playerJump;
    private Rigidbody player;

    [SerializeField] private float bobSpeed = default;
    [SerializeField] private float bobHeight = default;
    [SerializeField] private float midPoint = default;

    private float timer;
    private float oldTimer;

    private float bob;
    private bool hasBobbedOnFloor;

    public event Action OnBobOnFloor = delegate { };

    private void Awake()
    {
        playerJump = FindObjectOfType<PlayerJump>();
        playerEngine = GetComponentInParent<PlayerEngine>();
        playerInput = GetComponentInParent<PlayerInput>();
        player = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        if((playerInput.Horizontal == 0 && playerInput.Vertical == 0) || !playerJump.isGrounded)
        {
            timer = Mathf.Lerp(timer, 0, 5 * Time.deltaTime);
        }
        else
        {
            LowestBob();

            timer += (bobSpeed * playerEngine.currentPlayerSpeed) / 10 * Time.deltaTime;

            if (timer > Mathf.PI * 2)
                timer = timer - (Mathf.PI * 2);
        }

        bob = Mathf.Sin(timer) * bobHeight + player.transform.position.y;

        transform.position = new Vector3(transform.position.x, bob + midPoint, transform.position.z);
    }

    private void LowestBob()
    {

        if (Mathf.Sin(timer) > oldTimer)
        {
            if (!hasBobbedOnFloor)
            {
                hasBobbedOnFloor = true;
                OnBobOnFloor();
            }
        }
        else
            hasBobbedOnFloor = false;

        oldTimer = Mathf.Sin(timer);
    }
}   
