using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    [SerializeField] private float recoilStrength = default;
    [SerializeField] private float smoothStrength = default;
    [SerializeField] private float returnSpeed = default;
    private CameraLook cameraLook;
    private float v;

    private void Awake()
    {
        cameraLook = FindObjectOfType<CameraLook>();
        FindObjectOfType<GunShoot>().OnShootGun += Shoot;
    }

    private void Shoot()
    {
        v += recoilStrength;
    }

    private void LateUpdate()
    {
        if (v == 0)
            return;

        cameraLook.rotY = Mathf.Lerp(cameraLook.rotY, cameraLook.rotY + v, smoothStrength * Time.deltaTime);
        v = Mathf.Lerp(v, 0, returnSpeed * Time.deltaTime);
    }
}
