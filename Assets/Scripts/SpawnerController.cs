using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<Spawner> spawners;

    public int maxObstacles;
    private int numOfObstacles = 0;

    public bool atMax;

    void Start(){
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfObstacles == maxObstacles){
            atMax = true;
        }
    }

    IEnumerator SpawnObstacles(){
        Spawner randomSpawner = spawners[Random.Range(0, spawners.Count)];
        randomSpawner.SpawnObstacle();
        yield return new WaitUntil(() => atMax == true);
    }
}
