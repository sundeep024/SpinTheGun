using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponRigidBody : MonoBehaviour
{
    //Weapon Variables...
    [SerializeField] private Rigidbody2D _weaponRD;
    private float rotateSpeed = 100;
    [SerializeField] private Transform gun;
    private bool isRotate;


    //Weapon Bullets variables...
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _SpawnPoint;
    public GameObject _spawnHolder;
    private float shootTime = 0;
    private bool isShoot = true;
    public ParticleSystem muzzleFlash;

    public static int BULLETCOUNT = 20;
    public static int _SCORE;

    [SerializeField]
    private float bulletForce = 50;


    //Canvas Display...
    public GameObject gameOverCanvas;
    public GameObject gamePlayCanvas;
    public GameObject gunGameObject;
    public GameObject coinGameObject;


    public Transform weaponRightPosition;
    public Transform weaponLeftPosition;

    float posX = 2.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        _SCORE = 0;
        BULLETCOUNT = 20;
        gamePlayCanvas.SetActive(true);
        gunGameObject.SetActive(true);
        gameOverCanvas.SetActive(false);
        coinGameObject.SetActive(true);
        isRotate = true;        
        StartCoroutine(GunRotate());
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen Height : " + Screen.height);
    }

    private void Update()
    {        
        if (Time.time > shootTime)
        {
            isShoot = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(BULLETCOUNT < 0)
            {
                BULLETCOUNT = 0;
                Debug.Log("GameOver..");
                CanvasOnOff();
            }
            else
            {
                GunShoot();
            }
        }
        
        WeaponLeftToRight();


        WeaponForce();
    }

    public void GunShoot()
    {
        if (isShoot == false)
        {
            return;
        }
        AudioManager.PlayGunFireClip();
        muzzleFlash.Play();
        Rigidbody2D bulletRD = Instantiate(_bullet, _SpawnPoint.position, _SpawnPoint.rotation);
        bulletRD.AddForce(_SpawnPoint.right * bulletForce, ForceMode2D.Impulse);
        bulletRD.transform.SetParent(_spawnHolder.transform);                
        BULLETCOUNT--;
    }

    public void WeaponForce()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AudioManager.PlayGunBackForceClip();
            _weaponRD.AddForce(-_weaponRD.transform.right * 1.5f, ForceMode2D.Impulse);
        }
    }
    
    IEnumerator GunRotate()
    {
        while (isRotate)
        {
            yield return new WaitForSeconds(0.08f);
            transform.Rotate(0,0,10.0f * rotateSpeed * Time.deltaTime, Space.Self);
        }
    }
    public void WeaponLeftToRight()
    {
        if (_weaponRD.position.x > posX)
        {
            _weaponRD.position = weaponRightPosition.position;
        }
        if(_weaponRD.position.x < -posX)
        {
            _weaponRD.position = weaponLeftPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioManager.PlayGunPickUpClip();
            WeaponRigidBody.BULLETCOUNT = WeaponRigidBody.BULLETCOUNT + 2;
            Debug.Log("Score is " + WeaponRigidBody.BULLETCOUNT);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            _SCORE = _SCORE + 5;
            AudioManager.PlayCoinCollectClip();
            Debug.Log("Score is " + _SCORE);
        }
        if(collision.gameObject.tag == "Border" )
        {
            CanvasOnOff();
            Debug.Log("GameOver...");
            Debug.Log("Weapon Destroyed...");
           // BULLETCOUNT = 20;
        }
    }

    public void CanvasOnOff()
    {
        gameOverCanvas.SetActive(true);
        gamePlayCanvas.SetActive(false);
        gunGameObject.SetActive(false);
        coinGameObject.SetActive(false);
    }
}
