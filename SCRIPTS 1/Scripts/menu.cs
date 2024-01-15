using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    public GameObject loadingScreen;
    public string sceneName;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void playGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneName);

    }
    public void quitGame()
    {
        Debug.Log("Para salir del juego");
        Application.Quit();
    }
    public void drive()
    {
        Application.OpenURL("");
    }
}
