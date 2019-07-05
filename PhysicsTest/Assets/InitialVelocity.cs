using UnityEngine;

public class InitialVelocity : MonoBehaviour {
	
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 3);
	}
}
