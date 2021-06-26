using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent Mob;
    public GameObject Player;
    public float enemySpeed = 1.5f;

    public float mobDistance = 15f;

    private void Start()
    {
        Mob = gameObject.GetComponent<NavMeshAgent>();
        Mob.speed = enemySpeed;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);

        if (distance < mobDistance)
        {

            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            Mob.SetDestination(new Vector3(newPos.x, 0f, newPos.z));
        }
    }
}

