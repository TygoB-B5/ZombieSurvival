using UnityEngine;

public class GunShotMode : MonoBehaviour
{
    private PlayerInput playerInput;

    public enum GunMode { Semi, Auto, Burst }
    public GunMode gunMode;
    private byte gunModeId;

    [SerializeField] private bool canBeAuto = default;
    [SerializeField] private bool canBeSemi = default;
    [SerializeField] private bool canBeBurst = default;

    public AudioSource gunModeClick;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();

        if (!canBeAuto && !canBeSemi && !canBeBurst)
            canBeSemi = true;
    }

    private void Update()
    {
        if (playerInput.SwitchGunMode)
        {
            gunModeId++;
        }

        if (gunModeId >= 3)
            gunModeId = 0;

        SwitchGunMode();
    }

    private void SwitchGunMode()
    {
        switch (gunModeId)
        {
            case 0:
                if (canBeSemi)
                    gunMode = GunMode.Semi;
                else
                {
                    gunModeId++;
                    SwitchGunMode();
                }
                break;

            case 1:
                if (canBeAuto)
                    gunMode = GunMode.Auto;
                else
                {
                    gunModeId++;
                    SwitchGunMode();
                }
                break;

            case 2:
                if (canBeBurst)
                    gunMode = GunMode.Burst;
                else
                {
                    gunModeId = 0;
                    SwitchGunMode();
                }
                break;
        }
    }
}
