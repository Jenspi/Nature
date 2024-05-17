using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum SpawnerDirectionType{
        Top, Bottom, Left, Right
    }

    public SpawnerDirectionType spawnerDirectionType;

    public enum ObstacleType{
        Cloud, Branch, Plane
    }
    public ObstacleType obstacleType;

    public void SpawnObstacle(){
        // Instantiate blah blah
        Debug.Log("spawning obstacle");
    }
}
