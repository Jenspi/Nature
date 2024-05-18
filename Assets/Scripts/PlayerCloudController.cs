using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloudController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _water;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector2 _windVector;
    [SerializeField] private int _waterMin, _waterMax, _waterGained, _waterLost;
    [SerializeField] private float _throwTime;
    private bool _isJumping, _inWhirlwind;
    private float _gravity;

    // Start is called before the first frame update
    void Start()
    {
        _isJumping = false;
        _inWhirlwind = false;
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
        if(_isJumping && !_inWhirlwind){
            StartCoroutine("Jump");
            _water -= _waterLost;
            _isJumping = false;
        }
        if(_inWhirlwind){
            _rb.AddForce(_windVector * Time.deltaTime, ForceMode2D.Impulse);
            StopCoroutine("Jump");
            _rb.gravityScale = _gravity;
            StartCoroutine("Throw");
        }
    }

    void LateUpdate(){
        if(_water <= 0)
            ; // Game Over!
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Water(Clone)" || collider.gameObject.name == "Water"){
            Destroy(collider.gameObject);
            _water += _waterGained;
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.name == "Whirlwind(Clone)" || collider.gameObject.name == "Whirlwind"){
            _inWhirlwind = true;
        }
    }

    IEnumerator Jump()
    {
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(0, _jumpForce);
        _rb.gravityScale = _gravity;
        // yield return new WaitForSeconds(0.5f);
        // _rb.gravityScale = _gravity;
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Throw()
    {
        yield return new WaitForSeconds(_throwTime);
        _inWhirlwind = false;
    }
}
