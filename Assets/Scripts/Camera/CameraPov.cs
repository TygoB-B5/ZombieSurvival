using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class CameraPov : MonoBehaviour
{
    private PlayerEngine playerEngine;
    private Camera cam;
    private float camFovDynamic;
    private float camFovStatic;

    [SerializeField] private float zoomOutMultiplier = default;

    private void Awake()
    {
        playerEngine = GetComponentInParent<PlayerEngine>();
        cam = GetComponent<Camera>();
        camFovStatic = cam.fieldOfView;
        camFovDynamic = cam.fieldOfView;
    }

    private void Update()
    {
        float movementSpeed = playerEngine.currentPlayerSpeed;
        camFovDynamic = camFovStatic + movementSpeed * zoomOutMultiplier;
        cam.fieldOfView = camFovDynamic;
    }
}
