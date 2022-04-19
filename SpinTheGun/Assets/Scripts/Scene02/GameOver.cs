using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text score;
    public Text highscore;
  

    private void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void Update()
    {
        score.text = WeaponRigidBody._SCORE.ToString();
        int Score= WeaponRigidBody._SCORE;
        score.text = Score.ToString();
        if(Score  > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            highscore.text = Score.ToString();
        }
    }

public void MainManu()
    {
        AudioManager.PlayButtonClickClip();
        SceneManager.LoadScene("GameMainMenu");
    }
    public void GoToHome()
    {
        AudioManager.PlayButtonClickClip();
        Debug.Log("Goto Home Screen...");
        SceneManager.LoadScene("GameMainMenu");
    }

    public void GameRestart()
    {
        AudioManager.PlayButtonClickClip();
        Debug.Log("GamePlay Screen...");
        SceneManager.LoadScene("GamePlay");
    }
}
