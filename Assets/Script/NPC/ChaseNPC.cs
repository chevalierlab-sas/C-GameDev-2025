using UnityEngine;
using UnityEngine.AI;
using Unity.VisualScripting;
using System.Collections;

public class ChaseNPC : MonoBehaviour
{
    public float patrolRadius = 20f;
    public float detectionRadius = 30f;
    public Transform player;
    public float damage = 10f;

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolTarget;
    private Vector3 originalPosition;
    private bool isPatrolling = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //SetNewPatrolTarget();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(patrolTarget);
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRadius)
        {
            StopCoroutine(Patrol());
            isPatrolling = false;
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            if (!isPatrolling)
            {
                StartCoroutine(Patrol());
                isPatrolling = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("player")) {
            StartCoroutine(Attack());
        }
        
    }

    IEnumerator Patrol()
    {
        while (isPatrolling)
        {
            Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
            randomDirection += originalPosition;

            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1);
            Vector3 finalPosition = hit.position;

            navMeshAgent.SetDestination(finalPosition);

            yield return new WaitForSeconds(Random.Range(3f, 7f)); // Wait for a random amount of time before moving again
        }
    }

    IEnumerator Attack()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        //yield return new WaitForSeconds(0.4f);
        if (playerHealth != null)
        {
            playerHealth.takeDamage(damage);
        }
        yield return new WaitForSeconds(0.1f);

    }
}
