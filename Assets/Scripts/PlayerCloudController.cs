using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloudController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _water;
    [SerializeField] private float _jumpForce;
    private bool _isJumping;
    private float _gravity;

    // Start is called before the first frame update
    void Start()
    {
        _isJumping = false;
        _gravity = _rb.gravityScale;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && _water > 0 && !_isJumping){
            _isJumping = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_isJumping){
            StartCoroutine("Jump");
            _water -= 10;
            _isJumping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Water(Clone)" || collider.gameObject.name == "Water"){
            Destroy(collider.gameObject);
            _water += 10;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(GetComponent<Collider>().gameObject.name == "Mountain(Clone)" || collision.gameObject.name == "Mountain"){
            _water -= 20;
        }
    }

    IEnumerator Jump(){
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(0, _jumpForce);
        yield return new WaitForSeconds(0.5f);
        _rb.gravityScale = _gravity;
    }
}
