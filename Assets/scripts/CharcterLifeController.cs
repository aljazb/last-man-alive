using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharcterLifeController : MonoBehaviour {
	[SerializeField] private float CharacterLife;
	[SerializeField] private float ZombieDamage;
	[SerializeField] private float BigDaddyDamage;
	[SerializeField] private Slider Slider;

	void Start () {
		CharacterLife = 1;
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
			lifeDamaged(false);
		} else if (col.gameObject.tag == "BigDaddy") {
			lifeDamaged(true);
		}
	}
}
