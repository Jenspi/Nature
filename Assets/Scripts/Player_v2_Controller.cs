using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=wiuJiFQ78kQ -> Player Movement
// https://www.youtube.com/watch?v=ailbszpt_AI&t=123s -> Constraining player to the screen
public class Player_v2_Controller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _wall;
    private Vector3 _screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 playerPos = new Vector3(moveInput, 0, 0) * _moveSpeed * Time.deltaTime;
        transform.position += playerPos;
    }
}
