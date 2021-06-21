using UnityEngine;
using UnityEngine.AI;

public class HoleCreation : MonoBehaviour
{
    private GameObject HoleParent;
    private GameObject Collider2dTo3d;
    private GameObject ground2D;
    private GameObject Hole2D;
    private GameObject Coll3Dmesh;
    private NavMeshAgent navMeshAgent;

    private float xVal, zVal;

    public float enemyFollowSpeed = 1.5f, modDistance = 10f;


    PolygonCollider2D groundCol;
    PolygonCollider2D HoleCol;
    MeshCollider Mesh3DColl;
    private HoleMovement holeMove;


    public GameObject HoleShape;

    private Vector2[] polyPoint = {new Vector2(10f,10f),
                            new Vector2(-10f,10f),
                            new Vector2(-10f,-10f),
                            new Vector2(10f,-10f)};
    private void Start()
    {
        Ground2dCol();
        Mesh3DCol();
        for (int i = 0; i < 4; i++)
        {
            Instantiate2dGOs(i);
            AddingHoleComponents(i);
        }
    }

    










    private void Instantiate2dGOs(int index)
    {
        Collider2dTo3d = new GameObject(); Collider2dTo3d.name = "Collider2dTo3d";
        Collider2dTo3d.transform.parent = transform;

        Hole2dCol(index);

    }
    private void AddingHoleComponents(int index)
    {
        HoleParent = new GameObject(); HoleParent.name = "HoleParent";
        HoleParent.transform.parent = transform;
        randomPos();
        HoleParent.transform.position = new Vector3(xVal, HoleParent.transform.position.y, zVal);
        MovementHoleComponent();

        GameObject newHole = Instantiate(HoleShape, HoleParent.transform.position, Quaternion.identity) as GameObject;
        newHole.transform.parent = HoleParent.transform;
    }

    void randomPos()
    {
        xVal = Random.Range(0f, 10f);
        zVal = Random.Range(0f, 10f);
    }

    void MovementHoleComponent()
    {
        holeMove = HoleParent.AddComponent<HoleMovement>();
        HoleParent.AddComponent<EnemyFollow>();
        navMeshAgent = HoleParent.AddComponent<NavMeshAgent>();
        navMeshAgent.speed = enemyFollowSpeed;


        holeMove.Hole2dCollider = HoleCol;
        holeMove.Ground2dCollider = groundCol;
        holeMove.GeneratedMeshCollider = Mesh3DColl;
    }


    void Ground2dCol()
    {
        ground2D = new GameObject();
        ground2D.name = "Ground2D";
        groundCol = ground2D.AddComponent<PolygonCollider2D>();
        groundPolySet(groundCol);
    }

    void Hole2dCol(int index)
    {
        Hole2D = new GameObject();
        Hole2D.name = "" + index;
        HoleCol = Hole2D.AddComponent<PolygonCollider2D>();
        Hole2D.transform.parent = Collider2dTo3d.transform;
    }

    void Mesh3DCol()
    {
        Coll3Dmesh = new GameObject();
        Coll3Dmesh.name = "3dMeshColl";
        Mesh3DColl = Coll3Dmesh.AddComponent<MeshCollider>();
        Coll3Dmesh.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
    void groundPolySet(PolygonCollider2D ground2dCol)
    {
        ground2dCol.SetPath(0, polyPoint);
    }
}

