using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCloudController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpForce;
    [SerializeField] private WaterBar _waterBar;
    [Header("Water Data")]
    [SerializeField] private int _water; 
    [SerializeField] private int _waterMin;
    [SerializeField] private int _waterMax; 
    [SerializeField] private int _waterGained;
    [SerializeField] private int _waterCost;
    [SerializeField] private int _waterDamage;
    [Header("Hazard Effects")]
    [SerializeField] private Vector2 _windVector;
    [SerializeField] private float _throwTime; 
    [SerializeField] private float _invulnTime;
    [SerializeField] private int _flickerAmount;
    private bool _isJumping, _inWhirlwind, _isDamaged;//, _hittingWall;
    private float _gravity;
	// audio sources
	public AudioSource jump;
	public AudioSource impact;
	public AudioSource waterpickup;
	public AudioSource whirlwind;

    // Start is called before the first frame update
    void Start()
    {
        _isJumping = false;
        _inWhirlwind = false;
        //_hittingWall = false;
        _gravity = _rb.gravityScale;
        _waterBar.setMaxWater(_waterMax);
        _waterBar.SetWater(_waterMax);
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && _water > 0 && !_isJumping){
            _isJumping = true;
			jump.Play();
        }
        if(_water <= 0)
            SceneManager.LoadScene("GameOver_Level2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_isJumping && !_inWhirlwind){
            StartCoroutine("Jump");
            _water -= _waterCost;
            _waterBar.SetWater(_water);
            _isJumping = false;
        }
        if(_inWhirlwind){
            _rb.AddForce(_windVector * Time.deltaTime, ForceMode2D.Impulse);
            StopCoroutine("Jump");
            _rb.gravityScale = _gravity;
            whirlwind.Play();
			StartCoroutine("Throw");
        }
    }

    void DamagePlayer()
    {
		impact.Play();
        _water -= _waterDamage;
        _waterBar.SetWater(_water);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!_isDamaged && collision.gameObject.name == "Mountain(Clone)" || collision.gameObject.name == "Mountain"){
            DamagePlayer();
            StartCoroutine("Damage");
        }
        if(collision.gameObject.name == "HorzWall"){
            DamagePlayer();
            StartCoroutine("HitWall");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Water(Clone)" || collider.gameObject.name == "Water"){
            Destroy(collider.gameObject);
			waterpickup.Play();
            _water += _waterGained;
            _waterBar.SetWater(_water);
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

    IEnumerator HitWall()
    {
        _rb.AddForce(new Vector3(0, 140) * Time.deltaTime, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);
    }
}
