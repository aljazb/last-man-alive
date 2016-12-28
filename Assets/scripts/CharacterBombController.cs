using UnityEngine;
using System.Collections;

public class CharacterBombController : MonoBehaviour {

	[SerializeField] public int BombCount;
	[SerializeField] private GameObject BombPrefab;

	void Update () {
		if (BombCount > 0 && Input.GetKeyDown(KeyCode.Space)) {
			BombCount--;
			Instantiate(BombPrefab, transform.position, transform.rotation);
		}
	}

	public void AddBomb() {
		BombCount++;
	}
}
