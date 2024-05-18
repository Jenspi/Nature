using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<Spawner> horizontalSpawners;
    public List<Spawner> verticalSpawners;
    public List<Spawner> diagonalSpawners;
    public List<Spawner> specialSpawners;

    public float horizontalSpawningDelay;
    public float verticalSpawningDelay;
    public float diagonalSpawningDelay;
    public float specialSpawningDelay;

    void Start(){
        if (horizontalSpawners.Count > 0){
            StartCoroutine(SpawnHorizontalObstacles());
        }
        if (verticalSpawners.Count > 0){
            StartCoroutine(SpawnVerticalObstacles());
        }
        if (diagonalSpawners.Count > 0){
            StartCoroutine(SpawnDiagonalObstacles());
        }
        if (specialSpawners.Count > 0){
            StartCoroutine(SpawnSpecialObstacles());
        }
    }

    IEnumerator SpawnHorizontalObstacles(){
        // will continue spawning forever with for(;;)
        for (;;){
            horizontalSpawners[Random.Range(0, horizontalSpawners.Count-1)].SpawnObstacle();
            yield return new WaitForSeconds(horizontalSpawningDelay);
        }
    }

    IEnumerator SpawnVerticalObstacles(){
        for (;;){
            verticalSpawners[Random.Range(0, verticalSpawners.Count-1)].SpawnObstacle();
            yield return new WaitForSeconds(verticalSpawningDelay);
        }
    }

    IEnumerator SpawnDiagonalObstacles(){
        for (;;){
            diagonalSpawners[Random.Range(0, diagonalSpawners.Count-1)].SpawnObstacle();
            yield return new WaitForSeconds(diagonalSpawningDelay);
        }
    }

    IEnumerator SpawnSpecialObstacles(){
        for (;;){
            specialSpawners[Random.Range(0, specialSpawners.Count-1)].SpawnObstacle();
            yield return new WaitForSeconds(specialSpawningDelay);
        }
    }
}
