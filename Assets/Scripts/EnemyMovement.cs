using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement:MonoBehaviour {

    public AudioClip ataqueAudio;
    public AudioClip seguirAudio;
    public float esperaParaSumir = 1.0f;

    float distanciaParaSeguir = 30.0f;
    float distanciaParaAtaque = 3.0f;

    Transform player;               // Reference to the player's position.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    Animator anim;
    float distanciaAtePlayer;
    bool jaDeuGritoDeGerra = false;
    bool jaAtacou = false;

    private IEnumerator ataqueCoroutine;

    void Awake() {
        // Set up the references.

        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        AtualizaDistanciaAtePlayer();
    }

    void Update() {
        AtualizaDistanciaAtePlayer();
    }

    void OnTriggerEnter(Collider other) {
        ataqueCoroutine = AtaqueEDestroi(other);
        StartCoroutine(ataqueCoroutine);
    }

    void OnTriggerExit(Collider other) {
        anim.SetBool("Idle", false);
    }

    void AtualizaDistanciaAtePlayer() {
        
        distanciaAtePlayer = Vector3.Distance(player.transform.position, transform.position);

        if(distanciaAtePlayer < distanciaParaSeguir && 
            distanciaAtePlayer > distanciaParaAtaque) {

            nav.SetDestination(player.position);
            anim.SetBool("Idle", false);

            if (!jaDeuGritoDeGerra) {
                SoundManager.instance.PlayerSingle(seguirAudio);
                jaDeuGritoDeGerra = true;
            }
        }
    }

    private IEnumerator AtaqueEDestroi(Collider other) {

        if(other.gameObject.tag == "Player" && !jaAtacou) {

            jaAtacou = true;

            SoundManager.instance.PlayerSingle(ataqueAudio);
            anim.SetBool("Idle", true);
            anim.SetTrigger("Attack");

            yield return new WaitForSeconds(esperaParaSumir);

            DestroyObject(this.gameObject);
        }

        yield return new WaitForSeconds(0.0f);
    }
}