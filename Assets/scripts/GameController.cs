using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance = null;

	public Transform CharacterTransform = null;
	public CharacterMovementController CharacterMovementController = null;

	void Awake() {
		Instance = this;
	}
}
