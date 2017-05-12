using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement:MonoBehaviour {

    float distanciaParaSeguir = 30.0f;
    float distanciaParaAtaque = 3.0f;

    Transform player;               // Reference to the player's position.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    Animator anim;
    float distanciaAtePlayer;

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

    void OnTriggerStay(Collider other) {

        if(other.gameObject.tag == "Player") {
            anim.SetBool("Idle", true);
            anim.SetTrigger("Attack");
        }
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
        }
    }
}