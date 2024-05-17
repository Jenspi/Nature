using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// https://www.youtube.com/watch?v=wiuJiFQ78kQ -> Player Movement
// https://www.youtube.com/watch?v=ailbszpt_AI&t=123s -> Constraining player to the screen
public class Player_v2_Controller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _wall;
    private Vector3 _screenBounds;
    public TMP_Text waterCounterText;
    public int waterCount;

    // Start is called before the first frame update
    void Start()
    {
        waterCounterText.text = waterCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 playerPos = new Vector3(moveInput, 0, 0) * _moveSpeed * Time.deltaTime;
        transform.position += playerPos;
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Obstacle"){
            waterCount--;
            waterCounterText.text = waterCount.ToString();
        }
        if (other.tag == "WaterDispenser"){
            waterCount++;
            waterCounterText.text = waterCount.ToString();
        }
    }
}
