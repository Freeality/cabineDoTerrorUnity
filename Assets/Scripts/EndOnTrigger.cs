using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOnTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (IsPlayer (other)) {
			Quit ();
		}
	}

	bool IsPlayer(Collider other) {
		
		if (other.gameObject.tag == "Player") {
			return true;
		}

		return false;
	}

	void Quit() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
