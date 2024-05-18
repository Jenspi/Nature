using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondensationSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _spawnTime;
    
    [Header("Spawn Values")]
    [SerializeField] private int _randomTarget;
    [SerializeField] private int _minRandomValue;
    [SerializeField] private int _maxRandomValue;

    [Header("Scale")]
    [SerializeField] private int _xMin;
    [SerializeField] private int _xMax;
    [SerializeField] private int _yMin, _yMax;
    [SerializeField] private int _zMin, _zMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        for(;;){
            float random = Random.Range(_minRandomValue, _maxRandomValue);
            if(random >= _randomTarget){
                CreateObject();
            }
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    void CreateObject()
    {
        GameObject newObject = Instantiate(_prefab, this.transform.position, Quaternion.identity);
        Vector3 randomSize = new Vector3(Random.Range(_xMin, _xMax), Random.Range(_yMin, _yMax), Random.Range(_zMin, _zMax));
        newObject.transform.localScale = randomSize;
        newObject.transform.position = this.transform.position;
    }
}
