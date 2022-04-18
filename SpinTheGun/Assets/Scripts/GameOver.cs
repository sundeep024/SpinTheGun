using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text score;

    private void Update()
    {
        score.text = "Score : " + WeaponRigidBody._SCORE.ToString();
    }


    public void MainManu()
    {
        SceneManager.LoadScene("GameMainMenu");
    }


}
