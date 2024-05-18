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
            transform.position = new Vector3(transform.position.x, this.transform.position.y - moveSpeed, 0);
        }
        if (direction == ObstacleDirection.North){
            transform.position = new Vector3(transform.position.x, this.transform.position.y + moveSpeed, 0);
        }
        if (direction == ObstacleDirection.Southwest){
            transform.position = new Vector3(transform.position.x - moveSpeed, this.transform.position.y - moveSpeed, 0);
        }
        if (direction == ObstacleDirection.Southeast){
            transform.position = new Vector3(transform.position.x + moveSpeed, this.transform.position.y - moveSpeed, 0);
        }
        if (direction == ObstacleDirection.Northwest){
            transform.position = new Vector3(transform.position.x - moveSpeed, this.transform.position.y + moveSpeed, 0);
        }
        if (direction == ObstacleDirection.Northeast){
            transform.position = new Vector3(transform.position.x + moveSpeed, this.transform.position.y + moveSpeed, 0);
        }
    }

    // destroy this obstacle once it hits a kill box
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "KillBox"){
            Destroy(this.gameObject);
        }
    }
}
