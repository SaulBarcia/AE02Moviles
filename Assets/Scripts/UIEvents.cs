using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{
    public GameObject PauseMenu;
    void Start()
    {
        PauseMenu.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
        if (PauseMenu != null && GameObject.Find("DeathMenu") != null)
        {
            PauseMenu.SetActive(false);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ActivatePause()
    {
        Time.timeScale = 0f;
        if (GameObject.Find("DeathMenu") == null)
        {
            PauseMenu.SetActive(true);
        }
    }
}
