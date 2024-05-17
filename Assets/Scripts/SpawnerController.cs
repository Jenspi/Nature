using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<Spawner> horizontalSpawners;
    public List<Spawner> verticalSpawners;
    public List<Spawner> diagonalSpawners;

    public float spawningDelay;
    public int maxObstacles;

    public int numOfObstacles;

    // spawnercontroller is static and a singleton which means that there is only ever one of these
    public static SpawnerController Instance;

    void Awake(){
        Instance = this;
    }

    void Start(){
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles(){
        while (numOfObstacles < maxObstacles){
            if (horizontalSpawners.Count > 0){
                horizontalSpawners[Random.Range(0, horizontalSpawners.Count-1)].SpawnObstacle();
                numOfObstacles++;
            }
            if (verticalSpawners.Count > 0){
                verticalSpawners[Random.Range(0, verticalSpawners.Count-1)].SpawnObstacle();
                numOfObstacles++;
            }
            if (diagonalSpawners.Count > 0){
                diagonalSpawners[Random.Range(0, diagonalSpawners.Count-1)].SpawnObstacle();
                numOfObstacles++;
            }
            yield return new WaitForSeconds(spawningDelay);
        }
    }

    // a public method that any child spawner can call in case numOfObstacles is made private
    public void DecrementNumOfObstacles(){
        numOfObstacles--;
    }
}
