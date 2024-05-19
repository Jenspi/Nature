using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class CreditsScrolling : MonoBehaviour
{
   	public TextMeshProUGUI textComponent;
	public TextMeshProUGUI textComponent2;
	public string[] lines;
	public float textSpeed;
	private int index;
	private string nextScene =  "TitleScene";
	private string text;
	private string text2;
	
	// Start is called before the first frame update
    void Start() {
		index = 0;
        string lorePath = "Assets/Scripts/Dialogue/Credits.txt";
		text = File.ReadAllText(lorePath);
		textComponent.text = string.Empty;
		string lorePath2 = "Assets/Scripts/Dialogue/Credits2.txt";
		text2 = File.ReadAllText(lorePath2);
		textComponent2.text = string.Empty;
		StartDialogue();

    }

    // Update is called once per frame
    void Update() {
		
		var textPos = textComponent.GetComponent<RectTransform>();
        var textcoords = textPos.localPosition;
		if (textcoords.y < 0 && index == 5) {
			textPos.localPosition = new Vector3(textcoords.x, textcoords.y+1, textcoords.z);
			index = 0;
		} else {
			index++;
		}
		
        if(Input.GetMouseButtonDown(0)) {
			if (textComponent.text == text && textComponent2.text == text2) {
				NextLine();
			} else if (textComponent.text == text && textComponent2.text != text2) {
				textComponent2.text = text2;
			}				
			else {
				StopAllCoroutines();
				textPos.localPosition = new Vector3(textcoords.x, 0, textcoords.z);
				textComponent.text = text;
			}
		}
    }
	void StartDialogue() {
		//index = 0;
		StartCoroutine(TypeLine());
	}
	
	IEnumerator TypeLine() {
		
		foreach (char c in text.ToCharArray()) {
			textComponent.text += c;			
			yield return new WaitForSeconds(textSpeed);
		}
	}
	
	void NextLine() {
			SceneManager.LoadScene(nextScene);
	}
}
