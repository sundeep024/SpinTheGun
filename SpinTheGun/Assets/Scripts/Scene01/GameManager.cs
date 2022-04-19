using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GotoGamePlay()
    {
        AudioManagerScene01.PlayButtonClickClip();
        Debug.Log("Game Play Screen...");
        SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame()
    {
        AudioManagerScene01.PlayButtonClickClip();
        Debug.Log("Game Exit...");
        Application.Quit();
    }
}
