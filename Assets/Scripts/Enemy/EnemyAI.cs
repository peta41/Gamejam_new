using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;          
    private NavMeshAgent agent;      
    public float customSpeed = 3.5f;   
    public float approachDistance = 5f; // Vzdálenost, když se aktivuje animace
    private Animator animator; // Reference na Animator

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = customSpeed;
       Player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>(); // Získání komponenty Animator
    }

    void Update()
    {
        if (Player != null)
        {
            agent.SetDestination(Player.position); 

            float distance = Vector3.Distance(transform.position, Player.position);
            if (distance <= approachDistance)
            {
                // Aktivace animace pro přiblížení
                animator.SetBool("IsApproaching", true);
            }
            else
            {
                // Deaktivace animace pro přiblížení, pokud je nepřítel dále
                animator.SetBool("IsApproaching", false);
            }

            // Kontrola, zda se nepřítel pohybuje
            if (agent.velocity.magnitude > 0.1f)
            {
                // Aktivace animace chůze
                animator.SetBool("IsWalking", true);
            }
            else
            {
                // Deaktivace animace chůze, pokud se nepřítel nepohybuje
                animator.SetBool("IsWalking", false);
            }
        }
    }
}