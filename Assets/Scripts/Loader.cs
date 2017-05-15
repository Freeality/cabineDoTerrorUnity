using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject soundManager;

    private void Awake() {
        if (SoundManager.instance == null) {
            Instantiate(soundManager);
        }
    }
}
