using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TSButtons : MonoBehaviour
{
	public void Intro() {
		GlobalVariables.Set("lorePath", "Assets/Scripts/Dialogue/DialogueIntro.txt");
		GlobalVariables.Set("nextScene", "TitleScene");
		SceneManager.LoadScene("ExpositionScene");
	}
	
	public void NewGame() {
		GlobalVariables.Set("lorePath", "Assets/Scripts/Dialogue/DialogueLore1.txt");
		GlobalVariables.Set("nextScene", "DanielScene 1");
		SceneManager.LoadScene("LoreScene1");
	}
	
	public void Continue() {
		GlobalVariables.Set("lorePath", "Assets/Scripts/Dialogue/DialogueLore2.txt");
		GlobalVariables.Set("nextScene", "Zach_Scene_Condesation");
		SceneManager.LoadScene("LoreScene1");
	}
	
	public void Credits() {
		SceneManager.LoadScene("CreditsScene");
	}
	
	public void Return() {
		SceneManager.LoadScene("TitleScene");
	}
	
	public void QuitGame() {
		Application.Quit();
	}

	public void RestartLevel1() {
		SceneManager.LoadScene("DanielScene 1");
	}

	public void RestartLevel2() {
		SceneManager.LoadScene("Level2");
	}
}
