using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    public Text bullets;

    private void Start()
    {
        score.text = "Score : 00";  // + WeaponRigidBody._SCORE.ToString();     
        bullets.text = " 00 ";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = WeaponRigidBody._SCORE.ToString();
        //PlayerPrefs.SetInt("Score", WeaponRigidBody._SCORE);
        bullets.text = WeaponRigidBody.BULLETCOUNT.ToString();
    }
    
    public void GoToHome()
    {
        AudioManager.PlayButtonClickClip();
        Debug.Log("Goto Home Screen...");
        SceneManager.LoadScene("GameMainMenu");
    }


}
