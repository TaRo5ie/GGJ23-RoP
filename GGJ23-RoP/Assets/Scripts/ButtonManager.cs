using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("S1");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Credits");
    }


    public void QuitGame()
        {
        Debug.Log("exit game");
            Application.Quit();
        }
}

