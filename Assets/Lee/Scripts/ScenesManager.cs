using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void SelectScene()
    {
        SceneManager.LoadScene("Select");
    }
}