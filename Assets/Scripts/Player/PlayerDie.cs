using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<PlayerHealth>().OnDie += Die;
    }

    private void Die()
    {
        FindObjectOfType<Camera>().fieldOfView = 0;
        Destroy(FindObjectOfType<GunShoot>());
        Destroy(FindObjectOfType<PlayerEngine>());
        Destroy(GameObject.FindWithTag("Player").gameObject.GetComponent<Rigidbody>());
        GameObject.FindWithTag("MainCamera").gameObject.AddComponent<Rigidbody>();
        GameObject.FindWithTag("MainCamera").gameObject.AddComponent<BoxCollider>();

        StartCoroutine(GoToGameOverScene());
    }

    private IEnumerator GoToGameOverScene()
    {
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
