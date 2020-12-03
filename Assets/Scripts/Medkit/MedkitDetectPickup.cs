using UnityEngine;
using System;

public class MedkitDetectPickup : MonoBehaviour
{
    public event Action<GameObject> OnPickupMedkit = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            OnPickupMedkit(other.gameObject);
    }
}
