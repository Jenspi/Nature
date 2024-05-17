using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// https://www.youtube.com/watch?v=wiuJiFQ78kQ
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public float jumpForce;
    //public Rigidbody2D rb2d;

    public TMP_Text waterCounterText;
    public int waterCount;

    void Start(){
        waterCounterText.text = waterCount.ToString();
    }

    void Update(){
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;

        // for jumping
        /*
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb2d.velocity.y) < 0.001f){
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        */
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Obstacle"){
            waterCount--;
            waterCounterText.text = waterCount.ToString();
        }
    }
}
