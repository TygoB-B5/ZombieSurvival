using UnityEngine;

[RequireComponent(typeof(MedkitDetectPickup))]
public class MedkitDestroy : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MedkitDetectPickup>().OnPickupMedkit += DestroyObject;
    }

    private void DestroyObject(GameObject player)
    {
        Destroy(gameObject.GetComponent<Collider>(), 0);
        Destroy(gameObject.GetComponent<MeshRenderer>(), 0);

        if (GetComponent<MedkitSound>())
            Destroy(gameObject, GetComponent<MedkitSound>().aud.clip.length);
        else
            Destroy(gameObject, 0);
    }
}
