using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharcterLifeController : MonoBehaviour {
	[SerializeField] private float CharacterLife;
	[SerializeField] private float ZombieDamage;
	[SerializeField] private float BigDaddyDamage;
	[SerializeField] private Slider Slider;
	[SerializeField] private SpriteRenderer NoSpawnRadious;

	Color NormalColor;
	Color RedColor;

	void Start () {
		CharacterLife = 1;
		NormalColor = new Color(0.5f, 0.5f, 0.5f, 0.24f);
		RedColor = new Color(1f, 0, 0, 0.24f);
	}

	void lifeDamaged(bool isBigDaddy) {
		if (IsAlive()) {
			if (isBigDaddy) {
				CharacterLife -= BigDaddyDamage * Time.fixedDeltaTime;
			}
			else {
				CharacterLife -= ZombieDamage * Time.fixedDeltaTime;
			}
			Slider.value = CharacterLife;
		}
		else {
			Die();
		}
	} 

	bool IsAlive() {
		return CharacterLife > 0;
	}

	void Die() {
		
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Zombie") {
			NoSpawnRadious.color = RedColor;
			lifeDamaged(false);
		} else if (col.gameObject.tag == "BigDaddy") {
			NoSpawnRadious.color = RedColor;
			lifeDamaged(true);
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Zombie" || col.gameObject.tag == "BigDaddy") {
			NoSpawnRadious.color = NormalColor;
		}
	}
}
