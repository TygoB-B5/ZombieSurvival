using UnityEngine;

[RequireComponent(typeof(MedkitDetectPickup))]
public class MedkitAddToInventory : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MedkitDetectPickup>().OnPickupMedkit += AddMedkit;
    }

    private void AddMedkit(GameObject player)
    {
        player.GetComponent<PlayerInventory>().Add("Medkit", 1);
    }
}
