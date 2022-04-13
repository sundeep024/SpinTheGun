using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _minX, _maxX;
    private bool isSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReSpawningObjects());    
    }

    IEnumerator ReSpawningObjects()
    {
        while(isSpawn)
        {
            yield return new WaitForSeconds(1.5f);

            float spawnRange = Random.Range(_minX, _maxX);
            Vector2 SpawnPosition = new Vector2(spawnRange, transform.position.y);

            GameObject clone = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], SpawnPosition , Quaternion.identity);

            Destroy(clone, 2.0f);
        }        
    }

}