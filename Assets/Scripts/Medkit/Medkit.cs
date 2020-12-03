using UnityEngine;

public class Medkit : MonoBehaviour
{
    public GameObject thisMedkit { get; private set; }

    private void Awake()
    {
        thisMedkit = this.gameObject;
    }

    private void Start()
    {
        MedkitManager.medkits.Add(this);
    }

    private void OnDestroy()
    {
        MedkitManager.medkits.Remove(this);
    }
}
