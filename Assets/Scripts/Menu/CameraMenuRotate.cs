using UnityEngine;

public class CameraMenuRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * 3 * Time.deltaTime);   
    }
}
