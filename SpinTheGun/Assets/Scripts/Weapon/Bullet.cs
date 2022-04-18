using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletRemove());
    }

    public IEnumerator BulletRemove()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
            
}
