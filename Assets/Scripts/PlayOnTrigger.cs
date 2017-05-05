using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTrigger : MonoBehaviour {

    public AudioSource audioFX;

    void Start() {
        audioFX = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player") {
            audioFX.Play();
        }
    }
}
