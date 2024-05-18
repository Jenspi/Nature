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
	public Image topSpeaker;
	public Image botSpeaker;
	public Image[] childrens;
	
	// 1 Narrator
	public Sprite speaker1;
	// 2 WaterDrop
	public Sprite speaker2;
	// 3 Sun
	public Sprite speaker3;
	// 4 Lake
	public Sprite speaker4;
	
	private int index;
	private string nextScene =  "TitleScene";
	private string speaker;
	private string place;
	private string dialog;
	
    // Start is called before the first frame update
    void Start()
    {
        childrens = GetComponentsInChildren<Image>();
		topSpeaker = childrens[1];
		botSpeaker = childrens[2];
		
		string lorePath = GlobalVariables.Get<string>("lorePath");
		nextScene = GlobalVariables.Get<string>("nextScene");
		if (lorePath == null) {lorePath = "Assets/Scripts/Dialogue/DialogueLore1.txt";}
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
				if (place == "1") {
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
		place = tokens[1];
		dialog = tokens[2];
		Sprite newHead;
		switch (speaker) {
			case "1":
			newHead = speaker1;
			break;
			case "2":
			newHead = speaker2;
			break;
			case "3":
			newHead = speaker3;
			break;
			case "4":
			newHead = speaker4;
			break;
			default:
			newHead = speaker1;
			break;
		}
		
		foreach (char c in dialog.ToCharArray()) {
			if (place == "1") {
				topSpeaker.sprite = newHead;
				textComponentTop.text += c;
			} else {
				botSpeaker.sprite = newHead;
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
