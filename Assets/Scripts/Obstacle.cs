using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum ObstacleDirection{
        North, Northeast, Northwest,
        South, Southeast, Southwest,
        East, West,
        None
    }

    public ObstacleDirection direction;
    public float moveSpeed;

    void FixedUpdate(){
        if (direction == ObstacleDirection.South){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - moveSpeed, 0);
        }
    }
}
