using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance = null;

	public Transform CharacterTransform = null;
	public CharacterMovementController CharacterMovementController = null;

	void Awake() {
		Instance = this;
	}

	public static Vector2 Dir2Vec(int dir) {
		switch (dir) {
		case 0:
			return new Vector2(0, 1f);
		case 1:
			return new Vector2(1f, 1f);
		case 2:
			return new Vector2(1f, 0);
		case 3:
			return new Vector2(1f, -1f);
		case 4:
			return new Vector2(0, -1f);
		case 5:
			return new Vector2(-1f, -1f);
		case 6:
			return new Vector2(-1f, 0);
		case 7:
			return new Vector2(-1f, 1f);
		default:
			Debug.LogError("Neveljavna smer");
			return Vector2.zero;
		}
	}
}
