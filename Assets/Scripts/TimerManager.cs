using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _myText;
    [SerializeField] private int _timer;
    [Header("Dialogue/Scene Info")]
    [SerializeField] private string _filename;
    [SerializeField] private string _nextScene;
    private bool _isTiming;
    // Start is called before the first frame update
    void Start()
    {
        _isTiming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isTiming ){
            _isTiming = true;
            StartCoroutine("Timer");
        }
    }

    IEnumerator Timer()
    {
        int timer = _timer;
        while(timer > 0){
            _myText.text = timer.ToString();
            timer--;
            yield return new WaitForSeconds(1);
        }
        _isTiming = false;
        GlobalVariables.Set("lorePath", "Assets/Scripts/Dialogue/" + _filename + ".txt");
		GlobalVariables.Set("nextScene", _nextScene);
		SceneManager.LoadScene("LoreScene1");
    }
}
