using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent Mob;
    public GameObject Player;

    public float mobDistance = 3f;

    private void Start()
    {
        Mob = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        Mob.transform.position = new Vector3(Mob.transform.position.x,
            0f,
            Mob.transform.position.z);
    }
    private void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);

        if (distance < mobDistance)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            Mob.SetDestination(newPos);
        }
    }
}
