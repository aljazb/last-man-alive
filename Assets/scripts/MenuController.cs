using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void LoadGame() {
		SceneManager.LoadScene("MainScene");
	}

	public void Quit() {
		Application.Quit();
	}
}
