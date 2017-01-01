using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	void End() {
		SceneManager.LoadScene("Level2");
	}
}
