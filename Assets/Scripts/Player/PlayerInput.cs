using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }
    public bool Jump { get; private set; }
    public bool Shoot { get; private set; }
    public bool SingleShoot { get; private set; }
    public bool Sprint { get; private set; }
    public bool SwitchGunMode { get; private set; }
    public bool Reload { get; private set; }
    //inventory
    public bool Keyboard1 { get; private set; }
    public bool Keyboard2 { get; private set; }
    public bool Keyboard3 { get; private set; }
    public bool Keyboard4 { get; private set; }
    public bool Keyboard5 { get; private set; }
    public bool Keyboard6 { get; private set; }
    public bool Keyboard7 { get; private set; }
    public bool Keyboard8 { get; private set; }
    public bool Keyboard9 { get; private set; }

    private const float deadzone = 0.05f;

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal < deadzone && Horizontal > -deadzone)
            Horizontal = 0;
        if (Vertical < deadzone && Vertical > -deadzone)
            Vertical = 0;

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        Jump = Input.GetKeyDown(KeyCode.Space);
        Shoot = Input.GetMouseButton(0);
        SingleShoot = Input.GetMouseButtonDown(0);
        Sprint = Input.GetKey(KeyCode.LeftShift);
        SwitchGunMode = Input.GetKeyDown(KeyCode.B);
        Reload = Input.GetKeyDown(KeyCode.R);
        //inventory
        Keyboard1 = Input.GetKeyDown(KeyCode.Q);
        Keyboard2 = Input.GetKeyDown(KeyCode.Alpha2);
        Keyboard3 = Input.GetKeyDown(KeyCode.Alpha3);
        Keyboard4 = Input.GetKeyDown(KeyCode.Alpha4);
        Keyboard5 = Input.GetKeyDown(KeyCode.Alpha5);
        Keyboard6 = Input.GetKeyDown(KeyCode.Alpha6);
        Keyboard7 = Input.GetKeyDown(KeyCode.Alpha7);
        Keyboard8 = Input.GetKeyDown(KeyCode.Alpha8);
        Keyboard9 = Input.GetKeyDown(KeyCode.Alpha9);
    }
}
