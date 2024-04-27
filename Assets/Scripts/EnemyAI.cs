using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyAI : MonoBehaviour
{
    public Transform Player;          
    private NavMeshAgent agent;      
    public float customSpeed = 3.5f;   

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = customSpeed;
        Player = GameObject.Find("Player").transform;  
    }

    void Update()
    {
        if (Player != null)
        {
            agent.SetDestination(Player.position); 
        }
    }
}