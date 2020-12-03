using UnityEngine;

public class MedkitMovement : MonoBehaviour
{
    [SerializeField] private float waveLength = default;
    [SerializeField] private float waveSpeed = default;
    [SerializeField] private float rotationSpeed = default;

    private float t;

    private void Update()
    {
        t += waveSpeed * Time.deltaTime;
        if (t > Mathf.PI * 2)
        {
            t -= Mathf.PI * 2;
        }

        transform.position += new Vector3(0, 1, 0) * Mathf.Sin(t) * waveLength * Time.deltaTime;

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
