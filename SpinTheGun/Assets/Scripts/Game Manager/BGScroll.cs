using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public Transform follow;
    public float speed;


    public Transform image01, image02;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= image02.position.y)
        {
            image01.position = new Vector3(image01.position.x , image02.position.y,image01.position.z);
            Transform tempImage = image01;
            image01 = image02;
            image02 = tempImage;
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(follow.position.y + speed, 0);
    }
}
