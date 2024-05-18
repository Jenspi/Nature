using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class Exposition : MonoBehaviour
{
   	public TextMeshProUGUI textComponent;
	public string[] lines;
	public float textSpeed;
	private int index;
	private string nextScene =  "TitleScene";
	
	// Start is called before the first frame update
    void Start() {
        string lorePath = "Assets/Scripts/Dialogue/DialogueIntro.txt";
		FileInfo theSourceFile = new FileInfo(lorePath);
        StreamReader reader = theSourceFile.OpenText();
		List<string> linesList = new List<string>();
		string text;
		
		do {
			text = reader.ReadLine();
			if (text != null) {
				linesList.Add(text);
			}
		} while (text != null);
		
		lines = linesList.ToArray();
		textComponent.text = string.Empty;
		StartDialogue();

    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
			if (textComponent.text == lines[index]) {
				NextLine();
			} else {
				StopAllCoroutines();
				textComponent.text = lines[index];	
			}
		}
    }
	void StartDialogue() {
		index = 0;
		StartCoroutine(TypeLine());
	}
	
	IEnumerator TypeLine() {
		
		foreach (char c in lines[index].ToCharArray()) {
			textComponent.text += c;			
			yield return new WaitForSeconds(textSpeed);
		}
	}
	
	void NextLine() {
		if (index < lines.Length -1) {
			index++;
			textComponent.text = string.Empty;
			StartCoroutine(TypeLine());		
		} else {
			gameObject.SetActive(false);
			SceneManager.LoadScene(nextScene);
		}
	}

}
