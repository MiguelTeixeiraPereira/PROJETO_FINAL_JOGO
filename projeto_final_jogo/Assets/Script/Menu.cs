using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void IrMenu()
    {
        SceneManager.LoadScene(0);


    }

    public void ActiveConfig(GameObject Config)
    {
        Config.SetActive(true);
    }

    public void DisableConfig(GameObject Config)
    {
        Config.SetActive(false);
    }

    public void ActivePause(GameObject Pause)
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void DisablePause(GameObject Pause)
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
}