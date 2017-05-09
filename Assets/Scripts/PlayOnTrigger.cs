using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTrigger : MonoBehaviour {

    private AudioSource audioFX;
    public GameObject fonte;

    void Start() {
        audioFX = fonte.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            audioFX.Play();
        }
    }
}
