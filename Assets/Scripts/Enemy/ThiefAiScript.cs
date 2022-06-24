using UnityEngine;
using UnityEngine.AI;

public class ThiefAiScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public int stolenMoney;
    public int minRangeOfMoney, maxRangeOfMoney;
    public Transform fleeTarget;

    public float sightRange, robRange;
    public bool playerInSightRange, playerInRobRange, alreadyRob;

    public Money moneyScript;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInRobRange = Physics.CheckSphere(transform.position, robRange, whatIsPlayer);

        if (!playerInSightRange) Patroling();
        if (playerInSightRange && !alreadyRob) ChasePlayer();
        if (playerInSightRange && alreadyRob) FleePlayer();
    }
    private void Patroling()
    {
        agent.speed = 3.5f;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        if (playerInRobRange && !alreadyRob)
        {
            int moneyToRob = Random.Range(minRangeOfMoney, maxRangeOfMoney);
            if(moneyScript.currentMoney - moneyToRob < 0)
            {
                moneyToRob = moneyScript.currentMoney;
            }
            moneyScript.updateMoney(-moneyToRob);
            stolenMoney = moneyToRob;
            alreadyRob = true;
        }
    }
    private void FleePlayer()
    {
        agent.SetDestination(fleeTarget.position);
        agent.speed = 6f;
        sightRange = 40f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, robRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void returnMoney()
    {
        moneyScript.updateMoney(stolenMoney);
    }
}

