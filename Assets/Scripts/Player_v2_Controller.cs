using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://www.youtube.com/watch?v=wiuJiFQ78kQ -> Player Movement
// https://www.youtube.com/watch?v=ailbszpt_AI&t=123s -> Constraining player to the screen
public class Player_v2_Controller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    

    [SerializeField] private WaterBar _waterBar;
    [Header("Water Data")]
    [SerializeField] private int _water; 
    [SerializeField] private int _waterMin;
    [SerializeField] private int _waterMax; 
    // [SerializeField] private int _waterGained;
    // [SerializeField] private int _waterCost;
    [SerializeField] private int _waterDamage;

    [Header("Hazard Effects")]
    [SerializeField] private float _flyTime; 
    [SerializeField] private float _invulnTime;
    [SerializeField] private int _cloudPoisonDamage;
    [SerializeField] private int _cloudPoisonTime;
    [SerializeField] private int _flickerAmount;
    private bool _inCloud, _inPlane, _inHeli, _isDamaged;

    // Start is called before the first frame update
    void Start()
    {
        _waterBar.setMaxWater(_waterMax);
        _waterBar.SetWater(_waterMax);
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0){
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        Vector3 playerPos = new Vector3(moveInput, 0, 0) * _moveSpeed * Time.deltaTime;
        transform.position += playerPos;

        if(_water <= 0)
            SceneManager.LoadScene("GameOver"); // Game Over!
    }

    /*
    void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Obstacle"){
            float waterFloat = (float)waterCount;
            waterFloat = waterFloat - 0.10f;
            waterCount = (int)waterFloat;
            waterCounterText.text = waterCount.ToString();
        }
    }
    */

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!_isDamaged){
            // branch damage
            if (collision.gameObject.name == "LeftBranch(Clone)" || collision.gameObject.name == "RightBranch(Clone)"){
                _water -= _waterDamage;
                _waterBar.SetWater(_water);
                StartCoroutine("Damage");
            }

            // plane and heli damage
            if  (   
                    collision.gameObject.name == "NWPlane(Clone)" || 
                    collision.gameObject.name == "NEPlane(Clone)" ||
                    collision.gameObject.name == "SWPlane(Clone)" ||
                    collision.gameObject.name == "SEPlane(Clone)" ||
                    collision.gameObject.name == "Heli(Clone)"
                )
            {

                _water -= _waterDamage;
                _waterBar.SetWater(_water);
                StartCoroutine("Damage");
            }
            
            // cloud damage
            if (collision.gameObject.name == "Cloud(Clone)"){
                StartCoroutine("CloudDamage");
            }
        }
    }

    IEnumerator Damage()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        _isDamaged = true;
        for(int i = 0; i < _flickerAmount; i++){
            sprite.enabled = false;
            yield return new WaitForSeconds(_invulnTime);
            sprite.enabled = true;
            yield return new WaitForSeconds(_invulnTime);
        }
        _isDamaged = false;
    }
    IEnumerator CloudDamage()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        _isDamaged = true;
        for(int i = 0; i < _cloudPoisonTime; i++){
            sprite.enabled = false;
            _water -= _cloudPoisonDamage;
            _waterBar.SetWater(_water);
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        _isDamaged = false;
    }
}
