using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rd;
    private float rotateSpeed = 70;
    [SerializeField] private Transform gun;
    private bool isRotate = true;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(GunRotate());
    }

    IEnumerator GunRotate()
    {
        while(isRotate)
        {
            yield return new WaitForSeconds(0.2f);
            transform.Rotate(0, 0, 90.0f * rotateSpeed * Time.deltaTime, Space.World);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,90.0f), rotateSpeed *Time.deltaTime);
        }        
    }

    private void FixedUpdate()
    {
        
    }
}
