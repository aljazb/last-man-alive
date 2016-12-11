using UnityEngine;
using System.Collections;

public class BulletMovementController : MonoBehaviour {
	[SerializeField] public int Direction;
	[SerializeField] private float BulletSpeed;

	void Update () {
		MoveBullet ();
	}

	void MoveBullet() {
		switch (Direction) {
			case 0:
				ChangePosition (0, 1);
				break;
			case 1:
				ChangePosition (1, 1);
				break;
			case 2:
				ChangePosition (1, 0);
				break;
			case 3:
				ChangePosition (1, -1);
				break;
			case 4:
				ChangePosition (0, -1);
				break;
			case 5:
				ChangePosition (-1, -1);
				break;
			case 6:
				ChangePosition (-1, 0);
				break;
			case 7:
				ChangePosition (-1, 1);
				break;
			default:
				break;
		}
	}


	void ChangePosition (int x, int z) {
		transform.position += Vector3.Normalize(new Vector3(x, 0, z)) * BulletSpeed * Time.deltaTime; 
	}

	void OnTriggerEnter(Collider col) {
		Destroy(gameObject);
	}

}
