using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class Dialogue : MonoBehaviour
{
	public TextMeshProUGUI textComponentTop;
	public TextMeshProUGUI textComponentBot;
	public string[] lines;
	public float textSpeed;
	
	private int index;
	private string nextScene;
	private string speaker;
	private string dialog;
	
    // Start is called before the first frame update
    void Start()
    {
        string lorePath = GlobalVariables.Get<string>("lorePath");
		nextScene = GlobalVariables.Get<string>("nextScene");
		Debug.Log(lorePath);
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
		textComponentTop.text = string.Empty;
		textComponentBot.text = string.Empty;
		StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
			if (textComponentTop.text == dialog) {
				NextLine();
			} else if (textComponentBot.text == dialog) {
				NextLine();
			} else {
				StopAllCoroutines();
				if (speaker == "1") {
				textComponentTop.text = dialog;
				} else {
				textComponentBot.text = dialog;
				}
			}
		}
    }
	
	void StartDialogue() {
		index = 0;
		StartCoroutine(TypeLine());
	}
	
	IEnumerator TypeLine() {
		string[] tokens = lines[index].Split("  ");
		speaker = tokens[0];
		dialog = tokens[1];
		foreach (char c in dialog.ToCharArray()) {
			if (speaker == "1") {
				textComponentTop.text += c;
			} else {
				textComponentBot.text += c;			
			}
			yield return new WaitForSeconds(textSpeed);
		}
	}
	
	void NextLine() {
		if (index < lines.Length -1) {
			index++;
			textComponentTop.text = string.Empty;
			textComponentBot.text = string.Empty;
			StartCoroutine(TypeLine());		
		} else {
			gameObject.SetActive(false);
			SceneManager.LoadScene(nextScene);
		}
	}
}
