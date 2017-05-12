using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour {

    public string otherTag;

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == otherTag) {
			Destroy (this.gameObject);
		}
	}
}
