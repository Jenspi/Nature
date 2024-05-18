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
    private bool _isTiming;
    private Scene _currentScene;
    // Start is called before the first frame update
    void Start()
    {
        _isTiming = false;
        _currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isTiming && _currentScene.name == "Zach_Scene_Condesation"){
            _isTiming = true;
            StartCoroutine("TimerLevel2");
        }
    }

    IEnumerator TimerLevel2()
    {
        int timer = _timer;
        while(timer > 0){
            _myText.text = timer.ToString();
            timer--;
            yield return new WaitForSeconds(1);
        }
        _isTiming = false;
        GlobalVariables.Set("lorePath", "Assets/Scripts/Dialogue/DialogueLore3.txt");
		GlobalVariables.Set("nextScene", "TitleScene");
		SceneManager.LoadScene("LoreScene1");
    }
}
