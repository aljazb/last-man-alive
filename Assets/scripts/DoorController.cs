using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	[SerializeField] private GameObject[] Doors;
	[SerializeField] private int HitCount;
	[SerializeField] private int ChangeCount;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			HitCount++;

			if (HitCount > 3*ChangeCount) {
				gameObject.GetComponent<BoxCollider>().enabled = false;
				Doors[2].GetComponent<BoxCollider>().enabled = true;
				Doors[2].GetComponent<CapsuleCollider>().enabled = true;
				Doors[2].GetComponent<Rigidbody>().isKinematic = false;
//				Doors[2].GetComponent<Rigidbody>().AddForce(0,10f,0);
			} else if (HitCount > 2*ChangeCount) {
				Doors[1].SetActive(false);
				Doors[2].SetActive(true);
			} else if (HitCount > ChangeCount) {
				Doors[0].SetActive(false);
				Doors[1].SetActive(true);
			}
		}
	}
}
