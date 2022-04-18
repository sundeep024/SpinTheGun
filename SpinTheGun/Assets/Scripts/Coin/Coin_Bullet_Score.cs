using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Bullet_Score : MonoBehaviour
{
    public static int _SCORE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Weapon")
        {
            _SCORE = _SCORE + 5;
            Debug.Log("Score is " + _SCORE);
        }
        
    }
}
