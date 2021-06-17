using UnityEngine;
using UnityEngine.AI;
public class EnemyHoleAI : MonoBehaviour
{

    private GameObject playerShape;

    private NavMeshAgent holeGO;
    public float mobDistance;

    private void Start()
    {

        playerShape = GameObject.FindGameObjectWithTag("Player");
        holeGO = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerShape.transform.position);
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

        Debug.Log(distance);

        if(distance < mobDistance)
        {
            Vector3 dirToPlayer = transform.position - playerShape.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            holeGO.SetDestination(newPos);
        }
    }
}
