using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject menuPanel;

    public void Menu_button()
    {
        Time.timeScale = 0; //game pause
        menuPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        //restart is not working.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }
}
