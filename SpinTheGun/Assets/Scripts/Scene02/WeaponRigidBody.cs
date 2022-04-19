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
    [SerializeField] private float bulletForce = 50;


    //Weapon Bullets variables...
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _SpawnPoint;
    public GameObject _spawnHolder;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private Transform _muzzleFlashPoint;
    private float shootTime = 0;
    private bool isShoot = true;
    //public ParticleSystem muzzleFlash;

    //Game Score  and Bullet count Variables...
    public static int BULLETCOUNT = 20;
    public static int _SCORE;    

    //Canvas Display...
    public GameObject gameOverCanvas;
    public GameObject gamePlayCanvas;
    public GameObject gunGameObject;
    public GameObject coinGameObject;
    public GameObject gameBulletOver;


    public Transform weaponRightPosition;
    public Transform weaponLeftPosition;
    //Vector2 screenBounds; 

    float posX = 2.1f;

    
    // Start is called before the first frame update
    void Start()
    {
        _SCORE = 0;
        BULLETCOUNT = 20;
        //Canvas True or False Activation...
        gamePlayCanvas.SetActive(true);
        gunGameObject.SetActive(true);
        gameOverCanvas.SetActive(false);
        coinGameObject.SetActive(true);
        gameBulletOver.SetActive(false);

        isRotate = true;

        //StartCoroutine(StartGame());
        //Gun rotation method
        StartCoroutine(GunRotate());
        //Debug.Log("Screen Width : " + Screen.width);
        //Debug.Log("Screen Height : " + Screen.height);
    }
    
    
    
    private void Update()
    {        
        if (Time.time > shootTime)
        {
            isShoot = true;
        }
        //When User tounch on screen or press mouse button
        if (Input.GetMouseButtonDown(0))
        {
            if(BULLETCOUNT <= 0)    // when bullet zero than game over
            {
                BULLETCOUNT = 0;
                Debug.Log("GameOver..");
                BulletOverCanvas();
                //_weaponRD.position = Vector2.zero;
            }
            else
            {
                GunShoot();     // otherwise user can shoot 
            }
        }        
        WeaponLeftToRight();    // gun move left to right and right to left
        
        WeaponForce();  // weapon force to opposite side when user fire
    }

    public void GunShoot()
    {
        if (isShoot == false)
        {
            return;
        }
        AudioManager.PlayGunFireClip(); // play sound when fire
       // muzzleFlash.Play();
        //bullet instantiate, set bullet position and rotation of bullet 
        Rigidbody2D bulletRD = Instantiate(_bullet, _SpawnPoint.position, _SpawnPoint.rotation);
        GameObject mf = Instantiate(_muzzleFlash, _muzzleFlashPoint.position, Quaternion.identity);
        Destroy(mf, 0.03f);
        //bullet fire on right side of gun point and force
        bulletRD.AddForce(_SpawnPoint.right * bulletForce, ForceMode2D.Impulse);

        //Instantiate bullet set patent  
        bulletRD.transform.SetParent(_spawnHolder.transform);   
        
        //user fire bullet and descrease bullet count
        BULLETCOUNT--;
    }

    public void WeaponForce()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AudioManager.PlayGunBackForceClip();
            //when a gun fire than weapon force to opposite side
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
        /*screenBounds = new Vector2(Screen.width, Screen.height);
        //Vector3 pos = _weaponRD.position;
        if(_weaponRD.position.x >screenBounds.x)
        {
            _weaponRD.position = weaponRightPosition.position;
        }*/

        //check weapon position bound the screen X position
        if (_weaponRD.position.x > posX)
        {
            Debug.Log("Weapon X Value" + _weaponRD.position.x);
            _weaponRD.position = weaponRightPosition.position;
        }
        if (_weaponRD.position.x < -posX)
        {
            _weaponRD.position = weaponLeftPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // weapon collect bullet increase score plus 2
        if (collision.gameObject.tag == "Bullet")
        {
            AudioManager.PlayGunPickUpClip();
            WeaponRigidBody.BULLETCOUNT = WeaponRigidBody.BULLETCOUNT + 2;
            Debug.Log("Score is " + WeaponRigidBody.BULLETCOUNT);
            Destroy(collision.gameObject);
        }

        // weapon collect multibullet increase score plus 5
        if (collision.gameObject.tag == "MultiBullet")
        {
            AudioManager.PlayGunPickUpClip();
            WeaponRigidBody.BULLETCOUNT = WeaponRigidBody.BULLETCOUNT + 5;
            Debug.Log("Score is " + WeaponRigidBody.BULLETCOUNT);
            Destroy(collision.gameObject);
        }

        // weapon collect coin increase score plus 5
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            _SCORE = _SCORE + 5;
            AudioManager.PlayCoinCollectClip();
            Debug.Log("Score is " + _SCORE);
        }

        //when weapon touch Top and Bottom border game over
        if(collision.gameObject.tag == "Border" )
        {
            CanvasOnOff();
            AudioManager.PlayGameOverClip();
            Debug.Log("GameOver...");
            Debug.Log("Weapon Destroyed...");
           // _weaponRD.position = Vector2.zero;
           // BULLETCOUNT = 20;
        }
        // weapon touch redZone and add force to weapon
        if (collision.gameObject.tag == "RedZone")
        {
            Debug.Log("Red Zone Activate");
            AudioManager.PlayRedZoneClip();
            _weaponRD.AddForce(-_weaponRD.transform.right * 2.2f, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
    }

    //if weapon touch Top or Bottom Border display game over canvas
    public void CanvasOnOff()
    {
        gameOverCanvas.SetActive(true);
        gamePlayCanvas.SetActive(false);
        gunGameObject.SetActive(false);
        coinGameObject.SetActive(false);
    }

    //if weapon Bullet is over display bullet over canvas..
    public void BulletOverCanvas()
    {
        gameBulletOver.SetActive(true);
        gameOverCanvas.SetActive(false);
        gamePlayCanvas.SetActive(false);
        gunGameObject.SetActive(false);
        coinGameObject.SetActive(false);
    }
}
