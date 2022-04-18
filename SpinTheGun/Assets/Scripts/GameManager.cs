using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GotoGamePlay()
    {
        Debug.Log("Home Screen...");
        SceneManager.LoadScene("GamePlay");
    }
    public void ExitGame()
    {
        Debug.Log("Game Exit...");
        Application.Quit();
    }
}
