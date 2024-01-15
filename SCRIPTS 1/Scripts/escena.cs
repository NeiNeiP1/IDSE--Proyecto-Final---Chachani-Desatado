using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class escena : MonoBehaviour
{
    public string sceneName;
    public Collider collision;
    public GameObject loadingScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            loadingScreen.SetActive(true);
            SceneManager.LoadScene(sceneName);

            collision.enabled = false;

        }

    }
}
