using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffectsOnHealth : MonoBehaviour
{
    public PostProcessProfile pp;
    private PlayerHealth playerHealth;

    [SerializeField] private float chromaticRate = default;
    private float t;


    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        Timer();

        float v = Mathf.Sin((playerHealth.maxHealth / (float)playerHealth.health) / playerHealth.maxHealth * 2.5f) * 3 - 0.24f;
        v *= Mathf.Abs(Mathf.Sin(t));
        float d =  playerHealth.health * 1.5f;

        pp.TryGetSettings(out DepthOfField depth);
        pp.TryGetSettings(out ChromaticAberration chrom);
        depth.focusDistance.value = d * 1 + Mathf.Abs(Mathf.Sin(t));
        chrom.intensity.value = v;
    }

    private void Timer()
    {
        t += chromaticRate * Time.deltaTime;

        if (t > Mathf.PI * 2)
            t -= Mathf.PI * 2;
    }
}
