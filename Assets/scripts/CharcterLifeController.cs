using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharcterLifeController : MonoBehaviour {
	[SerializeField] private float CharacterLife;
	[SerializeField] private float ZombieDamage;
	[SerializeField] private float BigDaddyDamage;
	[SerializeField] private Slider Slider;
	[SerializeField] private SpriteRenderer NoSpawnRadious;
	[SerializeField] private GameObject DeathPrefab;
	[SerializeField] private GameObject CharModel;
	[SerializeField] private Animator CameraAnimator;
	[SerializeField] private AudioSource CharacterDyingSound;
	[SerializeField] private AudioSource CharacterDieSound;

	Color NormalColor;
	Color RedColor;
	bool Dead = false;

	void Start () {
		CharacterLife = 1;
		NormalColor = new Color(0.5f, 0.5f, 0.5f, 0.24f);
		RedColor = new Color(1f, 0, 0, 0.24f);
	}

	public void Bomb(float magnitude) {
		CharacterLife -= magnitude/2f;
		Slider.value = CharacterLife;
		if (!IsAlive()) {
			Die();
		}
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
			CharacterDyingSound.Play();
		}
		else {
			Die();
		}
	} 

	bool IsAlive() {
		return CharacterLife > 0;
	}

	void Die() {
		if (!Dead) {
			CameraAnimator.SetTrigger("EndDeath");
			Dead = true;
			Instantiate(DeathPrefab, transform.position, Quaternion.identity);
			CharModel.SetActive(false);
			NoSpawnRadious.enabled = false;
			CharacterDieSound.Play();
		}
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
