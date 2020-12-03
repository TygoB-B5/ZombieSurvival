using UnityEngine;

public class PlayerEngine : MonoBehaviour
{
    private PlayerInput playerInput;

    public Vector3 currentMovement { get; set; }

    [SerializeField]private float playerSpeed = default;
    [SerializeField]private float playerSprintSpeed = default;
    [SerializeField]private float updateCurrentSpeedTime = default;

    public float playerSpeed_ { get; private set; }
    public float playerSprintSpeed_ { get; private set; }
    public float currentPlayerSpeed { get; private set; }

    private void Awake()
    {
        playerSpeed_ = playerSpeed;
        playerSprintSpeed_ = playerSprintSpeed;

        playerInput = GetComponent<PlayerInput>();
    }

    private void LateUpdate()
    {
        transform.position += currentMovement;

        SetCurrentPlayerSpeed();

        currentMovement = transform.forward * playerInput.Vertical * currentPlayerSpeed * Time.deltaTime + transform.right * playerInput.Horizontal * currentPlayerSpeed * Time.deltaTime;
    }

    private void SetCurrentPlayerSpeed()
    {
        if (playerInput.Horizontal == 0 && playerInput.Vertical == 0)
        {
            currentPlayerSpeed = Mathf.Lerp(currentPlayerSpeed, 0, updateCurrentSpeedTime * Time.deltaTime);
            return;
        }

        if (playerInput.Sprint)
        {
            if (playerInput.Horizontal != 0 && playerInput.Vertical != 0)
                currentPlayerSpeed = Mathf.Lerp(currentPlayerSpeed, playerSprintSpeed * 0.9f, updateCurrentSpeedTime * Time.deltaTime);
            else
                currentPlayerSpeed = Mathf.Lerp(currentPlayerSpeed, playerSprintSpeed, updateCurrentSpeedTime * Time.deltaTime);
        }
        else
        {
            if (playerInput.Horizontal != 0 && playerInput.Vertical != 0)
                currentPlayerSpeed = Mathf.Lerp(currentPlayerSpeed, playerSpeed * 0.9f, updateCurrentSpeedTime * Time.deltaTime);
            else
                currentPlayerSpeed = Mathf.Lerp(currentPlayerSpeed, playerSpeed, updateCurrentSpeedTime * Time.deltaTime);
        }
    }
}
