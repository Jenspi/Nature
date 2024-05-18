using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// https://www.youtube.com/watch?v=wiuJiFQ78kQ
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public TMP_Text waterCounterText;
    public int waterCount;

    void Start(){
        waterCounterText.text = waterCount.ToString();
    }

    void Update(){
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Obstacle"){
            waterCount--;
            waterCounterText.text = waterCount.ToString();
        }
    }
}
