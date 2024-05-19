using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

// https://mike-87852.medium.com/create-a-scrolling-background-in-unity-ccd6ae660f0b -> creating an infitely scrolling background
public class Sidescroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [Header("Image Scrolling Data")]
    [SerializeField] private Transform[] _backgrounds;
    [SerializeField] private Transform _respawn, _border1, _border2;
    private Vector3 _leftEdge;

    // Start is called before the first frame update
    void Start()
    {
        _leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        for(int i = 0; i < _backgrounds.Length; i++){
            Transform transform = _backgrounds[i];
            float x = transform.position.x;
            float y = transform.position.y;
            transform.position = new Vector2(x - _speed * Time.deltaTime, y);
            if(_border1.position.x < _leftEdge.x || _border2.position.x < _leftEdge.x){
                transform.position = _respawn.position;
            }
        }
    }
}
