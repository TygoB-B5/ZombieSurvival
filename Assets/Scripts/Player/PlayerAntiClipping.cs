using UnityEngine;
using UnityEngine.Video;

public class PlayerAntiClipping : MonoBehaviour
{
    private PlayerEngine playerEngine;
    // Update is called once per frame
    private void Awake()
    {
        playerEngine = FindObjectOfType<PlayerEngine>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Physics.OverlapSphere(transform.position + transform.up * 0.5f, 0.5f).Length != 1)
        {
            playerEngine.currentMovement = -playerEngine.currentMovement / 1.5f;
        }
    }
}
