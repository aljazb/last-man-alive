using UnityEngine;
using System.Collections;

public class CharacterBombController : MonoBehaviour {

	[SerializeField] public int BombCount;
	[SerializeField] private GameObject BombPrefab;
	[SerializeField] private UnityEngine.UI.Text BombCountText;

	void Update () {
		if (BombCount > 0 && Input.GetKeyDown(KeyCode.Space)) {
			BombCount--;
			Instantiate(BombPrefab, transform.position, transform.rotation);
		}
		BombCountText.text = BombCount.ToString();
	}

	public void AddBomb() {
		BombCount++;
	}
}
