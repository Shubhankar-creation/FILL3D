using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent Mob;
    public GameObject Player;

    private HoleCreation HCreate;
    private void Start()
    {
        HCreate = GameObject.FindGameObjectWithTag("HoleInstance").GetComponent<HoleCreation>();
        Mob = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);

        if (distance < HCreate.modDistance)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            Mob.SetDestination(newPos);
        }
    }
}
