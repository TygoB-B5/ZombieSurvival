using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Text healthText;
    public Text medkitText;
    public Text ammoText;
    public Text scoreText;

    private GunAmmo gunAmmo;

    private void Awake()
    {
        FindObjectOfType<PlayerHealth>().OnUpdateHealth += UpdateUi;
        FindObjectOfType<PlayerInventory>().OnUpdateInventory += UpdateUi;
        FindObjectOfType<PlayerScore>().OnScoreUpdate += UpdateUi;

        ReReferenceOnGunChange();
    }

    private void ReReferenceOnGunChange()
    {
        gunAmmo = FindObjectOfType<GunAmmo>();
        FindObjectOfType<GunAmmo>().OnUpdateAmmo += UpdateUi;
    }

    private void UpdateUi()
    {
        healthText.text = "Health: " + FindObjectOfType<PlayerHealth>().health.ToString();
        medkitText.text = "Medkits: " + FindObjectOfType<PlayerInventory>().slots[0].item.count.ToString();
        ammoText.text = "Ammo: " + gunAmmo.ammo.ToString();
        scoreText.text = "Score: " + FindObjectOfType<PlayerScore>().score;
    }
}


