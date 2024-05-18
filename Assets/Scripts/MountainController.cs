using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainController : MonoBehaviour
{
    [SerializeField] private bool _canBob;
    [SerializeField] private float _speed;
    [SerializeField] private int _directionTime;
    [SerializeField] private float _yPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GoUp");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x - _speed, this.transform.position.y);
    }

    void LateUpdate()
    {
        if(this.transform.position.x <= -20f){
            Debug.Log("Destroyed Object");
            Destroy(this.gameObject);
        }
    }

    IEnumerator GoUp(){
        bool isGoingUp = true;
        for(;;){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.07f);
            yield return new WaitForSeconds(0.005f);
            if(this.transform.position.y >= _yPos + 3)
                isGoingUp = false;
            if(!isGoingUp)
                break;
        }
        StartCoroutine("GoDown");
    }

    IEnumerator GoDown(){
        bool isGoingDown = true;
        for(;;){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.07f);
            yield return new WaitForSeconds(0.005f);
            if(this.transform.position.y <= _yPos - 3)
                isGoingDown = false;
            if(!isGoingDown)
                break;
        }
        StartCoroutine("GoUp");
    }
}
