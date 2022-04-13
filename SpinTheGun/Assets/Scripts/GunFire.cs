using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _gunPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootGun();
    }


    public void ShootGun()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody2D Shoot = Instantiate(_bullet, _gunPoint.position , Quaternion.identity);

            Shoot.velocity = transform.TransformDirection(Vector3.forward * 100);

        }
    }
}
