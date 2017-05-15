using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTrigger : MonoBehaviour {

    private IEnumerator playCoroutine;
    private AudioSource audioFX;

    public GameObject fonte;

    void Start() {
        audioFX = fonte.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {

        playCoroutine = PlayCoroutine(other);
        StartCoroutine(playCoroutine);
    }

    private IEnumerator PlayCoroutine(Collider other) {

        if(other.gameObject.tag == "Player") {

            // SoundManager.instance.PlayerSingle(audioFX.clip);
            audioFX.Play();
            yield return new WaitForSeconds(1.0f);

            Destroy(gameObject);
        }

        yield return new WaitForSeconds(0.0f);
    }
}
