using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("game");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("��");
    }
    public void tutorial()
    {
        SceneManager.LoadScene("Ttutorial");
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}