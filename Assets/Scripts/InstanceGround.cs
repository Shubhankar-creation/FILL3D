using UnityEngine;
using UnityEngine.AI;

public class InstanceGround : MonoBehaviour
{
    private SpawnDetection shapeSpawn;
    private GameObject groundInstance;
    public GameObject Ground;
    public NavMeshSurface NavSurface;
    void Start()
    {
        shapeSpawn = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnDetection>();
    }
    void Update()
    {
        if (shapeSpawn.canInstantiate)
        {
            groundInstance = Instantiate(Ground, new Vector3(shapeSpawn.posXVal, 0f, shapeSpawn.posZVal), Quaternion.identity) as GameObject;
            groundInstance.transform.parent = transform;

            NavSurface.BuildNavMesh();
        }
    }
}
