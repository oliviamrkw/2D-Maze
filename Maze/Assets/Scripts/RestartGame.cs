using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level00");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
