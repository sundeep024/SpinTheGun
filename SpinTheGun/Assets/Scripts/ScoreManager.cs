using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text score;
    //private int pScore;
    public Text bullets;

    private void Start()
    {
        score.text = "Score : 00";// + WeaponRigidBody._SCORE.ToString();        bullets.text = WeaponRigidBody.BULLETCOUNT.ToString();
        bullets.text = " 00 ";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : "+ WeaponRigidBody._SCORE.ToString();
        //PlayerPrefs.SetInt("Score", WeaponRigidBody._SCORE);
        bullets.text = WeaponRigidBody.BULLETCOUNT.ToString();
    }

    
}
