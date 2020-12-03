using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;
    private Transform player;
    private float rotX;
    public float rotY { get; set; }

    public float sensitivity;

    private void Awake()
    {
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        playerInput = FindObjectOfType<PlayerInput>();
        cam = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        //clamp Y angle
        rotX += playerInput.MouseX * sensitivity;
        rotY += playerInput.MouseY * sensitivity;
        rotY = Mathf.Clamp(rotY, -90, 90);

        //rotate
        cam.transform.localRotation = Quaternion.Euler(Vector3.right * -rotY);
        player.transform.localRotation = Quaternion.Euler(Vector3.up * rotX);
    }
}
