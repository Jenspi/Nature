using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TSButtons : MonoBehaviour
{
	public void NewGame() {
		GlobalVariables.Set("lorePath", "Assets/Scripts/Dialogue/DialogueLore1.txt");
		GlobalVariables.Set("nextScene", "DanielScene 1");
		SceneManager.LoadScene("LoreScene1");
	}
	
	public void Continue() {
		GlobalVariables.Set("lorePath", "Assets/Scripts/Dialogue/DialogueLore2.txt");
		GlobalVariables.Set("nextScene", "Zach's Scene");
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
		// Debug.Log("Game is exiting");
		// Just to make sure its working
	}
}
