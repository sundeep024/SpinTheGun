using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] public GameObject[] _collectPrefabs;
    private float _offsetY;
    private float _minX, maxX;
    private float _posY;


    // Start is called before the first frame update
    void Start()
    {
        //Vector3 spawnPos = new Vector2(Random.Range(_posX));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
