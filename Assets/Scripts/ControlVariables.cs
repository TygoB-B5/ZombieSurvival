using UnityEngine;
using UnityEngine.UI;

public class ControlVariables : MonoBehaviour
{
    public Slider sensitivitySlider;

    private void Start()
    {
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
    }

    public void UpdateSensitivity()
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        PlayerPrefs.Save();
    }
}
