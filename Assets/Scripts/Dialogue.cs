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
	
    // Start is called before the first frame update
    void Start()
    {
        FileInfo theSourceFile = new FileInfo ("Assets/Scripts/Dialogue/TopDialogue.txt");
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
			if (textComponentTop.text == lines[index]) {
				NextLine();
			} else if (textComponentBot.text == lines[index]) {
				NextLine();
			} else {
				StopAllCoroutines();
				if (index % 2 == 0) {
				textComponentTop.text = lines[index];
				} else {
				textComponentBot.text = lines[index];
				}
			}
		}
    }
	
	void StartDialogue() {
		index = 0;
		StartCoroutine(TypeLine());
	}
	
	IEnumerator TypeLine() {
		foreach (char c in lines[index].ToCharArray()) {
			if (index % 2 == 0) {
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
			SceneManager.LoadScene("DanielScene 1");
		}
	}
}
