using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _boundrary;
    private float _yPos;
    [Header("Water Movement")]
    [SerializeField] private bool _canBob;
    [SerializeField] private float _bobbingFrequency;
    [SerializeField] private float _bobbingMagnitude;
    [SerializeField] private float _bobbingLimit;

    // Start is called before the first frame update
    void Start()
    {
        _boundrary = GameObject.FindGameObjectWithTag("Boundrary").GetComponent<Transform>();
        StartCoroutine("GoUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        this.transform.position = new Vector3(x - _speed, y);
    }

    void LateUpdate()
    {
        float boundraryLimit = _boundrary.position.x;
        if(this.transform.position.x <= boundraryLimit){
            Debug.Log("Destroyed: " + gameObject.name);
            Destroy(this.gameObject);
        }
    }

    IEnumerator GoUp(){
        bool isGoingUp = true;
        for(;;){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + _bobbingMagnitude);
            if(this.transform.position.y >= _yPos + _bobbingLimit)
                isGoingUp = false;
            if(!isGoingUp)
                break;
            yield return new WaitForSeconds(_bobbingFrequency);
        }
        StartCoroutine("GoDown");
    }

    IEnumerator GoDown(){
        bool isGoingDown = true;
        for(;;){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - _bobbingMagnitude);
            if(this.transform.position.y <= _yPos - _bobbingLimit)
                isGoingDown = false;
            if(!isGoingDown)
                break;
            yield return new WaitForSeconds(_bobbingFrequency);
        }
        StartCoroutine("GoUp");
    }
}
