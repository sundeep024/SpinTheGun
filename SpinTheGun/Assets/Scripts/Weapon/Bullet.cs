using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position.x;

        transform.Translate(0,0.01f,0);
        if(pos > 10.0f)
        {
            Destroy(gameObject,5.0f);
        }
    }
}
